using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Business.BusinessClass;
using Business;
using Business.Modle;
using HighspeedNew.OrderHandle;
using System.Transactions;
using System.Configuration;

namespace HighSpeed.OrderHandle
{
    public partial class win_schedule : Form
    {
        w_main wm = new w_main();
        public delegate void HandleScheduleing(int falge, bool isOrnot);

        List<string> regionSort = new List<string>();

        public win_schedule()
        {
            InitializeComponent();
            string str = ConfigurationManager.AppSettings["RegionSort"].ToString();
            regionSort = str.Split(',').ToList();
            Bind();

        }
        ScheduleClass sc = new ScheduleClass();
        void Bind()
        {
            var re = sc.GetRouteInFO(regionSort);
            if (re.IsSuccess)
            {
                orderdata.DataSource = re.Content.Select(x => new { x.SYNSEQ, x.REGIONCODE, x.Count, x.QTY }).ToList();
                LblOrderCount.Text = "总订单量：" + re.Content.Sum(item => item.QTY).ToString();
                LblCusCount.Text = "总订货户数：" + re.Content.Sum(item => item.Count).ToString();
            }
            else
            {
                orderdata.AutoGenerateColumns = false;
                orderdata.DataSource = new List<TaskInfo>();
                LblOrderCount.Text = "总订单量：0";
                LblCusCount.Text = "总订货户数：0";
            }
            this.txt_codestr.Text = "";
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Bind();
        }

