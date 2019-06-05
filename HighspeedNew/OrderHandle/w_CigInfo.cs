using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.BusinessClass;
namespace HighSpeed.OrderHandle
{
    public partial class w_CigInfo : Form
    {
        public w_CigInfo()
        {
            InitializeComponent();
            Bind();
        }
        ChannelClass cc = new ChannelClass();
        void Bind()
        {
          itemdata.DataSource =  cc.GetCigInfo().Content;
            box_type.Items.Add("卷烟名称");
            box_type.Items.Add("卷烟编码");
            box_type.SelectedIndex = 0;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_keywd.Text))
            {
                Bind();
                return;

            }
            else
            {
               int index = box_type.SelectedIndex +1;
               var a = cc.GetCigInfo(txt_keywd.Text, index);
               if (a.IsSuccess)
               {
                   itemdata.DataSource = a.Content;
               }
               else
               {

                   MessageBox.Show(a.MessageText);
               }

            }
        }
        public string CigCode { get { return cigarettecode; } }
        public string CigName { get { return cigarettename; } }
        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cigarettecode) && !string.IsNullOrWhiteSpace(cigarettename))
            { 
                DialogResult = DialogResult.OK;
                Close(); 
            }
            else
            {
                MessageBox.Show("请选择品牌");
            }
        }
        string cigarettecode = "", cigarettename = "";
        private void itemdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                if (this.itemdata.CurrentRow != null && this.itemdata.CurrentRow.Index != -1)
                {
                    cigarettecode = this.itemdata.CurrentRow.Cells[1].Value + "";
                    cigarettename = this.itemdata.CurrentRow.Cells[0].Value + "";

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
    }
}
