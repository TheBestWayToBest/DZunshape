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
    public partial class w_orderdata : Form
    {
        public w_orderdata()
        {
            InitializeComponent();
            Bind();
        }

        void Bind() 
        {
            List<AllOrderData> list = new List<AllOrderData>();
            list = OrderClass.GetAllOrder();

            this.orderdata.DataSource = list;
            this.orderdata.AutoGenerateColumns = false;

            //string columnwidths = pub.IniReadValue(this.Name, this.orderdata.Name);
            //if (columnwidths != "")
            //{
            //    string[] columns = columnwidths.Split(',');
            //    int j = 0;
            //    for (int i = 0; i < columns.Length; i++)
            //    {
            //        if (orderdata.Columns[i].Visible == true)
            //        {
            //            orderdata.Columns[j].Width = Convert.ToInt32(columns[i]);
            //            j = j + 1;
            //        }
            //    }
            //}
            orderdata.ClearSelection();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            dgVprint1.MainTitle = "今日订单汇总";
            dgVprint1.TableHeaderLeft = "山东德州烟草配送中心";
            dgVprint1.TableHeaderRight = "分拣日期：" + DateTime.Now.Date.ToShortDateString();
            //dgVprint2.PaperLandscape = true;//用横向打印，默认是纵向哦
            dgVprint1.Print(orderdata);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgVprint1.ExportDGVToExcel2(this.orderdata, "今日订单汇总", "orderinfo.xls", true);
        }

        private void orderdata_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               orderdata.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                   orderdata.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   orderdata.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
