using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Business.BusinessClass;
using Business.Modle;
using Tool;
using Business;
using OPC;
using System.Threading;

namespace SpecialShapeSmoke
{
    public partial class MainScreen : Form
    {
        Label lblpack;
        Label[] lbladded;
        Label[] lbladd;
        decimal machineSeq;
        decimal groupNo;
        public MainScreen()
        {
            InitializeComponent();
            //OpenSerialPort();
            lbladded = new Label[15]
            {
                LblAdded1,LblAdded2,LblAdded3,LblAdded4,LblAdded5,LblAdded6,LblAdded7,LblAdded8,LblAdded9,LblAdded10,LblAdded11,LblAdded12,LblAdded13,LblAdded14,LblAdded15
            };
            lbladd = new Label[15]
            {
                LblAdd1,LblAdd2,LblAdd3,LblAdd4,LblAdd5,LblAdd6,LblAdd7,LblAdd8,LblAdd9,LblAdd10,LblAdd11,LblAdd12,LblAdd13,LblAdd14,LblAdd15
            };
            sp_name = "COM1";
            machineSeq = 1;
            groupNo = 1;
            lblpack = new Label();
            lblpack.BackColor = Color.Transparent;
            lblpack.Font = new Font("宋体", 10, FontStyle.Bold | FontStyle.Italic);

            lblpack.Name = "lblpack";
            lblpack.Text = "混合道补货顺序";
            lblpack.Location = new Point(Convert.ToInt32(64), 7);
            lblpack.Size = new Size(300, 20);

            panel1.Controls.Add(lblpack);
            OpenSerialPort();
            TSender.Start();
            BGWConn.RunWorkerAsync();
            GetData();
            List<MixInfo> list = new List<MixInfo>();
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

        private void MainScreen_Resize(object sender, EventArgs e)
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

        
        SerialPort sp = new SerialPort();    
        string sp_name;
        public void OpenSerialPort()
        {

            sp.PortName = sp_name;
            if (!sp.IsOpen)
            {
                try
                {
                    sp.ReadBufferSize = 32;
                    sp.BaudRate = 9600;
                    sp.Open();
                    sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                }
                catch
                {
                   
                }
            }

        }
        //处理扫描文本
        static string str;
        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = sender as SerialPort;
            String tempCode = sp.ReadExisting();
            str = tempCode.Split('\r').First();
            
        }
        void PullCigarette(string str)
        {
            string[] strs = new string[2];
            try
            {
                strs = MixedClass.GetCigInfoByCode(str);
            }
            catch
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            MixInfo info = MixedClass.GetMixCig(machineSeq, groupNo, 0)[0];
            sb.AppendLine("扫到条码" + str[0]);
            if (info.CigCode == strs[0] && info.CigName == strs[1])
            {
                if (MixedClass.UpdatePullStatus2Put(machineSeq, info.PokeID))
                {
                    sb.AppendLine("<扫码放烟成功>");
                    GetData();
                }

            }
            else 
            {
                sb.AppendLine("放烟品牌错误：扫描到条码" + str[0]);
                MessageBox.Show("放烟错误，请重放");
            }
        }

        void GetData() 
        {
            WriteLog.GetLog().Write("读取数据");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("开始获取数据" + DateTime.Now.ToString());
            string strStart = System.DateTime.Now.ToString();
            List<MixInfo> list = new List<MixInfo>();
            foreach (var item in lbladded)
            {
                item.Text = "";
            }
            foreach (var item in lbladd)
            {
                item.Text = "";
            }
            try
            {
                
                //UpdateLabel(list, 15, lbladd);
                list = MixedClass.GetMixCig(machineSeq, groupNo, 0);
                int length;
                if (list.Count > lbladded.Length)
                    length = lbladded.Length;
                else
                    length = list.Count;
                UpdateLabel(list, length, lbladd);
                try
                {
                    List<MixInfo> finish = new List<MixInfo>();
                    //UpdateLabel(finish, 15, lbladded);
                    finish = MixedClass.GetMixCig(machineSeq, groupNo, 1);
                    int lengths;
                    if (finish.Count > lbladded.Length)
                        lengths = lbladded.Length;
                    else
                        lengths = finish.Count;
                    UpdateLabel(finish, lengths, lbladded);
                }
                catch (Exception ex)
                {
                    
                }
            }
            catch (Exception ex)
            {
                WriteLog.GetLog().Write("sp-03:数据获取失败！   ");
                //if (ex.Message == "基础提供程序在 Open 上失败。")
                //{
                    databaselinkcheck("数据库连接失败！请检查网络，重新打开程序！");
                //}
            }
        }

        void UpdateLabel(List<MixInfo> list, int length, Label[] labels)
        {
            for (int i = 0; i < length; i++)
            {
                string info = i + 1 + "." + list[i].CigName;
                UpdateLabel(info, labels[i]);
            }
        }
        private delegate void HandleDelegate1(string info, Label label);
        public void UpdateLabel(string info, Label label)
        {
            String time = DateTime.Now.ToLongTimeString();

            if (label.InvokeRequired)
            {
                label.Invoke(new HandleDelegate1(UpdateLabel), new Object[] { info, label });
            }
            else
            {
                if (label.Name.Contains("Added"))
                    label.BackColor = Color.LightGreen;
                label.Text = info;
            }
        }

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
                BtnSearch.Enabled = false;
                BtnRefresh.Enabled = false;
                TRefresh.Stop();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PullCigarette("39537");
        }

        OPCServer opcServer;
        private void BGWConn_DoWork(object sender, DoWorkEventArgs e)
        {
            //GetData(true);
            opcServer = new OPCServer();
            WriteLog.GetLog().Write("正在尝试连接服务器......");

            string[] str = opcServer.Connection();
            if (string.IsNullOrWhiteSpace(str[0]))
            {
                opcServer.OnlyTaskGroup.addItem(PlcItemCollection.GetOnlyUnnormalItem());//任务交互区
                opcServer.SpyBiaozhiGroup.addItem(PlcItemCollection.GetSpanUnnormalItem());//监控任务标识位
                opcServer.FinishOnlyGroup.addItem(PlcItemCollection.GetFinishUnnormalItem());//完成信号交互区;

                //opcServer.ScanGroup.addItem(PlcItemCollection.GetScan());

                WriteLog.GetLog().Write("opC服务器创成功！");
                opcServer.ConnectState = opcServer.CheckConnection();
                if (opcServer.ConnectState)
                {
                    GetData();
                    opcServer.SpyBiaozhiGroup.callback = OnDataChange;
                    opcServer.FinishOnlyGroup.callback = OnDataChange;
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

        delegate StringBuilder DelSendTask(object[] data, StringBuilder outStr);

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
                                //UnPokeClass.UpdateunTask(tempvalue, 20);
                                RelenishimentClass.Completed(tempvalue);
                                WriteLog.GetLog().Write("补货任务号" + tempvalue + "号任务已完成,数据库更新完成");
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
                                    RelenishimentClass.UpdateMixTask(receivePackage, 15);
                                }
                                if (opcServer.IsSendOn)//如果任务已经在发送中则返回
                                {
                                    return;
                                }
                                StringBuilder outStr = new StringBuilder();
                                object[] data = RelenishimentClass.GetSendTasks(10, out outStr);
                                DelSendTask task = new DelSendTask(opcServer.SendOnlyTask);
                                IAsyncResult result = task.BeginInvoke(data, outStr, null, task);
                                StringBuilder re = task.EndInvoke(result);
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
    
    }
}
