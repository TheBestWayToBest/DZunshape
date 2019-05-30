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

namespace HighSpeed.OrderHandle
{
    public partial class w_Batch : Form
    {
        public w_Batch()
        {
            InitializeComponent();
            Refsh();
        }
        BatchClass bc = new BatchClass();
        TaskClass tc = new TaskClass();

        /// <summary>
        /// 刷新界面
        /// </summary>
        void Refsh()
        {
            var data = bc.GetBatchDetail() ;
            batchdata.DataSource = data.Content;
          //  batchdata.DataSource = bc.GetBatchDetail().ResultObject;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            Response re = tc.JugTaskIsOrNotFinish();
            if (re.IsSuccess)//如果分拣任务已经完成
            {
                win_batch_new bnew = new win_batch_new(20);
                bnew.StartPosition = FormStartPosition.CenterScreen;
                bnew.ShowDialog();
                Refsh();
            }
            else
            {
                MessageBox.Show(re.MessageText);
            }
        }
    }
}
