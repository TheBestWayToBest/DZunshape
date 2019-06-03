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

    }
}
