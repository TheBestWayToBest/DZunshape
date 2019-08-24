using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.BusinessClass;
using Business;
using Business.Modle;
using System.Threading;

namespace HighspeedNew.OrderHandle
{
    public partial class w_SortFm_New : Form
    {
        public w_SortFm_New()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Bind();
        }
        private void btnRef_Click(object sender, EventArgs e)
        {
            Bind();
        }
        ScheduleClass sc = new ScheduleClass();

        void Bind()
        {
            var scre = sc.GetTaskInfo();
            if (scre.IsSuccess)
            {
                dgvSortInfo.Rows.Clear();
                List<TaskInfo> list = scre.Content.Select(x => new TaskInfo { SYNSEQ = x.SYNSEQ, REGIONCODE = x.REGIONCODE, Count = x.Count, QTY = x.QTY }).ToList();
                foreach (var item in list)
                {

                    DataGridViewCellStyle dgvStyle = new DataGridViewCellStyle();
                    dgvStyle.BackColor = Color.LightGreen;
                    // 存了状态值  
                    //string status = "";
                    int index = this.dgvSortInfo.Rows.Add();
                    this.dgvSortInfo.Rows[index].Cells[0].Value = item.SYNSEQ;//户序
                    this.dgvSortInfo.Rows[index].Cells[1].Value = item.REGIONCODE; //分拣任务号

                    this.dgvSortInfo.Rows[index].Cells[2].Value = item.Count;//车组号
                    this.dgvSortInfo.Rows[index].Cells[3].Value = item.QTY;//抓烟数量
                    //this.dgvSortInfo.Rows[index].Cells[4].Value = item.CusName;//客户名称
                    //this.dgvSortInfo.Rows[index].Cells[5].Value = item.CigCode;//香烟编号
                    //this.dgvSortInfo.Rows[index].Cells[6].Value = item.CigName;//香烟名称


                    //this.dgvSortInfo.Rows[index].Cells[8].Value = item.ThroughNum;//物理通道号
                    //this.dgvSortInfo.Rows[index].Cells[9].Value = item.BillCode;//订单号


                }
                LblCusCount.Text = "总订货户数：" + scre.Content.Sum(item => item.Count).ToString();
                LblCigCount.Text = "总订单条烟数量：" + scre.Content.Sum(item => item.QTY).ToString();

            }

        }
        int times;
        delegate void HandleSort();
        private void btnSort_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            label2.Text = "正在读取数据...";
            progressBar1.Value = 0;
            label2.Visible = true;
            panel2.Visible = true;
            lblTime.Visible = true;
            progressBar1.Visible = true;
            times = 0;//时间重置 
            TimerByTime.Start();// = true;//启动时间记录
            lblTime.Text = "已用时间:0秒";
            HandleSort task = Sort; //新的
            task.BeginInvoke(null, null);
            label2.Text = "正在对分拣车组任务数据进排程";
        }
        void Sort()
        {
            try
            {
                progressBar1.Value = (progressBar1.Maximum / 2);
                var re = sc.SchedulePoke();
                //排程结束后，对排程数据进行验证
                ValidationClass vc = new ValidationClass();
                Response response = vc.ValidationSchedule("2");
                if (response.IsSuccess)
                {

                    if (re.IsSuccess)
                    {
                        List<MixedInfo> list = MixedClass.GetUnPokeData();
                        MixedClass.InsertPokeMixed(list);
                        btnPokeSeq.Enabled = true;
                        progressBar1.Value = progressBar1.Maximum;
                        //TimerByTime.Stop();// 计时结束;
                        btnSort.Enabled = true;
                        lblInFO.Text = "分拣车组任务排程成功！" + "\r\n" + "所用时间:" + times + "秒";
                        MessageBox.Show("分拣车组任务排程成功！" + "\r\n" + "所用时间:" + times + "秒", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        panel2.Visible = false;
                        TimerByTime.Stop();// 计时结束;
                        btnSort.Enabled = true;
                        MessageBox.Show(re.MessageText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //回滚排程操作
                    MessageBox.Show(response.MessageText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("排程异常:" + e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                //dgvSortInfo.Rows.Clear();
                //List<TaskInfo> list = new List<TaskInfo>();
                //dgvSortInfo.DataSource = list;

                
                panel2.Visible = false;
                TimerByTime.Stop();// 计时结束;
                btnSort.Enabled = true;
            }

        }

        private void btn_replenishplan_Click(object sender, EventArgs e)
        {
            Replan plan = new Replan();
            Response response = plan.AutoGenReplan();
            MessageBox.Show(response.MessageText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void TimerByTime_Tick(object sender, EventArgs e)
        {
            times = times + 1;
            lblTime.Text = "已用时间:" + times + "秒";
        }
    }
}
