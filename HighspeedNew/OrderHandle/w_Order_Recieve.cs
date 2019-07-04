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
    public partial class w_Order_Recieve : Form
    {
        public w_Order_Recieve()
        {
            InitializeComponent();
            this.datePick.Value = DateTime.Today;
            //Bind();
        }
        ScheduleClass sc = new ScheduleClass();
        void Bind()
        { 
            var rm = sc.GetRegionInfo(datePick.Value);
            if (rm.IsSuccess)
            {
                orderdata.DataSource = rm.Content;
            }
            else
            {
                MessageBox.Show(rm.MessageText);
                //orderdata.DataSource = null;
                orderdata.AutoGenerateColumns = false;
                orderdata.DataSource = new List<MainOrder>();
            }
            this.txt_codestr.Text = "";

        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            Bind();
        }

        private void btn_recieve_Click(object sender, EventArgs e)
        {
            decimal maxSyncseq = 0;
            try
            {
                maxSyncseq = sc.GetSyncseqFromOrderTable().Content;
                String codestr = this.txt_codestr.Text.Trim();
                btn_recieve.Enabled = false;
                if (codestr != "")
                {
                    String[] code = codestr.Substring(1).Split(',');
                    int len = code.Length, sucCount = 0;
                    string indexstr = "";
                    for (int i = 0; i < len; i++)
                    {
                        panel2.Visible = true;
                        label2.Visible = true;
                        progressBar1.Visible = true;
                        progressBar1.Value = 0;
                        Application.DoEvents();
                        if (i == 0) label2.Text = "正在接收" + code[i] + "车组订单数据...";
                        DateTime time = DateTime.Parse(datePick.Value.ToString());
                        var re = sc.ReceiveSaleOrderToOrder(time, code[i], maxSyncseq);//接收数据

                        progressBar1.Value = ((i + 1) * 100 / len);
                        progressBar1.Refresh();
                        String tmpstr = "";

                        if (re.IsSuccess)
                        {
                            if (i + 1 < len) tmpstr = "正在接收" + code[i + 1] + "车组订单数据...";
                            else tmpstr = "";
                            label2.Text = code[i] + "车组订单数据接收完毕..." + tmpstr;
                            label2.Refresh();
                            indexstr = indexstr + "," + code[i];
                            sucCount++;
                        }
                        else
                        {
                            label2.Text = re.MessageText;
                            label2.Refresh();
                            MessageBox.Show(re.MessageText);
                            break;
                        }
                    }
                    panel2.Visible = false;
                    label2.Visible = false;
                    progressBar1.Visible = false;
                    MessageBox.Show(sucCount + "个车组的订单数据接收成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("请至少选择一个要接收订单的车组!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.btn_recieve.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("订单接收异常" + ex.Message);
            }
            finally
            {
                //根据批次maxSyncseq验证是否有新品牌和客户,提示定性新品牌并设置条烟转换比例 
                Response response = new Response();
                String resultMsg = "";
                //验证是否有新品牌
                response = sc.ValidNewItem(maxSyncseq);
                if(!response.IsSuccess){
                    resultMsg = resultMsg + "品牌验证：" + response.MessageText;
                    //MessageBox.Show(response.MessageText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //验证是否有新客户
                /*response = sc.ValidNewCustomer(maxSyncseq);
                    if (!response.IsSuccess)
                    {
                        resultMsg = "\r\n" + resultMsg + "零售户验证：" + response.MessageText;
                        //MessageBox.Show(response.MessageText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }*/
                //验证订单数量
                response = sc.ValiOrderNum(maxSyncseq, this.datePick.Value);
                if (!response.IsSuccess)
                {
                    resultMsg = "\r\n" + resultMsg + "订单数验证：" + response.MessageText;
                    //MessageBox.Show(response.MessageText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (!"".Equals(resultMsg)) {
                    MessageBox.Show(resultMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Bind();
            }
           
        }

        private void orderdata_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bool obj = (bool)this.orderdata.CurrentRow.Cells[0].EditedFormattedValue;

                String czcode = this.orderdata.CurrentRow.Cells[2].Value + "";//modify by tjl
                String czcodestr = this.txt_codestr.Text;
                if (obj)
                {
                    if (!czcodestr.Contains(czcode))
                    {
                        czcodestr = czcodestr + "," + czcode;
                    }
                }
                else
                {
                    czcodestr = czcodestr.Replace("," + czcode, "");
                }
                this.txt_codestr.Text = czcodestr;
            }
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            String czcodestr = "";
            for (int i = 0; i < this.orderdata.RowCount; i++)
            {
                orderdata.Rows[i].Cells[0].Value = "true";
                czcodestr = czcodestr + "," + orderdata.Rows[i].Cells[2].Value + "";
            }
            this.txt_codestr.Text = czcodestr;
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            label2.Visible = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Refresh();
            timer1.Start();
            Application.DoEvents();
            label2.Text = "正在从营销中心同步订单数据，请耐心等候...";
            
            string orderDateStr=datePick.Value.ToString("yyyyMMdd");
            ScheduleClass sc = new ScheduleClass();
            Response response=sc.SyncOrderDataFromInspur(orderDateStr);

            panel2.Visible = false;
            label2.Visible = false;
            progressBar1.Visible = false;
            timer1.Stop();
            MessageBox.Show(response.MessageText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (response.IsSuccess) Bind();
        }
        int time = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {

            progressBar1.Value = Convert.ToInt32(((time++) / 20.0) * 100);
            progressBar1.Refresh();
        }
    }
}
