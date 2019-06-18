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
    public partial class w_schedulereport : Form
    {
        public w_schedulereport()
        {
            InitializeComponent();
            Bind();
        }
        void Bind() 
        {
            List<PokeInfo> list = new List<PokeInfo>(); 
            list = ScheduleClass.GetAllSchdule();
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
            //dgVprint2.MainTitle = "排程报表";
            ////dgVprint1.SubTitle = "这是子标题，当然也可以不设的";
            ////dgVprint1.PageHeaderLeft = "白沙物流";
            ////dgVprint1.PageHeaderRight = "分拣日期：" + DateTime.Now.Date.ToShortDateString();
            //dgVprint2.TableHeaderLeft = "长株潭烟草物流配送中心";
            //dgVprint2.TableHeaderRight = "分拣日期：" + DateTime.Now.Date.ToShortDateString();
            ////dgVprint2.PaperLandscape = true;//用横向打印，默认是纵向哦
            //dgVprint2.Print(orderdata);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dgVprint2.ExportDGVToExcel2(this.orderdata, "排程报表", "schedulereport.xls", true);
        }
    }
}
