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




namespace MixedThrough
{
    public partial class MixedThrough : Form
    {
        Label lblpack;
        Label[] lbladded;
        Label[] lbladd;
        decimal machineSeq;
        decimal groupNo;
        public MixedThrough()
        {
            InitializeComponent();
            lbladded = new Label[15]
            {
                LblAdded1,LblAdded2,LblAdded3,LblAdded4,LblAdded5,LblAdded6,LblAdded7,LblAdded8,LblAdded9,LblAdded10,LblAdded11,LblAdded12,LblAdded13,LblAdded14,LblAdded15
            };
            lbladd = new Label[15]
            {
                LblAdd1,LblAdd2,LblAdd3,LblAdd4,LblAdd5,LblAdd6,LblAdd7,LblAdd8,LblAdd9,LblAdd10,LblAdd11,LblAdd12,LblAdd13,LblAdd14,LblAdd15
            };
            sp_name = "COM1";
            OpenSerialPort();
            machineSeq = 90;
            groupNo = 2;
            lblpack = new Label();
            lblpack.BackColor = Color.Transparent;
            lblpack.Font = new Font("宋体", 10, FontStyle.Bold | FontStyle.Italic);
            CheckForIllegalCrossThreadCalls = false;
            lblpack.Name = "lblpack";
            lblpack.Text = "混合道补货顺序";
            lblpack.Location = new Point(Convert.ToInt32(64), 7);
            lblpack.Size = new Size(300, 20);

            panel1.Controls.Add(lblpack);

            TSender.Start();
            BGWConn.RunWorkerAsync();
            GetData();
            ProgramAutoRun.SetMeStart(true);
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

        private void MixedThrough_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X; //窗体宽度缩放比例
            float newy = (this.Height) / Y;//窗体高度缩放比例
            SetControls(newx, newy, this);//随窗体改变控件大小
        }
        #endregion

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
            str += tempCode;
            if (str.Length > 12)
            {
                PullCigarette(str.Trim());
            }

        }
        void PullCigarette(string stri)
        {
            MixInfo info = MixedClass.GetMixCig(machineSeq, groupNo, 0)[0];
            WriteLog.GetLog().Write("扫到条码" + stri);
            if (info.CigCode.Trim() == stri.Trim()/* && info.CigName == strs[1].Trim()*/)
            {
                if (MixedClass.UpdatePullStatus2Put(machineSeq, info.SortNum, info.CigCode))
                {
                    WriteLog.GetLog().Write("<扫码放烟成功>");
                    BtnRemove.Enabled = false;
                    BtnRemove.Visible = false;
                    GetData();
                    str = "";
                }

            }
            else
            {
                WriteLog.GetLog().Write("放烟品牌错误：扫描到条码" + stri);
                MessageBox.Show("放烟错误，请重放");
                str = "";
            }
        }
        void PullCigarette()
        {
            StringBuilder sb = new StringBuilder();
            MixInfo info = MixedClass.GetMixCig(machineSeq, groupNo, 0)[0];
            if (MixedClass.UpdatePullStatus2Put3(info.CigCode, machineSeq, info.SortNum))
            {
                WriteLog.GetLog().Write("<点击放烟成功>");
                BtnRemove.Enabled = false;
                BtnRemove.Visible = false;
                GetData();
            }

        }
        void GetData()
        {
            WriteLog.GetLog().Write("读取数据");
            StringBuilder sb = new StringBuilder();
            WriteLog.GetLog().Write("开始获取数据" + DateTime.Now.ToString());
            string strStart = System.DateTime.Now.ToString();
            List<MixInfo> list = new List<MixInfo>();
            foreach (var item in lbladded)
            {
                item.Text = "";
                item.BackColor = Color.White;
            }
            foreach (var item in lbladd)
            {
                item.Text = "";
            }
            try
            {
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

                    finish = MixedClass.GetMixCig3(machineSeq, groupNo, 1).Take(15).OrderBy(item => item.SortNum).ToList();
                    int lengths;
                    if (finish.Count > lbladded.Length)
                        lengths = lbladded.Length;
                    else
                        lengths = finish.Count;
                    UpdateLabel(finish, lengths, lbladded);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                WriteLog.GetLog().Write("sp-03:数据获取失败！   ");
                databaselinkcheck("数据库连接失败！请检查网络，重新打开程序！");
            }
        }

        void UpdateLabel(List<MixInfo> list, int length, Label[] labels)
        {
            for (int i = 0; i < length; i++)
            {
                string info = i + 1 + "." + list[i].CigName + "  " + list[i].PokeNum;
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {

        }

        private void BtnSeq_Click(object sender, EventArgs e)
        {

        }


        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void LblAdd1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (LblAdd1.Text != "")
                {
                    BtnRemove.Enabled = true;
                    BtnRemove.Visible = true;
                }

            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            PullCigarette();
            BtnRemove.Enabled = false;
            BtnRemove.Visible = false;
        }



    }
}
