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

namespace SmokeRelenishment
{
    public partial class SmokeRelenishment : Form
    {
        public SmokeRelenishment()
        {
            InitializeComponent();
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
        }

        private void BGWConn_DoWork(object sender, DoWorkEventArgs e)
        {
            OPCServer opcServer = new OPCServer();
            WriteLog.GetLog().Write("正在尝试连接服务器......");
            opcServer.OnlyTaskGroup.addItem(PlcItemCollection.GetRelenishplanItem());
            opcServer.FinishOnlyGroup.addItem(PlcItemCollection.GetReFinishTaskItem());
            opcServer.SpyBiaozhiGroup.addItem(PlcItemCollection.GetReSpyOnlyLineItem());
            string[] str = opcServer.Connection();
            if (string.IsNullOrWhiteSpace(str[0]))
            {
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
    }
}
