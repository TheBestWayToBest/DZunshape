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
using HighspeedNew.OrderHandle;

namespace HighSpeed.OrderHandle
{
    public partial class w_Cigarette_LeftCount : Form
    {
        public w_Cigarette_LeftCount()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            List<CigarreteLeftCountInfo> list = new List<CigarreteLeftCountInfo>();
            list = CigarreteLeftCountClass.GetLeftCount(comboBox1.SelectedIndex + 2);
            codedata.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<CigarreteLeftCountInfo> list = new List<CigarreteLeftCountInfo>();
            list = CigarreteLeftCountClass.GetLeftCount(comboBox1.SelectedIndex + 2);
            codedata.DataSource = list;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.codedata.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择一行修改");
            }
            else 
            {
                w_CigaretteHandle repleish_handle = new w_CigaretteHandle(this.codedata.CurrentRow.Cells["cigarettecode"].Value.ToString(), this.codedata.CurrentRow.Cells["cigarettename"].Value.ToString(),
                   this.codedata.CurrentRow.Cells["machineseq"].Value.ToString(),
                   this.codedata.CurrentRow.Cells["mantissa"].Value.ToString(),
                   this.codedata.CurrentRow.Cells["THRESHOLD"].Value.ToString(),
                   comboBox1.SelectedIndex + 2
                   );
                repleish_handle.WindowState = FormWindowState.Normal;
                repleish_handle.StartPosition = FormStartPosition.CenterScreen;
                repleish_handle.ShowDialog();
                List<CigarreteLeftCountInfo> list = new List<CigarreteLeftCountInfo>();
                list = CigarreteLeftCountClass.GetLeftCount(comboBox1.SelectedIndex + 2);
                codedata.DataSource = list;
            }
        }
    }
}
