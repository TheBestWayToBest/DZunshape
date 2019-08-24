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
using System.Configuration;

namespace SpecialShapeSmoke
{
    public partial class MainScreen : Form
    {
        Label lblpack;
        Label[] lbladded;
        Label[] lbladd;
        decimal machineSeq;
        decimal groupNo;
        decimal sortnum = 0;
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
            try { sp_name = ConfigurationManager.AppSettings["SerialPort"].ToString(); }
            catch { sp_name = "COM2"; }
            CheckForIllegalCrossThreadCalls = false;
            machineSeq = 1;
            groupNo = 1;
            lblpack = new Label();
            lblpack.BackColor = Color.Transparent;
            lblpack.Font = new Font("宋体", 10, FontStyle.Bold | FontStyle.Italic);

            lblpack.Name = "lblpack";
            lblpack.Text = "特异型烟道补货顺序";
            lblpack.Location = new Point(Convert.ToInt32(64), 7);
            lblpack.Size = new Size(300, 20);

            panel1.Controls.Add(lblpack);
            OpenSerialPort();
            TSender.Start();
            BGWConn.RunWorkerAsync();
            //ProgramAutoRun.SetMeStart(true);
            try { sortnum = RelenishimentClass.GetMinSortNum(); }
            catch { }
            lblSortnum.Text = "当前任务：" + sortnum;
            GetData();

            X = this.Width;//获取窗体的宽度
            Y = this.Height;//获取窗体的高度
            SetTag(this);//调用方法
        }

        void ReadFinish()
        {
            List<string> list = new List<string>();
            list = PlcItemCollection.GetFinishUnnormalItem();
            for (int i = 0; i < list.Count; i++)
            {
                int receivePackage = int.Parse(opcServer.FinishOnlyGroup.ReadD(i).ToString());
                if (receivePackage != 0)
                {
                    WriteLog.GetLog().Write("从电控读取特异型烟任务号:" + receivePackage);
                    UnPokeClass.UpdateunTask1(receivePackage, 20);
                    try { sortnum = RelenishimentClass.GetMinSortNum(); }
                    catch { }
                    lblSortnum.Text = "当前任务：" + sortnum;
                    opcServer.FinishOnlyGroup.Write(0, i);
                }
            }
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
        static string str = "";
        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = sender as SerialPort;
            String tempCode = sp.ReadExisting();
            //str = tempCode.Split('\r').First();
            str += tempCode;
            if (str.Length > 12)
            {
                PullCigarette(str);
            }

        }
        void PullCigarette(string stri)
        {
            MixInfos info = MixedClass.GetMixCig2(machineSeq, groupNo, 0)[0];
            WriteLog.GetLog().Write("扫到条码" + stri);
            if (info.CigCode.Trim() == stri.Trim())
            {
                if (MixedClass.UpdatePullStatus2Put2(machineSeq, info.PokeID))
                {
                    WriteLog.GetLog().Write("<扫码放烟成功>");
                    GetData();
                    str = "";
                }

            }
            else
            {
                WriteLog.GetLog().Write("放烟品牌错误：扫描到条码" + str[0]);
                MessageBox.Show("放烟错误，请重放");
                str = "";
            }
        }

