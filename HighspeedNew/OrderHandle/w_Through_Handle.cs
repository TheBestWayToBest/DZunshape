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

namespace HighspeedNew.OrderHandle
{
    public partial class w_Through_Handle : Form
    {
        String handle_sign = "", id = "";
        string type = "", troughtype = "";
        string machine = "";
        decimal groupNo = 0;
        string lastCigarettecode;
        public List<string> list = new List<string>();
        public w_Through_Handle(String sign, String amend_id, string type, string troughtype, string machineSeq,decimal groupNo,string lastCigarettecode)
        {
            InitializeComponent();
            this.lastCigarettecode = lastCigarettecode;
            this.type = type;
            this.troughtype = troughtype;
            handle_sign = sign;
            this.machine = machineSeq;
            this.groupNo = groupNo;
            if (handle_sign == "0")
            {
                init(40);
                this.Text = "分拣通道--新增";
            }
            else
            {
                this.Text = "分拣通道--修改";
                init(0);
                txt_troughdesc.Enabled = false;
                this.box_actcount.Enabled = false;

            }

            id = amend_id;
        }
        public void init(decimal type)
        {
            decimal machineseq = new decimal();
            if (type == 40)
            {
                List<string> list = ThroughClass.GetMachineseqByType(40);
                foreach (var item in list)
                {
                    string[] str = item.Split(',');
                    if (str[0] == "2")
                    {
                        this.cbthroughnum.Items.Add("立式烟仓混合道(" + str[1] + ")");
                    }
                    else
                    {
                        this.cbthroughnum.Items.Add("特异形烟道(" + str[1] + ")");
                    }
                }
                this.cbthroughnum.SelectedIndex = 0;
            }

            else
            {
                machineseq = decimal.Parse(machine);

                this.cbthroughnum.Items.Add(machineseq);
                this.cbthroughnum.SelectedIndex = 0;
            }
                
            lbltype.Text = "异形烟";
            lbllineNum.Text = "异形烟分拣线";
            //cbthroughnum.Enabled = false;
            txt_troughdesc.Visible = false;

            box_actcount.Visible = false;
            //cbthroughnum.Visible = false;


            label8.Visible = false;
            // label2.Visible = false;
            label3.Visible = false;
        }
        private void btn_choose_Click(object sender, EventArgs e)
        {
            w_CigaretteChoose choose = new w_CigaretteChoose(list);
            choose.WindowState = FormWindowState.Normal;
            choose.ShowDialog();
            if (choose.DialogResult == DialogResult.OK)
            {
                list = choose.returnObj;
                if (this.list.Count == 2)
                {
                    this.txt_itemno.Text = list[0];
                    this.txt_itemname.Text = list[1];
                    this.txt_iteminfo.Text = list[1] + "（" + list[0] + "）";
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            T_PRODUCE_SORTTROUGH tps = new T_PRODUCE_SORTTROUGH();
            //tps.MACHINESEQ = Convert.ToDecimal(this.cbthroughnum.Text.Trim());//设备物理号编号:获取选择下拉框内的通道编号
            tps.TROUGHDESC = this.txt_troughdesc.Text.Trim();
            tps.CIGARETTECODE = this.txt_itemno.Text;
            tps.CIGARETTENAME = this.txt_itemname.Text;
            tps.SEQ = 2;
            tps.GROUPNO = groupNo;
            tps.TROUGHTYPE = 10;
            tps.CIGARETTETYPE = Convert.ToDecimal(type);
            tps.MANTISSA = 0;
            tps.STATE = "10";
            tps.LINENUM = "0";
            
            //if (tps.MACHINESEQ.ToString() == "")
            //{
            //    MessageBox.Show("请选择通道编号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            if (tps.CIGARETTECODE == "")
            {
                MessageBox.Show("请选择卷烟品牌!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (handle_sign == "0")
            {
                string str=this.cbthroughnum.Text.Trim();
                //string s = str.Substring(str.IndexOf('(')+1, str.IndexOf(')') - str.IndexOf('(')-1);
                tps.MACHINESEQ = Convert.ToDecimal(str.Substring(str.IndexOf('(') + 1, str.IndexOf(')') - str.IndexOf('(') - 1));
                string msg = ThroughClass.InsertThrough(tps);
                
                MessageBox.Show(msg);
                this.Close();
            }
            else
            {
                if (tps.MACHINESEQ.ToString() == "")
                {
                    MessageBox.Show("请选择通道编号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                tps.MACHINESEQ = Convert.ToDecimal(this.cbthroughnum.Text.Trim());
                tps.ID = Convert.ToDecimal(id);
                string msg = ThroughClass.UpdateThrough(tps,lastCigarettecode);
                MessageBox.Show(msg);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
