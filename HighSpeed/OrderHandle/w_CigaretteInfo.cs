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
    }
}
