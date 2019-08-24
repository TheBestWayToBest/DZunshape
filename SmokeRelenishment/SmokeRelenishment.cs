using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Tool;
using OPC;
using System.IO.Ports;
using Business.BusinessClass;
using Business;
using System.Threading;

namespace SmokeRelenishment
{
    public partial class SmokeRelenishment : Form
    {
        Label[] lbladded;
        Label[] lbladd;
        public SmokeRelenishment()
        {
            InitializeComponent();
            lbladded = new Label[10]
            {
                LblAdded1,LblAdded2,LblAdded3,LblAdded4,LblAdded5,LblAdded6,LblAdded7,LblAdded8,LblAdded9,LblAdded10
            };
            lbladd = new Label[10]
            {
                LblAdd1,LblAdd2,LblAdd3,LblAdd4,LblAdd5,LblAdd6,LblAdd7,LblAdd8,LblAdd9,LblAdd10
            };
            lblpack = new Label();
            lblpack.BackColor = Color.Transparent;
            lblpack.Font = new Font("宋体", 10, FontStyle.Bold | FontStyle.Italic);

            lblpack.Name = "lblpack";
            lblpack.Text = "件烟补货顺序";
            lblpack.Location = new Point(Convert.ToInt32(64), 7);
            lblpack.Size = new Size(300, 20);
            GetData(true);
            panel1.Controls.Add(lblpack);
            //ProgramAutoRun.SetMeStart(true);
            BGWConn.RunWorkerAsync();
            X = this.Width;//获取窗体的宽度
            Y = this.Height;//获取窗体的高度
            SetTag(this);//调用方法
        }

        #region
        private float X;//当前窗体的宽度

        private float Y;//当前窗体的高度

