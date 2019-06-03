using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.BusinessClass;
using Business;
 

namespace HighSpeed.OrderHandle
{
    public partial class win_trough : Form
    {
 
        public win_trough()
        {
            InitializeComponent();
            Bind();
        }
        ChannelClass cc = new ChannelClass();

        void Bind()
        {
            var a = cc.GetSortTroughInfo();
            if (a.IsSuccess)
            { 
                dgvdate.DataSource = a.Content;
            }
            else
            {
                MessageBox.Show(a.MessageText);
            }
           box_condition.Items.Add("卷烟名称");
           box_condition.Items.Add("卷烟编码");
           box_condition.SelectedIndex = 0;
        }
        void pager1_PageChanged(object sender, EventArgs e)
        {
       
        }

        void pager1_ExportCurrent(object sender, EventArgs e)
        {
        }

        void pager1_ExportAll(object sender, EventArgs e)
        {
        }    
 
         

 
 
            
            
            
   

        private void btn_search_Click(object sender, EventArgs e)
        {
            if( string.IsNullOrWhiteSpace(txt_keywd.Text))
            {
                Bind();
                return;

            }
            object con = txt_keywd.Text;
            int index = box_condition.SelectedIndex + 2;
            dgvdate.DataSource = cc.GetSortTroughInfo(con, index).Content;
        }

      

        private void troughdata_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

  
                
 
 
 

        private void box_condition_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txt_keywd.Focus();
        }

        private void txt_keywd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
            }
        }

        private void btn_amend_Click(object sender, EventArgs e)
        {
            if (MachineSeq !=  -1 )
            {
                w_EDITthough we = new w_EDITthough("修改一个通道", 1, MachineSeq);
                we.StartPosition = FormStartPosition.CenterScreen;
                we.ShowDialog();
                Bind();
            }

            
          
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            w_EDITthough we = new w_EDITthough("增加一个通道", 0);
            we.StartPosition = FormStartPosition.CenterScreen;
            we.ShowDialog();
            Bind();
        }
        
        decimal MachineSeq = -1;
        private void dgvdate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (this.dgvdate.CurrentRow != null && this.dgvdate.CurrentRow.Index != -1)
                {
                    MachineSeq = Convert.ToDecimal(this.dgvdate.CurrentRow.Cells[5].Value) ;
                }
            }
        }

        private void btn_qy_Click(object sender, EventArgs e)
        {
            if (MachineSeq !=  -1 )
            {
                var res = cc.GetSingleTrough(MachineSeq);
                if (res.IsSuccess)
                {
                    res.Content.STATE = "10"; 
                    cc.ChangeOneTrough(res.Content);
                    Bind();
                }
                else
                {
                    MessageBox.Show(res.MessageText);
                }
                 
              
            }
        }

        private void btn_jy_Click(object sender, EventArgs e)
        {
            if (MachineSeq !=  -1 )
            {
                var res = cc.GetSingleTrough(MachineSeq);
                if (res.IsSuccess)
                {
                    res.Content.STATE = "0"; 
                    cc.ChangeOneTrough(res.Content);
                    Bind();
                }
                else
                {
                    MessageBox.Show(res.MessageText);
                }
            }
        }

 
 
 

    }
}
