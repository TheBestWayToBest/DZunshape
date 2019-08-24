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
            //for (int i = 0; i < list.Count; i++)
            //{
            //    if (list[i] == "1")
            //        list[i] = "特异形烟" + list[i] + "道";
            //    else
            //        list[i] = "混合" + list[i] + "道";
            //}
            list.Insert(0, "所有");
            cmbTroughnum.DataSource = list;
            cmbTroughnum.SelectedIndex = 0;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            List<HunheInfo> list = new List<HunheInfo>();
            task_data.DataSource = list;
            if (cmbTroughnum.SelectedIndex == 0)
                list = HunheClass.GetHunheData(0);
            else
                list = HunheClass.GetHunheData(Convert.ToDecimal(cmbTroughnum.SelectedItem));
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