        /// <summary>
        /// 将控件的宽，高，左边距，顶边距和字体大小暂存到tag属性中
        /// </summary>
        /// <param name="cons">递归控件中的控件</param>
        private void SetTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    SetTag(con);
            }
        }
        //根据窗体大小调整控件大小

        private void SetControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                //获取控件的Tag属性值，并分割后存储字符串数组
                float a = System.Convert.ToSingle(mytag[0]) * newx;//根据窗体缩放比例确定控件的值，宽度
                con.Width = (int)a;//宽度
                a = System.Convert.ToSingle(mytag[1]) * newy;//高度
                con.Height = (int)(a);
                a = System.Convert.ToSingle(mytag[2]) * newx;//左边距离
                con.Left = (int)(a);
                a = System.Convert.ToSingle(mytag[3]) * newy;//上边缘距离
                con.Top = (int)(a);
                Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    SetControls(newx, newy, con);
                }
            }
        }

        private void SmokeRelenishment_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X; //窗体宽度缩放比例
            float newy = (this.Height) / Y;//窗体高度缩放比例
            SetControls(newx, newy, this);//随窗体改变控件大小
        }
        #endregion

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult MsgBoxResult = MessageBox.Show("确认退出系统?",//对话框的显示内容 
                             "操作提示",//对话框的标题 
                             MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                             MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                             MessageBoxDefaultButton.Button2);
            //继续尝试链接
            if (MsgBoxResult == DialogResult.Yes)
            {
                this.Dispose();
                this.Close();
                System.Environment.Exit(System.Environment.ExitCode);
            }
        }

        private void TRefresh_Tick(object sender, EventArgs e)
        {
            WriteLog.GetLog().Write("自动刷新");
            GetData(true);
        }
        void GetData(bool refresh = false)
        {
            WriteLog.GetLog().Write("读取数据");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("开始获取数据" + DateTime.Now.ToString());
            string strStart = System.DateTime.Now.ToString();

            List<T_PRODUCE_REPLENISHPLAN> lists = new List<T_PRODUCE_REPLENISHPLAN>();///RelenishimentClass.GetReplenishplan();
            foreach (var item in lbladded)
            {
                UpdateLabel(lists, 10, lbladd, Color.White);
            }
            foreach (var item in lbladd)
            {
                UpdateLabel(lists, 10, lbladd, Color.White);
            }
            try
            {
                List<T_PRODUCE_REPLENISHPLAN> list = RelenishimentClass.GetReplenishplan();
                int length;
                if (list.Count > lbladded.Length)
                    length = lbladded.Length;
                else
                    length = list.Count;
                UpdateLabel(list, length, lbladd, Color.White);

                List<T_PRODUCE_REPLENISHPLAN> finish = new List<T_PRODUCE_REPLENISHPLAN>();
                finish = RelenishimentClass.GetFinishedReplenishplan().OrderBy(item => item.ID).ToList();
                int lengths;
                if (finish.Count > lbladded.Length)
                    lengths = lbladded.Length;
                else
                    lengths = finish.Count;
                UpdateLabel(finish, lengths, lbladded, Color.LightGreen);
            }
            catch (Exception ex)
            {
                WriteLog.GetLog().Write("sp-03:数据获取失败！   ");
                if (ex.Message == "基础提供程序在 Open 上失败。")
                {
                    databaselinkcheck("数据库连接失败！请检查网络，重新打开程序！");
                }
            }
        }
        Label lblpack;
        //数据库连接失败，界面显示
        private delegate void HandleDelegate(string str);
        public void databaselinkcheck(string str)
        {
            if (lblpack.InvokeRequired)
            {
                lblpack.Invoke(new HandleDelegate(databaselinkcheck), str);
            }
            else
            {
                lblpack.Text = str;//;
                lblpack.Location = new Point(0, 10);
                lblpack.Width = 750;
                lblpack.BackColor = Color.Red;
                BtnSeq.Enabled = false;
                //BtnSearch.Enabled = false;
                BtnRefresh.Enabled = false;
                TRefresh.Stop();
            }
        }
        OPCServer opcServer;
        private void BGWConn_DoWork(object sender, DoWorkEventArgs e)
        {
            opcServer = new OPCServer();
            WriteLog.GetLog().Write("正在尝试连接服务器......");

            string[] str = opcServer.Connection();
            if (string.IsNullOrWhiteSpace(str[0]))
            {
                opcServer.OnlyTaskGroup.addItem(PlcItemCollection.GetRelenishplanItem());//任务交互区
                opcServer.SpyBiaozhiGroup.addItem(PlcItemCollection.GetReSpyOnlyLineItem());//监控任务标识位
                opcServer.FinishOnlyGroup.addItem(PlcItemCollection.GetReFinishTaskItem());//完成信号交互区;

                WriteLog.GetLog().Write("opC服务器创成功！");
                opcServer.ConnectState = opcServer.CheckConnection();
                if (opcServer.ConnectState)
                {
                    GetData(true);
                    opcServer.SpyBiaozhiGroup.callback = OnDataChange;
                    opcServer.FinishOnlyGroup.callback = OnDataChange;
                    opcServer.ScanGroup.callback = OnDataChange;
                    WriteLog.GetLog().Write("PLC连接成功!");
                    WriteLog.GetLog().Write("触发定时器");
                    if (opcServer.SpyBiaozhiGroup.Read(0).ToString() != "1" && !opcServer.IsSendOn)//监控标志位第一组 产生跳变
                    {
                        opcServer.SpyBiaozhiGroup.Write(2, 0);
                        opcServer.SpyBiaozhiGroup.Write(0, 0);
                        WriteLog.GetLog().Write("发送任务");
                    }
                    else
                    {
                        WriteLog.GetLog().Write("强制跳变失败");
                    }

                }
                else
                {
                    WriteLog.GetLog().Write("PLC连接失败!");
                    databaselinkcheck("plc连接失败");
                    TSender.Stop();
                    TRefresh.Stop();
                }
            }
            else
            {
                TSender.Stop();
                TRefresh.Stop();
                databaselinkcheck("plc连接失败");
                WriteLog.GetLog().Write(str[0]);
            }
        }

        private delegate void HandleDelegate1(string info, Label label, Color color);
        public void UpdateLabel(string info, Label label, Color color)
        {
            String time = DateTime.Now.ToLongTimeString();

            if (label.InvokeRequired)
            {
                label.Invoke(new HandleDelegate1(UpdateLabel), new Object[] { info, label, color });
            }
            else
            {

                label.BackColor = color;
                label.Text = info;
            }
        }

        private delegate void HandleDelegate2(string info, Label label);
        public void UpdateLabel(string info, Label label)
        {
            String time = DateTime.Now.ToLongTimeString();

            if (label.InvokeRequired)
            {
                label.Invoke(new HandleDelegate2(UpdateLabel), new Object[] { info, label });
            }
            else
            {
                if (label.Name.Contains("added"))
                    label.BackColor = Color.LightGreen;
                label.Text = info;
            }
        }

        delegate StringBuilder DelSendTask(object[] data, StringBuilder outStr);
        string sortnum = "0";
        public void OnDataChange(int group, int[] clientId, object[] values)
        {
            if (group == 5)//完成信号
            {
                for (int i = 0; i < clientId.Length; i++)
                {
                    string tempvalue = values[i].ToString();
                    if (decimal.Parse(tempvalue) >= 1)//分拣完成
                    {
                        try
                        {
                            if (decimal.Parse(tempvalue) != 0)
                            {
                                WriteLog.GetLog().Write("从电控读取补货任务号:" + tempvalue);
                                RelenishimentClass.Completed(tempvalue);
                                sortnum = tempvalue;
                                WriteLog.GetLog().Write("补货任务号" + tempvalue + "号任务已完成,数据库更新完成");
                                GetData();
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteLog.GetLog().Write("服务器连接失败" + ex.Message.ToString());
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
                                    WriteLog.GetLog().Write("补货任务号:" + receivePackage + "已接收");
                                    try
                                    {
                                        RelenishimentClass.UpdateReplanTask(receivePackage.ToString(), 15);
                                    }
                                    catch { }
                                }
                                if (opcServer.IsSendOn)//如果任务已经在发送中则返回
                                {
                                    return;
                                }
                                StringBuilder outStr = new StringBuilder();
                                object[] data = RelenishimentClass.GetSendTask(10, out outStr);
                                DelSendTask task = new DelSendTask(opcServer.SendOnlyTask);
                                IAsyncResult result = task.BeginInvoke(data, outStr, null, task);
                                StringBuilder re = task.EndInvoke(result);
                                //try
                                //{
                                //    RelenishimentClass.UpdateReplanTask(data[0].ToString(), 15);
                                //}
                                //catch { }
                                WriteLog.GetLog().Write(re.ToString());
                            }
                            else
                            {
                                if (values[i] != null && int.Parse(values[i].ToString()) != 0)
                                {
                                    WriteLog.GetLog().Write("补货读到标志位:" + values[i]);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteLog.GetLog().Write("补货异常信息" + ex.Message);
                        }
                    }
                }
            }
        }

        private void TSender_Tick(object sender, EventArgs e)
        {
        }

        void UpdateLabel(List<T_PRODUCE_REPLENISHPLAN> list, int length, Label[] labels, Color color)
        {
            if (list.Count > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    string info = i + 1 + "." + list[i].CIGARETTENAME + "  通道" + list[i].TROUGHNUM;
                    UpdateLabel(info, labels[i], color);
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    string info = "";
                    UpdateLabel(info, labels[i], color);
                }
            }

        }


        void UpdateLabel(List<T_PRODUCE_REPLENISHPLAN> list, int length, Label[] labels)
        {
            for (int i = 0; i < length; i++)
            {
                string info = i + 1 + "." + list[i].CIGARETTENAME + "  通道" + list[i].TROUGHNUM;
                UpdateLabel(info, labels[i]);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            WriteLog.GetLog().Write("手动刷新");
            GetData(true);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchCustomer sc = new SearchCustomer();
            sc.Show();
        }

        private void BtnSeq_Click(object sender, EventArgs e)
        {
            NowView nowview = new NowView(sortnum);
            nowview.Show();
        }
    }
}
