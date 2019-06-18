using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using OPC;
using OpcRcw.Da;
using Tool;
using Business;
using Business.BusinessClass;
using Business.Modle;

namespace SortingControlSys
{
    public partial class UnNormalFm : Form
    {
        private delegate void HandleDelegate(string strshow);
        private delegate void HandleDelegate2(Boolean visible, Control control);
        delegate StringBuilder DelSendTask(object[]data,StringBuilder outStr);
        delegate void HandleUpDate(string info);

        static HandleUpDate handle;

        OPCServer opcServer;
        /// <summary>
        /// 存放任务线路
        /// </summary>
        List<string> ListLineNum = new List<string>();

        public UnNormalFm()
        {
            InitializeComponent();
            UpdateControlEnable(false, BtnEnd);
            Initdata();
            TimeToClike.Start();
            opcServer = new OPCServer();
            handle += UpdateListBox;
        }

        private void BtnStatrt_Click(object sender, EventArgs e)
        {
            timerSendTask.Interval = 1000 * 10;
            timerSendTask.Start();
            GetTaskInfo("启动定时器");
            UpdateControlEnable(false, BtnStatrt);
            Thread thread = new Thread(new ThreadStart(startFenJian));
            thread.Start();
        }

        public void UpdateListBox(string info)
        {
            String time = DateTime.Now.ToLongTimeString();
            if (this.list_data.InvokeRequired)
            {

                this.list_data.Invoke(new HandleDelegate(UpdateListBox), info);
            }
            else
            {
                this.list_data.Items.Insert(0, time + "    " + info);
            }
        }
        public void UpdateControlEnable(Boolean enable, Control control)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new HandleDelegate2(UpdateControlEnable), new Object[] { enable, control });
            }
            else
            {
                control.Enabled = enable;

            }
        }
        public void startFenJian()
        {
            if (!opcServer.ConnectState)
            {
                GetTaskInfo("正在尝试连接服务器......");
                string[] str = opcServer.Connection();
                if (string.IsNullOrWhiteSpace(str[0]))
                {
                    opcServer.OnlyTaskGroup.addItem(PlcItemCollection.GetOnlyDBItem());//任务交互区
                    opcServer.SpyBiaozhiGroup.addItem(PlcItemCollection.GetSpyOnlyLineItem());//监控任务标识位
                    opcServer.FinishOnlyGroup.addItem(PlcItemCollection.GetOnlyLineFinishTaskItem());//完成信号交互区;
                    GetTaskInfo("opC服务器创成功！");
                    opcServer.ConnectState = opcServer.CheckConnection();
                    if (opcServer.ConnectState)
                    {
                        GetTaskInfo("PLC连接成功!");
                        opcServer.SpyBiaozhiGroup.callback = OnDataChange;
                        opcServer.FinishOnlyGroup.callback = OnDataChange;
                    }
                    else
                    {
                        GetTaskInfo("PLC连接失败!");
                        timerSendTask.Stop();
                    }
                }
                else
                 {
                    GetTaskInfo(str[0]);
                    timerSendTask.Stop();
                    UpdateControlEnable(true, BtnStatrt);
                }
            }
            else 
            {
                opcServer.SpyBiaozhiGroup.callback = OnDataChange;
                opcServer.FinishOnlyGroup.callback = OnDataChange;
            }

        }


        public void OnDataChange(int group, int[] clientId, object[] values)
        {
            if (group == 5)//1线完成信号
            {
                for (int i = 0; i < clientId.Length; i++)//"出口号：" + clientId[i] + ";任务号:" + taskno
                {
                    int tempvalue = int.Parse((values[i].ToString()));
                    if (tempvalue >= 1)//分拣完成
                    {
                        try
                        {
                            if (tempvalue != 0)
                            {
                                WriteLog.GetLog().Write(ListLineNum[0] + "线从电控读取出口号：" + clientId[i] + ";任务号:" + tempvalue);
                                //UnPokeService.UpdateunTask(tempvalue, 20);//根据异形烟整包任务号更新poke表中状态 
                                UnPokeClass.UpdateunTask(tempvalue, 20);
                                WriteLog.GetLog().Write(ListLineNum[0] + "线烟仓任务号" + tempvalue + "数据库更新完成");

                                GetTaskInfo(ListLineNum[0] + "线烟仓:" + tempvalue + "号任务已完成");
                            }
                        }
                        catch (Exception ex)
                        {
                            GetTaskInfo("服务器连接失败" + ex.Message.ToString());
                            return;
                        }
                    }
                    opcServer.FinishOnlyGroup.Write(0, clientId[i] - 1);
                }

            }
            else if (group == 9)//接收标志
            {
                for (int i = 0; i < clientId.Length; i++)
                {
                    if (clientId[i] == 1)//一线任务
                    {
                        try
                        {
                            if (values[i] != null && int.Parse(values[i].ToString()) == 0)
                            {
                                while (!opcServer.ConnectState)
                                {
                                    Thread.Sleep(100);
                                }

                                int receivePackage = int.Parse(opcServer.OnlyTaskGroup.ReadD(i).ToString());
                                if (receivePackage != 0)
                                {
                                    GetTaskInfo(ListLineNum[0] + "线烟仓任务包号:" + receivePackage + "已接收");
                                    UnPokeClass.UpdateTask(receivePackage, 15);
                                }
                                if (opcServer.IsSendOn)//如果任务已经在发送中则返回
                                {
                                    return;
                                }
                                StringBuilder outStr=new StringBuilder ();
                                object[] data = UnPokeClass.GetOneDateBaseTask(10, "1", out outStr);
                                DelSendTask task = new DelSendTask(opcServer.SendOnlyTask);
                                IAsyncResult result = task.BeginInvoke(data,outStr,null, task);
                                StringBuilder re = task.EndInvoke(result);
                                GetTaskInfo(re.ToString());
                            }
                            else
                            {
                                if (values[i] != null && int.Parse(values[i].ToString()) != 0)
                                {
                                    WriteLog.GetLog().Write(ListLineNum[0] + "线烟仓读到标志位:" + values[i]);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteLog.GetLog().Write(ListLineNum[1] + "线烟仓异常信息" + ex.Message);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 信息显示到界面 和记录到日记
        /// </summary>
        /// <param name="Info"></param>
        public static void GetTaskInfo(string Info)
        {

            // FmTaskDetail.GetTaskInfo_Detail(Info);
            WriteLog.GetLog().Write(Info);
            handle(Info);
        }

        private void timerSendTask_Tick(object sender, EventArgs e)
        {
            GetTaskInfo("触发定时器");
            if (opcServer.SpyBiaozhiGroup.Read(0).ToString() != "1" && !opcServer.IsSendOn)//监控标志位第一组 产生跳变
            {
                opcServer.SpyBiaozhiGroup.Write(2, 0);
                opcServer.SpyBiaozhiGroup.Write(0, 0);
                GetTaskInfo("发送任务");
            }
            else 
            {
                GetTaskInfo("强制跳变失败");
            }
            timerSendTask.Stop();
        }

        private void BtnEnd_Click(object sender, EventArgs e)
        {
            if (opcServer.ConnectState)
            {
                DialogResult result = MessageBox.Show("确定要停止发送任务?",//对话框的显示内容 
                                                        "操作提示",//对话框的标题 
                                                        MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                                                        MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                                                        MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        opcServer.FinishOnlyGroup.callback -= OnDataChange;
                        opcServer.SpyBiaozhiGroup.callback -= OnDataChange;
                        GetTaskInfo("异型烟倍速链，常规烟翻版移除事件成功！");
                        GetTaskInfo("任务停止发送与接收！");
                        UpdateControlEnable(false, BtnEnd);
                    }
                    catch (NullReferenceException nuller)
                    {
                        GetTaskInfo("OPC未能创建成功！" + nuller.Message);
                    }
                    catch (Exception ex)
                    {
                        GetTaskInfo("异型烟链板机任务停止失败！错误：" + ex.Message);
                    }
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            StatusManager frm = new StatusManager();
            frm.ShowDialog();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            Initdata();
        }

        public void Initdata()
        {
            WriteLog.GetLog().Write("initdata");
            task_data.Rows.Clear();
            try
            {
                List<TaskInfo> list = UnPokeClass.GetUNCustomer().ToList();
                if (list != null)
                {
                    DataGridViewCellStyle dgvStyle = new DataGridViewCellStyle();
                    dgvStyle.BackColor = Color.LightGreen;
                    int i = 1;
                    foreach (var row in list)
                    {
                        int index = this.task_data.Rows.Add();
                        this.task_data.Rows[index].Cells[0].Value = i++;//序号
                        this.task_data.Rows[index].Cells[1].Value = "长沙市烟草公司";//货主
                        this.task_data.Rows[index].Cells[2].Value = row.ORDERDATE.Value.Date.ToString("D"); //订单日期
                        this.task_data.Rows[index].Cells[3].Value = "批次" + row.SYNSEQ;//批次
                        this.task_data.Rows[index].Cells[4].Value = row.REGIONCODE;//线路编号
                        this.task_data.Rows[index].Cells[5].Value = row.REGIONCODE;//线路名称 
                        this.task_data.Rows[index].Cells[6].Value = row.FinishCount + "/" + row.Count;
                        this.task_data.Rows[index].Cells[7].Value = row.FinishQTY + "/" + row.QTY;
                        this.task_data.Rows[index].Cells[9].Value = row.Rate;

                        if (row.Rate == "100%")
                        {
                            this.task_data.Rows[index].Cells[9].Style = dgvStyle;
                        }

                    }
                    task_data.Sort(task_data.Columns[0], ListSortDirection.Ascending);
                }

            }
            finally
            {

            }
        }

        private void TimeToClike_Tick(object sender, EventArgs e)
        {
            Initdata();
            TimeToClike.Interval = 20000;//二十秒刷新
        }
    }
}
