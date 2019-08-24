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
    public partial class w_order_Union : Form
    {
        public w_order_Union()
        {
            InitializeComponent();
            string weekstr = DateTime.Now.DayOfWeek.ToString();
            this.datePick.Value = DateTime.Today;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Bind();
        }
        string time = "";
        void Bind() 
        {
            time = this.datePick.Text;
            this.txt_codestr.Text = "";
            List<OrderData> list = new List<OrderData>();
            list = OrderClass.GetOrderByDate(Convert.ToDateTime(time));

            try
            {

                //进度条显示
                panel2.Visible = true;
                label2.Visible = true;
                progressBar1.Visible = true;
                int rcounts = list.Count;
                progressBar1.Value = 0;
                for (int i = 0; i < rcounts; i++)
                {
                    Application.DoEvents();
                    progressBar1.Value = ((i + 1) * 100 / rcounts);
                    progressBar1.Refresh();
                    label2.Text = "正在读取数据..." + ((i + 1) * 100 / rcounts).ToString() + "%";
                    label2.Refresh();
                }
                panel2.Visible = false;
                label2.Visible = false;
                progressBar1.Visible = false;

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            if (btn_all.Text == "全选")
            {
                String czcodestr = "";
                for (int i = 0; i < this.orderdata.RowCount; i++)
                {
                    orderdata.Rows[i].Cells[0].Value = "true";
                    czcodestr = czcodestr + "," + orderdata.Rows[i].Cells[2].Value + "";
                }
                this.txt_codestr.Text = czcodestr;
                btn_all.Text = "反选";
            }
            else
            {
                for (int i = 0; i < this.orderdata.RowCount; i++)
                {
                    orderdata.Rows[i].Cells[0].Value = "false";
                }
                this.txt_codestr.Text = "";
                btn_all.Text = "全选";

            }
        }

        private void btnVli_Click(object sender, EventArgs e)
        {
            string Str = UnPokeClass.GetNullLWSomke();
            MessageBox.Show(Str); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgVprint1.MainTitle = "今日订单烟预汇总";

            dgVprint1.TableHeaderLeft = "山东德州烟草配送中心";
            dgVprint1.TableHeaderRight = "分拣日期：" + DateTime.Now.Date.ToShortDateString();
            //dgVprint1.PaperLandscape = true;//用横向打印，默认是纵向哦
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

        private void orderdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string region = orderdata.Rows[e.RowIndex].Cells[0].Value.ToString();
            w_orderDetail frm = new w_orderDetail(region,time);
            frm.Show();
        }
    }
}
