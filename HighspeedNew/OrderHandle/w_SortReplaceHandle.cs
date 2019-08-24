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
    public partial class w_SortReplaceHandle : Form
    {
        public w_SortReplaceHandle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            decimal ctype = 2;
            decimal machineseq = 0;
            if (RBLishi.Checked)
                ctype = 2;
            else
                ctype = 3;
            if (textBox1.Text == "")
                machineseq = 0;
            else
            {
                bool flag = decimal.TryParse(textBox1.Text, out machineseq);
                if (!flag)
                {
                    MessageBox.Show("输入错误");
                    return;
                }
            }

            List<SortReplaceInfo> list = new List<SortReplaceInfo>();
            list = SortClass.GetSortThroughInfo(ctype, machineseq);
            dataGridView1.DataSource = list;
        }
        SortReplaceInfo info = new SortReplaceInfo();
        public SortReplaceInfo ReturnObj { get { return info; } }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (info1.MachineSeq > 0 && info1.ThroughNum != "" && info1.CigaretteCode != "" && info1.CigaretteName != "")
            {
                info = info1;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请先点击选择您要的通道，再进行提交！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        SortReplaceInfo info1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            info1 = new SortReplaceInfo();
            if (e.RowIndex > -1)
            {
                if (this.dataGridView1.CurrentRow != null && this.dataGridView1.CurrentRow.Index != -1)
                {
                    BtnSubmit.Enabled = true;
                    info1.MachineSeq = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[0].Value);
                    info1.ThroughNum = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    info1.CigaretteCode = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    info1.CigaretteName = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                }
                else 
                {
                    BtnSubmit.Enabled = false;
                }
            }
        }
    }
}
