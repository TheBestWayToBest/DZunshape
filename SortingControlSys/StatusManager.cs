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
            CmbState.SelectedIndex = 1;
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
