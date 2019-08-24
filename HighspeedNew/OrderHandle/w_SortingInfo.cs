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

namespace HighspeedNew.OrderHandle
{
    public partial class w_SortingInfo : Form
    {
        public w_SortingInfo()
        {
            InitializeComponent();
            Bind();
        }
        List<SortInfo> list = null;
        void Bind()
        {
            try
            {
                list = new List<SortInfo>();
                list = SortClass.GetSortInfo();

                if (list.Count > 0)
                {
                    SortInfo lishi = list.Where(item => item.Ctype == 2).GroupBy(item => item.Ctype).Select(item => new SortInfo { Ctype = 0, CigaretteCode = "立式烟仓", CigaretteName = "立式烟仓分拣进度", MachineSeq = 0, SortedNum = item.Sum(x => x.SortedNum), TotalNum = item.Sum(x => x.TotalNum), UnSortNum = item.Sum(x => x.UnSortNum) }).FirstOrDefault();
                    SortInfo woshi = list.Where(item => item.Ctype == 3).GroupBy(item => item.Ctype).Select(item => new SortInfo { Ctype = 0, CigaretteCode = "卧式烟仓", CigaretteName = "卧式烟仓分拣进度", MachineSeq = 0, SortedNum = item.Sum(x => x.SortedNum), TotalNum = item.Sum(x => x.TotalNum), UnSortNum = item.Sum(x => x.UnSortNum) }).FirstOrDefault();
                    SortInfo teyixing = list.Where(item => item.Ctype == 1).GroupBy(item => item.Ctype).Select(item => new SortInfo { Ctype = 0, CigaretteCode = "特异型烟道", CigaretteName = "特异型烟道分拣进度", MachineSeq = 0, SortedNum = item.Sum(x => x.SortedNum), TotalNum = item.Sum(x => x.TotalNum), UnSortNum = item.Sum(x => x.UnSortNum) }).FirstOrDefault();

                    SortInfo zongshu = new SortInfo()
                    {
                        SortedNum = list.Sum(item => item.SortedNum),
                        UnSortNum = list.Sum(item => item.UnSortNum),
                        TotalNum = list.Sum(item => item.TotalNum),
                        Ctype = 0,
                        MachineSeq = 0,
                        CigaretteCode = "总分拣量",
                        CigaretteName = "总分拣量"
                    };

                    list.Insert(0, zongshu);

                    if (lishi != null)
                        list.Insert(1, lishi);
                    if (woshi != null)
                        list.Insert(2, woshi);
                    if (teyixing != null)
                        list.Insert(3, teyixing);

                    DgvSort.DataSource = list.OrderBy(item => item.MachineSeq).OrderBy(item => item.Ctype).ToList();
                }
                else
                {
                    DgvSort.DataSource = list;
                    MessageBox.Show("当前没有分拣数据");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DgvSort_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    if (list[e.RowIndex].Ctype == 1)
            //    {
            //        e.Value = "特异型烟";
            //    }
            //    else if (list[e.RowIndex].Ctype == 2)
            //    {
            //        if (list[e.RowIndex].MachineSeq == 90)
            //            e.Value = "立式烟仓混合道";
            //        else
            //            e.Value = "立式烟仓";
            //    }
            //    else if (list[e.RowIndex].Ctype == 3)
            //    {
            //        e.Value = "卧式烟仓";
            //    }
            //    else
            //    {

            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}
