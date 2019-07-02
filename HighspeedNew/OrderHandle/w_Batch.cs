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


using Business;namespace HighSpeed.OrderHandle
{
    public partial class w_Batch : Form
    {
        
        List<T_PRODUCE_BATCH>batch;
        public w_Batch()
        {
            InitializeComponent();
            Refsh();
        }
        BatchClass bc = new BatchClass();
        TaskClass tc = new TaskClass();
        ScheduleClass rc = new ScheduleClass();
        ChannelClass cc = new ChannelClass();
        /// <summary>
        /// 刷新界面
        /// </summary>
        void Refsh()
        {
            cc.GetSortTroughInfo("s", 1);
            batch = bc.GetBatchDetail().Content;
            batchdata.DataSource = batch;
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

        private void batchdata_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               batchdata.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                   batchdata.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   batchdata.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void batchdata_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4) {
                if (batch[e.RowIndex].BATCHTYPE == 20) {
                    e.Value = "异型烟";
                }
            }
            if (e.ColumnIndex == 3)
            {
                if (batch[e.RowIndex].STATE == 10)
                {
                    e.Value = "正常";
                }
                else 
                {
                    e.Value = "关闭";
                }
            }
        }
    }
}
