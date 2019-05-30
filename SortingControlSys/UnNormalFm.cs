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

namespace SortingControlSys
{
    public partial class UnNormalFm : Form
    {
        private delegate void HandleDelegate(string strshow);
        private delegate void HandleDelegate2(Boolean visible, Control control);
        delegate StringBuilder DelSendTask();
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
            opcServer = new OPCServer();
            handle += UpdateListBox;
        }

        private void BtnStatrt_Click(object sender, EventArgs e)
        {

            DZEntities en = new DZEntities();
            var s = en.T_WMS_ITEM.Select(x => x).ToList();
            //en.T_PRODUCE_ORDER.Select(x => x);
            timerSendTask.Interval = 1000 * 10;
            timerSendTask.Start();
            GetTaskInfo("启动定时器");
            updateControlEnable(false, BtnStatrt);
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
        public void updateControlEnable(Boolean enable, Control control)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new HandleDelegate2(updateControlEnable), new Object[] { enable, control });
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
                }
            }
            else 
            {
                
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
                    //FinishOnlyGroup.Write(0, clientId[i] - 1);
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
                                    //UnPokeService.UpdateTask(receivePackage, 15);
                                }
                                if (opcServer.IsSendOn)//如果任务已经在发送中则返回
                                {
                                    return;
                                }
                           
                                DelSendTask task = new DelSendTask(opcServer.SendOnlyTask);
                                IAsyncResult result = task.BeginInvoke(null, task);
                                StringBuilder re = task.EndInvoke(result);
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
            }
            timerSendTask.Stop();
        }

        private void BtnEnd_Click(object sender, EventArgs e)
        {

        }
    }
}
