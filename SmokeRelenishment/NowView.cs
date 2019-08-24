using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Modle;
using Business.BusinessClass;
using Business;

namespace SmokeRelenishment
{
    public partial class NowView : Form
    {
        decimal nowpokeid;
        decimal lastpokeids;
        public NowView(string sortnum)
        {
            InitializeComponent();
            this.nowpokeid = Convert.ToDecimal(sortnum);
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="Seq"></param>
        /// <param name="pokeid"></param>

        public void DateBind(decimal Seq, string pokeid = null)
        {
            //HunheClass HunHeNowCigarette = new HunHeService_new();
            List<T_PRODUCE_REPLENISHPLAN> list = RelenishimentClass.GetReplenishplan();
            if (list.Count < 1)
            {
                //labMachineSeq.Text = Seq + "通道没有分拣数据，请选择其他通道！";
            }
            //DgvNowView.DataSource = null;
            DgvNowView.DataSource = list;


        }

        string lastpokeid;
        /// <summary>
        /// 定位当前条目
        /// </summary>
        /// <param name="nowpokeids"></param>
        private void NowPoke(decimal nowpokeid, bool falg)
        {

            string pokeid;


            pokeid = nowpokeid.ToString();

            //若两次的pokeid不同 重置标志位 重选行
            if (lastpokeid != pokeid)
            {
                falg = true;
            }
            //判断当前pokeid是否等于上一个
            if (!string.IsNullOrEmpty(pokeid) && (lastpokeid != pokeid || falg))
            {

                DateBind(1);

                for (int i = 0; i < DgvNowView.RowCount; i++)
                {
                    string sendtasknum1 = DgvNowView.Rows[i].Cells["TASKNUM"].Value.ToString().Trim();//sendtasknum 包号 
                    if (sendtasknum1 == pokeid)
                    {
                        foreach (DataGridViewRow row in DgvNowView.Rows)
                        {
                            row.Selected = false;
                        }
                        DgvNowView.Rows[i].Selected = true;
                        DgvNowView.FirstDisplayedScrollingRowIndex = i;

                    }
                }
                lastpokeids = Convert.ToDecimal(pokeid);
                falg = false;
            }
        }

        private void btnNowPoke_Click(object sender, EventArgs e)
        {
            DateBind(1, nowpokeid.ToString());
            NowPoke(nowpokeid, true);
        }
    }
}
