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
    public partial class w_EDITthough : Form
    {
        public w_EDITthough()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">界面显示</param>
        /// <param name="type">操作类型 0 是新增， 1 是修改</param>
        public w_EDITthough(string text,int type,decimal machineseq =0)
        {
            InitializeComponent();
            Text = text;
            Type = type; 
            Machineseq = machineseq;
            if (type == 1)
            {
                var res = cc.GetSingleTrough(machineseq);
                txt_iteminfo.Text = res.Content.CIGARETTENAME + " " + res.Content.CIGARETTECODE;
                cbthroughnum.Items.Add(res.Content.MACHINESEQ);
                cbthroughnum.Enabled = false;
                cbthroughnum.SelectedIndex = 0;
            }
            else
            {
                cbthroughnum.Items.Clear();
                cbthroughnum.Items.Add("1061");
            }
        }
        w_CigInfo wc;
        int Type =0;//操作类型
        decimal Machineseq;
        Business.BusinessClass.ChannelClass cc = new Business.BusinessClass.ChannelClass();
        string cigcode, cigname;
        private void btn_choose_Click(object sender, EventArgs e)
        {
            wc = new w_CigInfo();
            wc.StartPosition = FormStartPosition.CenterScreen;
            wc.ShowDialog();
            if (wc.DialogResult
                 == System.Windows.Forms.DialogResult.OK)
            {

                txt_iteminfo.Text = wc.CigName +" " + wc.CigCode;
                cigcode = wc.CigCode;
                cigname = wc.CigName;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (Type == 0)
            {
                T_PRODUCE_SORTTROUGH tps = new T_PRODUCE_SORTTROUGH();
                tps.CIGARETTECODE = cigcode;
                tps.CIGARETTENAME = cigname;
                tps.STATE = "10"; // Convert.ToDecimal(cbthroughnum.SelectedValue);
                tps.MACHINESEQ =Convert.ToDecimal( cbthroughnum.SelectedItem);
              var a  =  cc.AddOneTrough(tps);
              if (a.IsSuccess)
              {
                  Close();
              }
              else
              {
                  MessageBox.Show(a.MessageText);
              }
            }
            else if (Type == 1)
            {
                T_PRODUCE_SORTTROUGH tps = new T_PRODUCE_SORTTROUGH();
                tps.MACHINESEQ = Machineseq; 
                tps.CIGARETTENAME = cigname;
                tps.CIGARETTECODE = cigcode; 
               var a =   cc.ChangeOneTrough(tps); 
                if (a.IsSuccess)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show(a.MessageText);
                }
            }
        }

       
    }
}
