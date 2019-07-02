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

namespace HighspeedNew.OrderHandle
{
    public partial class w_CigaretteHandle : Form
    {
        String itemno, itemName;
        String machineseq;
        int groupNo;
        public w_CigaretteHandle(String itemno, String itemname, String machineseq, String ws, String fz, int groupNo)
        {
            InitializeComponent();

            lblName.Text = itemname;
            lblNo.Text = itemno;
            this.itemno = itemno;
            this.itemName = itemname;
            this.machineseq = machineseq;
            this.tbws.Text = ws;
            this.tbhjws.Text = fz;
            this.groupNo = groupNo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CigarreteLeftCountInfo info = new CigarreteLeftCountInfo()
            {
                CigaretteCode = itemno,
                CigaretteName = itemName,
                MachineSeq = Convert.ToDecimal(machineseq),
                Threshold = Convert.ToDecimal(tbhjws.Text),
                Mantissa = Convert.ToDecimal(tbws.Text)
            };
            if (CigarreteLeftCountClass.UpdateLeftCount(info, groupNo))
                MessageBox.Show("修改成功");
            else
                MessageBox.Show("修改失败");
        }

        private void tbws_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }

        private void tbhjws_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }
    }
}
