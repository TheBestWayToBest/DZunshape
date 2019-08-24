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
    public partial class w_orderDetail : Form
    {
        string regionCode = "";
        DateTime date = DateTime.Now.Date;
        public w_orderDetail(string region,string time)
        {
            InitializeComponent();
            this.regionCode = region;
            date = Convert.ToDateTime(time);
            Bind();
        }

        void Bind() 
        {
            List<OrderLineInfo> list = new List<OrderLineInfo>();
            list = OrderClass.GetRegionOrderline(regionCode,date);
            dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgVprint1.ExportDGVToExcel2(this.dataGridView1, "车组异形烟订单明细", "ORDERDETAIL.xls", true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgVprint1.MainTitle = "车组异形烟订单明细";
            //dgVprint1.SubTitle = "这是子标题，当然也可以不设的";
            dgVprint1.TableHeaderLeft = "山东德州烟草配送中心";
            dgVprint1.TableHeaderRight = "分拣日期：" + DateTime.Now.Date.ToShortDateString();
            //dgVprint2.PaperLandscape = true;//用横向打印，默认是纵向哦
            dgVprint1.Print(dataGridView1);
        }
    }
}