        void GetData()
        {
            List<MixInfos> list = new List<MixInfos>();
            foreach (var item in lbladded)
            {
                UpdateLabel3(list, 15, lbladd, Color.White);
                //item.Text = "";
            }
            foreach (var item in lbladd)
            {
                UpdateLabel3(list, 15, lbladd, Color.White);
                //item.Text = "";
                //item.BackColor = Color.White;
            }
            try
            {
                list = MixedClass.GetMixCig2(machineSeq, groupNo, 0);
                int length;
                if (list.Count > lbladded.Length)
                    length = lbladded.Length;
                else
                    length = list.Count;
                UpdateLabel3(list, length, lbladd, Color.White);
                try
                {
                    List<MixInfos> finish = new List<MixInfos>();
                    //UpdateLabel(finish, 15, lbladded);
                    finish = MixedClass.GetMixCig4(machineSeq, groupNo, 1).OrderBy(item => item.ThroughNum).OrderBy(item => item.SortNum).ToList();
                    int lengths;
                    if (finish.Count > lbladded.Length)
                        lengths = lbladded.Length;
                    else
                        lengths = finish.Count;
                    UpdateLabel3(finish, lengths, lbladded, Color.LightGreen);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
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

        void UpdateLabel3(List<MixInfos> lists, int length, Label[] labels, Color color)
        {
            for (int i = 0; i < length; i++)
            {
                try
                {
                    string info = i + 1 + "." + lists[i].CigName + " " + lists[i].SortNum;
                    UpdateLabel(info, labels[i], color);
                }
                catch
                {
                    UpdateLabel("", labels[i], color);
                }
            }
        }

        void UpdateLabel(List<MixInfo> list, int length, Label[] labels, Color color)
        {
            for (int i = 0; i < length; i++)
            {
                try
                {
                    string info = i + 1 + "." + list[i].CigName + " " + list[i].SortNum;
                    UpdateLabel(info, labels[i], color);
                }
                catch
                {
                    UpdateLabel("", labels[i], color);
                }
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

        private delegate void HandleDelegate2(string info, Label label, Color color);
        public void UpdateLabel(string info, Label label, Color color)
        {
            String time = DateTime.Now.ToLongTimeString();

            if (label.InvokeRequired)
            {
                label.Invoke(new HandleDelegate2(UpdateLabel), new Object[] { info, label, color });
            }
            else
            {

                label.BackColor = color;
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
                //BtnSearch.Enabled = false;
                BtnRefresh.Enabled = false;
                TRefresh.Stop();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {

            SearchCustomer frm = new SearchCustomer();
            frm.Show();
            frm.Activate();
            SearchWinForm(frm);
        }

        public void SearchWinForm(Form fname)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is Form)
                {
                    fname.TopMost = true;
                    fname.Activate();

                    return;
                }
            }
            fname.Show();
            fname.Activate();
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
                        opcServer.IsSendOn = true;
                        opcServer.SpyBiaozhiGroup.Write(2, 0);
                        opcServer.SpyBiaozhiGroup.Write(0, 0);
                        ReadFinish();
                        opcServer.IsSendOn = false;
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
        //string sortNum = "0";
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
                                WriteLog.GetLog().Write("从电控读取特异型烟任务号:" + tempvalue);
                                //UnPokeClass.UpdateunTask(tempvalue, 20);
                                //sortNum = tempvalue;
                                UnPokeClass.UpdateunTask1(decimal.Parse(tempvalue), 20);
                                try { sortnum = RelenishimentClass.GetMinSortNum(); }
                                catch { }
                                lblSortnum.Text = "当前任务：" + sortnum;
                                //SpecialClass.UpdateSpecialState(decimal.Parse(tempvalue),2);
                                WriteLog.GetLog().Write("特异型烟任务号" + tempvalue + "号任务已完成,数据库更新完成");
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
                                    WriteLog.GetLog().Write("特异型烟任务号:" + receivePackage + "已接收");
                                    UnPokeClass.UpdateTask(receivePackage, 15);
                                    //UnPokeClass.UpdateHunhe(receivePackage);
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
                                if (re.ToString() == "特异型烟道暂无任务")
                                {
                                    databaselinkcheck("特异型烟道暂无任务");
                                    return;
                                }
                                WriteLog.GetLog().Write(re.ToString());
                                GetData();
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

        private void BtnSeq_Click(object sender, EventArgs e)
        {
            try
            {
                NowView frm = new NowView(Convert.ToDecimal(sortnum));
                frm.Show();
                frm.Activate();
                SearchWinForm(frm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败！请检查网络");
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

    }
}
