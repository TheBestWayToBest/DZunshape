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
            OpenSerialPort();
            BGWConn.RunWorkerAsync();
            X = this.Width;//获取窗体的宽度
            Y = this.Height;//获取窗体的高度
            SetTag(this);//调用方法
        }
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
                //System.Environment.Exit(0); 
                this.Dispose();
                this.Close();
                System.Environment.Exit(System.Environment.ExitCode);
            }
        }

        private void TRefresh_Tick(object sender, EventArgs e)
        {

        }

        void GetData(bool refresh = false) 
        {
            WriteLog.GetLog().Write("读取数据");
            StringBuilder sb = new StringBuilder();
            sb.Append("开始获取数据" + DateTime.Now.ToString());
            string strStart = System.DateTime.Now.ToString();
            //List<T_PRODUCE_REPLENISHPLAN> list = RelenishimentClass.GetReplenishplan();
            
        }

        private void BGWConn_DoWork(object sender, DoWorkEventArgs e)
        {
            GetData(true);
            OPCServer opcServer = new OPCServer();
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
                    
                    WriteLog.GetLog().Write("PLC连接成功!");
                }
                else
                {
                    WriteLog.GetLog().Write("PLC连接失败!");
                }
            }
            else
            {
                WriteLog.GetLog().Write(str[0]);
            }
        }
        SerialPort sp = new SerialPort();
        string sp_name;
        public void OpenSerialPort()
        {
            sp_name = "COM3";
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
            //int length = 0;
            //TextboxFZ3(1, str);
            //List<T_PRODUCE_REPLENISHPLAN> list = new List<T_PRODUCE_REPLENISHPLAN>();
            //list = RelenishimentClass.GetFinishedReplenishplan(str);
            //LbaAddedData(list);
            for (int i = 0; i < lbladded.Length-5; i++)
            {
                UpdateLabel(i.ToString(), lbladded[i]);
                lbladded[i].BackColor = Color.LightGreen;
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
                    label.Text = info;

                }
            
            
        }

        void LbaAddedData(List<T_PRODUCE_REPLENISHPLAN> list) 
        {
            for (int i = 0; i < lbladded.Length; i++)
            {
                lbladded[i].Text = (i + 1) + "." + list[i].CIGARETTENAME;
            }
        }


    }
}
