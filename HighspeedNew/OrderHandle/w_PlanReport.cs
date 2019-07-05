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
    public partial class w_PlanReport : Form
    {
        public w_PlanReport()
        {
            InitializeComponent();
            List<PlanInfo> list = new List<PlanInfo>();
            list = Replan.GetPlan();
            orderdata.DataSource = list;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            dgVprint1.MainTitle = "件烟补货计划汇总";
            dgVprint1.TableHeaderLeft = "山东德州烟草配送中心";
            dgVprint1.TableHeaderRight = "分拣日期：" + DateTime.Now.Date.ToShortDateString();
            //dgVprint2.PaperLandscape = true;//用横向打印，默认是纵向哦
            dgVprint1.Print(orderdata);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgVprint1.ExportDGVToExcel2(this.orderdata, "件烟补货计划汇总", "planinfo.xls", true);
        }
    }
}
