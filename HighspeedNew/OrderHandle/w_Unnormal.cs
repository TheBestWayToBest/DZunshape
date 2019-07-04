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
    public partial class w_Unnormal : Form
    {
        public w_Unnormal()
        {
            InitializeComponent();
            List<AllOrderData> list=new List<AllOrderData> ();
            list=OrderClass.GetUnnormalCig();
            orderdata.DataSource = list;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            dgVprint1.MainTitle = "今日异型烟汇总";
            //dgVprint1.SubTitle = "这是子标题，当然也可以不设的";

            dgVprint1.TableHeaderLeft = "长株潭烟草物流配送中心";
            dgVprint1.TableHeaderRight = "分拣日期：" + DateTime.Now.Date.ToShortDateString();
            dgVprint1.PaperLandscape = true;//用横向打印，默认是纵向哦
            dgVprint1.Print(orderdata);
        }
    }
}
