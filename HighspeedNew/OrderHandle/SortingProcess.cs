using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.BusinessClass;

namespace HighSpeed.OrderHandle
{
    public partial class SortingProcess : Form
    {
        public string sign;
        public string amend_id;
        public SortingProcess()
        {
            InitializeComponent();
            initdata();
        }
        public void initdata()
        {
            ScheduleClass sc = new ScheduleClass();
            var result=sc.GetSortingProcess();
            if (result.IsSuccess)
            {
                task_data.DataSource = result.Content.Select(x => new { synseq = x.SYNSEQ, regioncode = x.REGIONCODE, finishcountstr = x.FinishCountStr, finishqtystr = x.FinishQtyStr, rate = x.Rate }).ToList(); ;
            }
            else 
            {
                MessageBox.Show(result.MessageText);
                task_data.DataSource = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initdata();
        }
    }
}
