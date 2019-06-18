using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.BusinessClass;
using Business.Modle;
using Tool;

namespace SortingControlSys
{
    public partial class StatusManager : Form
    {
        public StatusManager()
        {
            InitializeComponent();
            CmbState.SelectedIndex = 0;
            X = this.Width;//获取窗体的宽度
            Y = this.Height;//获取窗体的高度
            SetTag(this);//调用方法
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                Bind();
            }
            catch
            {
                WriteLog.GetLog().Write("状态修改异常");
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

        private void StatusManager_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X; //窗体宽度缩放比例
            float newy = (this.Height) / Y;//窗体高度缩放比例
            SetControls(newx, newy, this);//随窗体改变控件大小
        }
        #endregion

        void Bind() 
        {
            int sortNum = 0;
            bool a = int.TryParse(TxtSortNum.Text, out sortNum);
            List<TaskDetail> list = UnPokeClass.GetDataAll(1, sortNum, TxtRegionCode.Text, TxtCusID.Text);
            foreach (var item in list)
            {
                DataGridViewCellStyle dgvStyle = new DataGridViewCellStyle();
                dgvStyle.BackColor = Color.LightGreen;
                // 存了状态值  
                string status = "";
                int index = this.DgvData.Rows.Add();
                this.DgvData.Rows[index].Cells[0].Value = item.SortSeq;//户序
                this.DgvData.Rows[index].Cells[1].Value = item.SortNum; //分拣任务号

                this.DgvData.Rows[index].Cells[2].Value = item.RegionCode;//车组号
                this.DgvData.Rows[index].Cells[3].Value = item.CusName;//客户名称
                this.DgvData.Rows[index].Cells[4].Value = item.CigCode;//香烟编号
                this.DgvData.Rows[index].Cells[5].Value = item.CigName;//香烟名称
                //this.DgvData.Rows[index].Cells[8].Value = item.POKENUM;//抓烟数量
                this.DgvData.Rows[index].Cells[6].Value = item.Status;//状态位
                this.DgvData.Rows[index].Cells[7].Value = item.ThroughNum;//物理通道号
                this.DgvData.Rows[index].Cells[8].Value = item.BillCode;//订单号

                if (item.Status == 10)
                {
                    status = "新增";
                }
                else if (item.Status == 12)
                {
                    status = "已计算";
                }
                else if (item.Status == 15)
                {
                    status = "已发送";
                }
                else
                {
                    status = "完成";
                }
                this.DgvData.Rows[index].Cells[9].Value = status;//状态位

                if (status == "完成")
                {
                    this.DgvData.Rows[index].Cells[9].Style = dgvStyle;

                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult MsgBoxResult = MessageBox.Show("确定要更新任务?",//对话框的显示内容 
                                                                "操作提示",//对话框的标题 
                                                                MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                                                                MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                                                                MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
            if (MsgBoxResult == DialogResult.Yes)
            {
                string txtStart = TxtStartNum.Text;
                string txtEnd = TxtEndNum.Text;
                int status = 10;
                if (string.IsNullOrWhiteSpace(TxtEndNum.Text))//如果只输入第一个任号务 则其修改
                {
                    txtEnd = txtStart;

                }
                else if (string.IsNullOrWhiteSpace(TxtStartNum.Text))//如果只输入第一个任号务 则其修改
                {
                    txtStart = txtEnd;
                }
                else if (Convert.ToDecimal(TxtStartNum.Text) > Convert.ToDecimal(TxtEndNum.Text)) //防止任务号输反
                {
                    string tmp = txtStart;
                    txtStart = txtEnd;
                    txtEnd = tmp;
                }
                switch (CmbState.SelectedIndex)
                {
                    case 1:
                        status = 10;//新增
                        break;
                    case 2:
                        status = 15;//已发送
                        break;
                    case 3:
                        status = 20;//已完成
                        break;
                }
                decimal start = 0;
                decimal end = 0;
                if (decimal.TryParse(txtStart, out start) && decimal.TryParse(txtEnd, out end))
                {
                    UnPokeClass.UpdateTask(start, end, status);
                    WriteLog.GetLog().Write("任务号从：" + txtStart + "任务号到：" + txtEnd + "，修改状态为：" + status + "，修改包装机为" + "，任务更新完成!");
                    Bind();
                }
                else
                {
                    MessageBox.Show("输入错误!!!");
                }

            }
        }

    }
}
