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

namespace HighSpeed.OrderHandle
{
    public partial class win_schedule : Form
    { 
        w_main wm = new w_main();
        public delegate void HandleScheduleing(int falge,bool isOrnot);
      
        public win_schedule()
        {
            InitializeComponent();
            Bind();
            
        }
        ScheduleClass sc = new ScheduleClass();
        void Bind()
        {
            var re = sc.GetRouteInFO()  ;
            if (re.IsSuccess)
            {
                orderdata.DataSource = re.Content.Select(a => new { 车组信息 = a.REGIONCODE, 订单户数 = re.Content.Where(b => b.REGIONCODE == a.REGIONCODE).Count(), 订单数量 = re.Content.Where(c => c.REGIONCODE == a.REGIONCODE).Sum(d => d.ORDERQUANTITY) }).ToList();
            }
            else
            {
                orderdata.DataSource = null;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Bind();
        }

        private void orderdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void btn_schedule_Click(object sender, EventArgs e)
        {
            try
            {

           
            String codestr = this.txt_codestr.Text.Trim();
          string indexstr = "";
            if (codestr != "")
            {
                 DialogResult MsgBoxResult = MessageBox.Show("车组排程顺序为【" + codestr.Substring(1) + "】，是否确定按照该顺序进行预排程？",//对话框的显示内容 
                                                                    "提示",//对话框的标题 
                                                                    MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                                                                    MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                                                                    MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
                 if (MsgBoxResult == DialogResult.Yes)
                 {
                     btn_schedule.Enabled = false;
                     String[] code = codestr.Substring(1).Split(',');
                     int len = code.Length;
                     for (int i = 0; i < len; i++)
                     {
                         panel2.Visible = true;
                         label2.Visible = true;
                         progressBar1.Visible = true; 
                         progressBar1.Value = 0;
                         Application.DoEvents();
                         if (i == 0) label2.Text = "正在对" + code[i] + "车组订单数据进行预排程..."; 
                        var resc =  sc.PreSchedule(code[i]); 
                         progressBar1.Value = ((i + 1) * 100 / len);
                         progressBar1.Refresh();
                         String tmpstr = "";
                         if (resc.IsSuccess)
                         {
                             if (i + 1 < len) tmpstr = "正在对" + code[i + 1] + "车组订单数据进行预排程...";
                             else tmpstr = "";
                             label2.Text = code[i] + "车组订单数据预排程结束..." + tmpstr;
                             label2.Refresh();
                             indexstr = indexstr + "," + code[i];
                         }
                         else
                         {
                             label2.Text = resc.MessageText;
                             label2.Refresh();
                             break;
                         }
                     }
                     panel2.Visible = false;
                     label2.Visible = false;
                     progressBar1.Visible = false;
                     MessageBox.Show("预排程成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
            } 
            else
            {
                MessageBox.Show("请至少选择一个要预排程的车组!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally{
                Bind();
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

    }
}
