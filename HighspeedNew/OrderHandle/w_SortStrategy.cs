using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HighspeedNew.OrderHandle
{
    public partial class w_SortStrategy : Form
    {
        public w_SortStrategy()
        {
            InitializeComponent();
        }
        int index = 1;
        public int Index { get { return index; } }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (RBAll.Checked)
                index = 0;
            else if (RBMost.Checked)
                index = 1;
            else
                index = 2;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index = -1;
            Close();
        }
    }
}
