using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Modle;
using Business.BusinessClass;


namespace HighSpeed.OrderHandle
{
    public partial class w_CigaretteInfo : Form
    {
        List<ItemInfo> itemInfos = new List<ItemInfo>();
        public w_CigaretteInfo()
        {
            InitializeComponent();
            box_type.SelectedIndex = 0;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            itemInfos = ItemClass.GetItemInfo(box_type.SelectedIndex, txt_keywd.Text.Trim());
            DgvItemInfo.DataSource = itemInfos;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {

        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {

        }

        private void DgvItemInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvItemInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (itemInfos[e.ColumnIndex].Shiptype=="0")
                {

                    e.Value = "正常烟";
                }
                else
                {
                    e.Value = "异型烟";
                }
            }
            if (e.ColumnIndex == 4)
            {
                if (itemInfos[e.ColumnIndex].RowStatus == 10)
                {

                    e.Value = "正常";
                }
                else
                {
                    e.Value = "删除";
                }
            }
        }
    }
}
