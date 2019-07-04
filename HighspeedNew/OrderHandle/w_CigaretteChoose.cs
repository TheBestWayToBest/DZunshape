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

namespace HighspeedNew.OrderHandle
{
    public partial class w_CigaretteChoose : Form
    {
        string cigarettecode = "", cigarettename = "";
        public List<string> infolst = new List<string>();
        public w_CigaretteChoose(List<string> lst)
        {
            InitializeComponent();
            infolst = lst;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            List<ItemInfo> list = new List<ItemInfo>();
            list = ItemClass.GetCig(box_type.SelectedIndex, txt_keywd.Text);
            itemdata.DataSource = list;
            this.itemdata.AutoGenerateColumns = false;
            itemdata.ClearSelection();
        }

        public List<string> returnObj
        {
            get { return this.infolst; }
        }
        private void itemdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (this.itemdata.CurrentRow != null && this.itemdata.CurrentRow.Index != -1)
                {
                    cigarettecode = this.itemdata.CurrentRow.Cells[1].Value + "";
                    cigarettename = this.itemdata.CurrentRow.Cells[2].Value + "";

                    //MessageBox.Show("===" + troughdata.RowCount);
                    if (cigarettecode != "")
                    {
                        this.btn_submit.Enabled = true;
                        this.txt_itemno.Text = cigarettecode;
                        this.txt_itemname.Text = cigarettename;
                    }
                    else
                    {
                        this.btn_submit.Enabled = false;
                        this.txt_itemno.Text = "";
                        this.txt_itemname.Text = "";
                    }
                }
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (cigarettecode != null && cigarettecode.Trim() != "")
            {
                infolst.Add(cigarettecode);
                infolst.Add(cigarettename);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请先点击选择您要的卷烟品牌，再进行提交！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
