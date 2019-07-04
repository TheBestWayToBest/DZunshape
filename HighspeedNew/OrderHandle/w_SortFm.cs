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
namespace HighSpeed.OrderHandle
{
    public partial class w_SortFm : Form
    {
        public w_SortFm()
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
                //dgvSortInfo.DataSource = scre.Content.GroupBy(x => new { x.REGIONCODE }).Select(x => new { 车组信息 = x.Key.REGIONCODE, 订单数量 = scre.Content.Where(a => a.REGIONCODE == x.Key.REGIONCODE).Sum(a => a.TASKQUANTITY), 订单户数 = scre.Content.Where(b => b.REGIONCODE == x.Key.REGIONCODE).GroupBy(b => b.CUSTOMERCODE).Count() }).ToList();
                dgvSortInfo.DataSource = scre.Content.Select(x => new { synseq=x.SYNSEQ,regioncode=x.REGIONCODE,count=x.Count,qty=x.QTY}).ToList();
                //{
                //    车组信息 = a.REGIONCODE,
                //    任务数 = scre.Content.Where(b => b.REGIONCODE == a.REGIONCODE).Sum(c => c.TASKQUANTITY),
                //    状态 = a.STATE,
                //    订单日期 = a.ORDERDATE
                //}).ToList();
            }
            else
            {
                dgvSortInfo.AutoGenerateColumns = false;
                dgvSortInfo.DataSource = new List<TaskInfo>();
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
            times = 1;//时间重置 
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

                if (re.IsSuccess)
                {
                    btnPokeSeq.Enabled = true;
                    progressBar1.Value = progressBar1.Maximum;
                    TimerByTime.Stop();// 计时结束;
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
            catch (Exception e)
            {
                MessageBox.Show("排程异常:" + e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
            finally
            { 
                //times = 1;
                Bind();
                panel2.Visible = false;
                TimerByTime.Stop();// 计时结束;
                btnSort.Enabled = true; 
            }

        }

        private void btn_replenishplan_Click(object sender, EventArgs e)
        {
            Replan plan = new Replan();
            Boolean flag=plan.AutoGenReplan();
            if (flag)
            {
                MessageBox.Show("补货计划生成成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("补货计划生成失败，请联系系统管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TimerByTime_Tick(object sender, EventArgs e)
        {
            times = times + 1;
            lblTime.Text = "已用时间:" + times + "秒";
        }

    }
}
