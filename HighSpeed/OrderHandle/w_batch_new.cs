using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Business.BusinessClass;
using Business.Modle;

namespace HighSpeed.OrderHandle
{
    public partial class win_batch_new : Form
    { 
        int para = 0;
        public win_batch_new(int para)
        {
            this.para = para;
            InitializeComponent();
            Textd();
        }
        void Textd()
        {
            txt_batchcode.Text = bc.CreateBatchCode().ResultObject.ToString();//创建一个最新的批次号
            String time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.starttime.Text = time;
        }
        BatchClass bc = new BatchClass();
        Response response;
        TaskClass tc = new TaskClass();
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {


                String txt_batchcode = this.txt_batchcode.Text.Trim();
                String txt_starttime = this.starttime.Text;
                if (string.IsNullOrWhiteSpace(txt_batchcode) || string.IsNullOrWhiteSpace(txt_starttime))
                {
                    MessageBox.Show("请填写批次编号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    response = bc.OperationBatch();//关闭最近一个创建的批次
                    if (response.IsSuccess)
                    {
                        response = bc.OperationBatch(txt_batchcode, 1);//创建一个新的批次
                        if (response.IsSuccess)
                        {
                            this.panel1.Visible = true;
                            this.lab_showinfo.Text = "正在处理历史订单和任务,请稍候......";
                            response = tc.RemoveTask();//移除分拣数据到历史表中
                            if (response.IsSuccess)
                            {
                                this.lab_showinfo.Text = "处理完成";
                                this.panel1.Visible = false;
                                MessageBox.Show("历史数据处理完成!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("历史数据处理："+response.MessageText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show(response.MessageText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.MessageText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Close();
            }
        }

    }
}
