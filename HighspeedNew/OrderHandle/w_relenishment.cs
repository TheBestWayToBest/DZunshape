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
    public partial class w_relenishment : Form
    {
        public w_relenishment()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            decimal status;
            if (RBAll.Checked)
                status = 0;
            else if (RBUnfinish.Checked)
                status = 10;
            else if (RBFinishing.Checked)
                status = 15;
            else
                status = 20;
            List<ReplenishInfo> list = new List<ReplenishInfo>();
            list = RelenishimentClass.GetReplenish(status);
            dgvReplenish.DataSource = list;
            this.dgvReplenish.AutoGenerateColumns = false;

            //string columnwidths = pub.IniReadValue(this.Name, this.troughdata.Name);
            //if (columnwidths != "")
            //{
            //    string[] columns = columnwidths.Split(',');
            //    int j = 0;
            //    for (int i = 0; i < columns.Length; i++)
            //    {
            //        if (dgvReplenish.Columns[i].Visible == true)
            //        {
            //            dgvReplenish.Columns[j].Width = Convert.ToInt32(columns[i]);
            //            j = j + 1;
            //        }
            //    }
            //}
            dgvReplenish.ClearSelection();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            dgVprint1.MainTitle = "件烟补货顺序";
            //dgVprint1.SubTitle = "这是子标题，当然也可以不设的";

            dgVprint1.TableHeaderLeft = "山东德州烟草配送中心";
            dgVprint1.TableHeaderRight = "分拣日期：" + DateTime.Now.Date.ToShortDateString();
            dgVprint1.PaperLandscape = true;//用横向打印，默认是纵向哦
            dgVprint1.Print(dgvReplenish);
        }
    }
}
