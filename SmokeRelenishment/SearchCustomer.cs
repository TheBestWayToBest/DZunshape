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

namespace SmokeRelenishment
{
    public partial class SearchCustomer : Form
    {
        public SearchCustomer()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            List<Replenish> list = new List<Replenish>();
            list = RelenishimentClass.GetReplenishByCigName(comboBox1.SelectedIndex, txt_search.Text);
            DgvNowView.DataSource = list;
        }

        private void SearchCustomer_Deactivate(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }
    }
}