        private void orderdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (orderdata.Rows.Count > 0)
            {
                if (e.ColumnIndex == 0)
                {
                    if (orderdata.RowCount > 0)
                    {
                        bool obj = (bool)this.orderdata.CurrentRow.Cells[0].EditedFormattedValue;
                        //MessageBox.Show(obj);

                        String czcode = this.orderdata.CurrentRow.Cells[2].Value + "";
                        //MessageBox.Show(obj.ToString());
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
            }

        }

        private void btn_schedule_Click(object sender, EventArgs e)
        {
            try
            {
                String codestr = this.txt_codestr.Text.Trim();
                string indexstr = "";
                if (codestr != "")
                {
                    //预排程前进行数据校验，包括通道和品牌设置等
                    ValidationClass vc = new ValidationClass();
                    Response response = vc.ValidationSchedule("1");

                    response.IsSuccess = true;


                    btn_schedule.Enabled = false;
                    String[] code = codestr.Substring(1).Split(',');
                    //int len = code.Length;
                    Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
                    w_SortStrategy frm = new w_SortStrategy();
                    frm.ShowDialog();
                    if (frm.Index >= 0)
                        dic = SortStrategy(frm.Index, code);
                    else
                    {
                        MessageBox.Show("请选择排程策略");
                        return;
                    }
                    if (response.IsSuccess)
                    {
                        DialogResult MsgBoxResult = MessageBox.Show("车组排程顺序为【" + codestr.Substring(1) + "】，是否确定按照该顺序进行预排程？",//对话框的显示内容 
                                                                           "提示",//对话框的标题 
                                                                           MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                                                                           MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                                                                           MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
                        if (MsgBoxResult == DialogResult.Yes)
                        {
                            TransactionOptions transactionOption = new TransactionOptions();
                            transactionOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                            using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, transactionOption)) 
                            {
                                bool flag = true;
                                foreach (var item in dic)
                                {
                                    List<string> regions = new List<string>();
                                    regions = item.Value;
                                    for (int i = 0; i < regions.Count; i++)
                                    {
                                        panel2.Visible = true;
                                        label2.Visible = true;
                                        progressBar1.Visible = true;
                                        progressBar1.Value = 0;
                                        Application.DoEvents();
                                        if (i == 0) label2.Text = "正在对" + regions[i] + "车组的单条订单数据进行预排程...";
                                        var resc = sc.PreScheduleForSingleOrder(regions[i]);
                                        progressBar1.Value = ((i + 1) * 100 / (regions.Count * 2));
                                        progressBar1.Refresh();
                                        String tmpstr = "";
                                        if (resc.IsSuccess)
                                        {
                                            if (i + 1 < regions.Count) tmpstr = "正在对" + regions[i + 1] + "车组单条订单数据进行预排程...";
                                            else tmpstr = "";
                                            label2.Text = regions[i] + "车组单条订单数据预排程结束..." + tmpstr;
                                            label2.Refresh();
                                            indexstr = indexstr + "," + regions[i];
                                        }
                                        else
                                        {
                                            label2.Text = resc.MessageText;
                                            label2.Refresh();
                                            flag = false;
                                            break;
                                        }
                                    }
                                    
                                    for (int i = 0; i < regions.Count; i++)
                                    {
                                        panel2.Visible = true;
                                        label2.Visible = true;
                                        progressBar1.Visible = true;
                                        progressBar1.Value = 0;
                                        Application.DoEvents();
                                        if (i == 0) label2.Text = "正在对" + regions[i] + "车组订单数据进行预排程...";
                                        var resc = sc.PreSchedule(regions[i]);
                                        progressBar1.Value = ((regions.Count + i + 1) * 100 / (regions.Count * 2));
                                        progressBar1.Refresh();
                                        String tmpstr = "";
                                        if (resc.IsSuccess)
                                        {
                                            if (i + 1 < regions.Count) tmpstr = "正在对" + regions[i + 1] + "车组订单数据进行预排程...";
                                            else tmpstr = "";
                                            label2.Text = regions[i] + "车组订单数据预排程结束..." + tmpstr;
                                            label2.Refresh();
                                            indexstr = indexstr + "," + regions[i];
                                        }
                                        else
                                        {
                                            label2.Text = resc.MessageText;
                                            label2.Refresh();
                                            flag = false;
                                            break;
                                        }  
                                    }
                                }
                                if (flag)
                                    tran.Complete();
                                else
                                    MessageBox.Show("预排程错误，事务回滚");
                            }
                           
                            
                            panel2.Visible = false;
                            label2.Visible = false;
                            progressBar1.Visible = false;
                            MessageBox.Show("预排程成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.MessageText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("请至少选择一个要预排程的车组!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                panel2.Visible = false;
                label2.Visible = false;
                progressBar1.Visible = false;
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                btn_schedule.Enabled = true;
                Bind();
            }


            //try
            //{
            //    String codestr = this.txt_codestr.Text.Trim();
            //    string indexstr = "";
            //    if (codestr != "")
            //    {
            //        //预排程前进行数据校验，包括通道和品牌设置等
            //        ValidationClass vc = new ValidationClass();
            //        Response response = vc.ValidationSchedule("1");
            //        if (response.IsSuccess)
            //        {
            //            DialogResult MsgBoxResult = MessageBox.Show("车组排程顺序为【" + codestr.Substring(1) + "】，是否确定按照该顺序进行预排程？",//对话框的显示内容 
            //                                                               "提示",//对话框的标题 
            //                                                               MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
            //                                                               MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
            //                                                               MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
            //            if (MsgBoxResult == DialogResult.Yes)
            //            {
            //                btn_schedule.Enabled = false;
            //                String[] code = codestr.Substring(1).Split(',');
            //                int len = code.Length;

            //                for (int i = 0; i < len; i++)
            //                {
            //                    panel2.Visible = true;
            //                    label2.Visible = true;
            //                    progressBar1.Visible = true;
            //                    progressBar1.Value = 0;
            //                    Application.DoEvents();
            //                    if (i == 0) label2.Text = "正在对" + code[i] + "车组的单条订单数据进行预排程...";
            //                    var resc = sc.PreScheduleForSingleOrder(code[i]);
            //                    progressBar1.Value = ((i + 1) * 100 / (len * 2));
            //                    progressBar1.Refresh();
            //                    String tmpstr = "";
            //                    if (resc.IsSuccess)
            //                    {
            //                        if (i + 1 < len) tmpstr = "正在对" + code[i + 1] + "车组单条订单数据进行预排程...";
            //                        else tmpstr = "";
            //                        label2.Text = code[i] + "车组单条订单数据预排程结束..." + tmpstr;
            //                        label2.Refresh();
            //                        indexstr = indexstr + "," + code[i];
            //                    }
            //                    else
            //                    {
            //                        label2.Text = resc.MessageText;
            //                        label2.Refresh();
            //                        break;
            //                    }
            //                }
            //                for (int i = 0; i < len; i++)
            //                {
            //                    //panel2.Visible = true;
            //                    //label2.Visible = true;
            //                    //progressBar1.Visible = true;
            //                    //progressBar1.Value = 0;
            //                    //Application.DoEvents();
            //                    if (i == 0) label2.Text = "正在对" + code[i] + "车组订单数据进行预排程...";
            //                    var resc = sc.PreSchedule(code[i]);
            //                    progressBar1.Value = ((len + i + 1) * 100 / (len * 2));
            //                    progressBar1.Refresh();
            //                    String tmpstr = "";
            //                    if (resc.IsSuccess)
            //                    {
            //                        if (i + 1 < len) tmpstr = "正在对" + code[i + 1] + "车组订单数据进行预排程...";
            //                        else tmpstr = "";
            //                        label2.Text = code[i] + "车组订单数据预排程结束..." + tmpstr;
            //                        label2.Refresh();
            //                        indexstr = indexstr + "," + code[i];
            //                    }
            //                    else
            //                    {
            //                        label2.Text = resc.MessageText;
            //                        label2.Refresh();
            //                        break;
            //                    }
            //                }
            //                panel2.Visible = false;
            //                label2.Visible = false;
            //                progressBar1.Visible = false;
            //                MessageBox.Show("预排程成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show(response.MessageText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("请至少选择一个要预排程的车组!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    panel2.Visible = false;
            //    label2.Visible = false;
            //    progressBar1.Visible = false;
            //    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    btn_schedule.Enabled = true;
            //    Bind();
            //}
        }
        Dictionary<string,List<string>> SortStrategy(int index,string []code) 
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            switch (index) 
            {
                case 0:
                    List<string> list1 = new List<string>();
                    for (int i = 0; i < code.Length; i++)
                    {
                        list1.Add(code[i]);
                    }
                    dic.Add("1", list1);
                    break;
                case 1:
                    List<string> area = new List<string>();
                    area = RegionSort.GetArea();
                    for (int i = 0; i < area.Count; i++)
                    {
                        List<string> region = new List<string>();

                        for (int j = 0; j < this.orderdata.RowCount; j++)
                        {
                            orderdata.Rows[j].Cells[0].Value = "true";
                            string regioncode = orderdata.Rows[j].Cells[2].Value.ToString();
                            if (regioncode.Contains(area[i]))
                                region.Add(regioncode);
                        }
                        dic.Add(area[i], region);
                    }
                    
                    break;
                case 2:
                    
                    for (int i = 0; i < code.Length; i++)
                    {
                        List<string> list2 = new List<string>();
                        list2.Add(code[i]);
                        dic.Add(i.ToString(), list2);
                    }
                    break;
            }
            return dic;
        }
        private void btn_all_Click(object sender, EventArgs e)
        {
            //dic = new Dictionary<string, List<string>>();
            //List<string> area = RegionSort.GetArea();
            //for (int i = 0; i < area.Count; i++)
            //{
            //    List<string> region = new List<string>();
                
            //    for (int j = 0; j < this.orderdata.RowCount; j++)
            //    {
            //        orderdata.Rows[j].Cells[0].Value = "true";
            //        string regioncode = orderdata.Rows[j].Cells[2].Value.ToString();
            //        if (regioncode.Contains(area[i]))
            //            region.Add(regioncode);
            //    }
            //    dic.Add(area[i], region);
            //}









            String czcodestr = "";
            for (int i = 0; i < this.orderdata.RowCount; i++)
            {
                orderdata.Rows[i].Cells[0].Value = "true";
                czcodestr = czcodestr + "," + orderdata.Rows[i].Cells[2].Value + "";
            }
            this.txt_codestr.Text = czcodestr;
        }

    }
}
