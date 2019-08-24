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
    public partial class w_PackageReport : Form
    {
        public w_PackageReport()
        {
            InitializeComponent();

            List<string> list = new List<string>();
            list = PackageClass.GetAllRegion();
            CmbRegion.DataSource = list;
            CmbRegion.SelectedIndex = 0;
        }

        void Bind() 
        {
            List<T_PRODUCE_PACKAGECALLBACK> list = new List<T_PRODUCE_PACKAGECALLBACK>();
            list = PackageClass.GetPackInfoByRegion(CmbRegion.SelectedItem.ToString());
            dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bind();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgVprint1.ExportDGVToExcel2(this.dataGridView1, "包装机数据", "PACKAGEMACHINEDATA.xls", true);
        }
    }
}
