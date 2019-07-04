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
    public partial class w_HunheReport : Form
    {
        public w_HunheReport()
        {
            InitializeComponent();
            List<string> list = new List<string>();
            list = HunheClass.GetHunheThrough();
            list.Insert(0, "所有");
            cmbTroughnum.DataSource = list;
            cmbTroughnum.SelectedIndex = 0;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            List<HunheInfo> list = new List<HunheInfo>();
            task_data.DataSource = list;
            switch (cmbTroughnum.SelectedIndex) 
            {
                case 0:
                    if (radioButton1.Checked)
                        list = HunheClass.GetHunheData((decimal)10, (decimal)0);
                    else if(radioButton2.Checked)
                        list = HunheClass.GetHunheData((decimal)15, (decimal)0);
                    else
                        list = HunheClass.GetHunheData((decimal)20, (decimal)0);
                    break;
                case 1:
                    if (radioButton1.Checked)
                        list = HunheClass.GetHunheData((decimal)10, Convert.ToDecimal(cmbTroughnum.SelectedItem));
                    else if(radioButton2.Checked)
                        list = HunheClass.GetHunheData((decimal)15, Convert.ToDecimal(cmbTroughnum.SelectedItem));
                    else
                        list = HunheClass.GetHunheData((decimal)20, Convert.ToDecimal(cmbTroughnum.SelectedItem));
                    break;
                case 2:
                    if (radioButton1.Checked)
                        list = HunheClass.GetHunheData((decimal)10, Convert.ToDecimal(cmbTroughnum.SelectedItem));
                    else if (radioButton2.Checked)
                        list = HunheClass.GetHunheData((decimal)15, Convert.ToDecimal(cmbTroughnum.SelectedItem));
                    else
                        list = HunheClass.GetHunheData((decimal)20, Convert.ToDecimal(cmbTroughnum.SelectedItem));
                    break;
                case 3:
                    if (radioButton1.Checked)
                        list = HunheClass.GetHunheData((decimal)10, Convert.ToDecimal(cmbTroughnum.SelectedItem));
                    else if (radioButton2.Checked)
                        list = HunheClass.GetHunheData((decimal)15, Convert.ToDecimal(cmbTroughnum.SelectedItem));
                    else
                        list = HunheClass.GetHunheData((decimal)20, Convert.ToDecimal(cmbTroughnum.SelectedItem));
                    break;
            }
            task_data.DataSource = list;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            dgVprint1.MainTitle = cmbTroughnum.SelectedItem + "混合道补货顺序";
            //dgVprint1.SubTitle = "这是子标题，当然也可以不设的";
            // dgVprint1.PaperLandscape = true;//用横向打印，默认是纵向

            dgVprint1.Print(task_data);
        }
    }
}
