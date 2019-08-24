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

namespace HighspeedNew.OrderHandle
{
    public partial class w_Through : Form
    {
        public string sign;
        public string amend_id;
        public w_Through()
        {
            InitializeComponent();
            box_condition.SelectedIndex = 0;
            Bind();
        }

        public void init()
        {
            //初始化查询条件下拉框
            DataTable conditiontable = new DataTable();
            conditiontable.Columns.Add("value", typeof(string));
            conditiontable.Columns.Add("txtvalue", typeof(string));

            DataRow dr = conditiontable.NewRow();
            dr["value"] = "cigarettecode";
            dr["txtvalue"] = "品牌代码";

            DataRow dr1 = conditiontable.NewRow();
            dr1["value"] = "cigarettename";
            dr1["txtvalue"] = "品牌名称";

            conditiontable.Rows.Add(dr);
            conditiontable.Rows.Add(dr1);

            this.box_condition.DataSource = conditiontable;
            this.box_condition.DisplayMember = "txtvalue";
            this.box_condition.ValueMember = "value";
            this.box_condition.SelectedIndex = 1;

            //初始化启停按钮状态
            this.btn_qy.Enabled = false;
            this.btn_jy.Enabled = false;
        }
        List<ThroughInfo> list;
        void Bind()
        {
            List<decimal> groupNo = new List<decimal>();
            list = new List<ThroughInfo>();
            if (CBGroup1.Checked)
                groupNo.Add(1);
            if (CBGroup2.Checked)
                groupNo.Add(2);
            if (CBGroup3.Checked)
                groupNo.Add(3);
            if (!CBGroup1.Checked && !CBGroup2.Checked && !CBGroup3.Checked)
            {
                groupNo.Add(2);
                CBGroup2.CheckState = CheckState.Checked;
            }
            list = ThroughClass.GetThroughInfo(box_condition.SelectedIndex, groupNo, txt_keywd.Text);

            this.troughdata.DataSource = list;
            this.troughdata.AutoGenerateColumns = false;

            //string columnwidths = pub.IniReadValue(this.Name, this.troughdata.Name);
            //if (columnwidths != "")
            //{
            //    string[] columns = columnwidths.Split(',');
            //    int j = 0;
            //    for (int i = 0; i < columns.Length; i++)
            //    {
            //        if (troughdata.Columns[i].Visible == true)
            //        {
            //            troughdata.Columns[j].Width = Convert.ToInt32(columns[i]);
            //            j = j + 1;
            //        }
            //    }
            //}
            troughdata.ClearSelection();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Bind();
        }

        private void btn_qy_Click(object sender, EventArgs e)
        {
            int count = this.troughdata.SelectedRows.Count;
            if (count > 0)
            {
                if (troughdata.CurrentRow.Cells["State"].Value.ToString() == "正常")
                {
                    MessageBox.Show("该通道已是启用状态");
                    return;
                }
                ThroughInfo info = new ThroughInfo();
                info.ID = (decimal)this.troughdata.SelectedRows[0].Cells["ID"].Value;
                try
                {
                    info.CigaretteCode = this.troughdata.SelectedRows[0].Cells["CigaretteCode"].Value.ToString();
                }
                catch
                {
                    MessageBox.Show("请先给该通道设置品牌");
                    return;
                }
                info.CigaretteType = decimal.Parse(this.troughdata.CurrentRow.Cells["CigaretteType"].Value + "");
                info.MachineSeq = (decimal)this.troughdata.SelectedRows[0].Cells["MachineSeq"].Value;
                info.ThroughNum = this.troughdata.SelectedRows[0].Cells["ThroughNum"].Value.ToString();
                info.GroupNo = (decimal)this.troughdata.CurrentRow.Cells["GroupNo"].Value;

                DialogResult MsgBoxResult = MessageBox.Show("确定启用【设备号：" + info.MachineSeq + "/通道号：" + info.ThroughNum + "】通道吗？",//对话框的显示内容 
                                                            "提示",//对话框的标题 
                                                            MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                                                            MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                                                            MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
                if (MsgBoxResult == DialogResult.Yes)
                {
                    if (info.GroupNo == 10 || info.GroupNo == 20)
                    {
                        if (info.CigaretteCode == null || info.CigaretteCode == "")
                        {
                            MessageBox.Show("请选择品牌再启用通道.");
                            return;
                        }
                    }

                    try
                    {
                        info.State = "10";
                        ThroughClass.UpdateThroughState(info);
                        ThroughClass.SetThroughActcount(info.CigaretteCode, info.GroupNo);
                        MessageBox.Show("【设备号：" + info.MachineSeq + "/通道号：" + info.ThroughNum + "】的通道已启用!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bind();
                    }
                    catch (Exception se)
                    {
                        MessageBox.Show(se.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("请点击选择您要启用的设备通道!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_jy_Click(object sender, EventArgs e)
        {
            int count = this.troughdata.SelectedRows.Count;

            if (count > 0)
            {
                ThroughInfo info = new ThroughInfo();
                info.ID = (decimal)this.troughdata.SelectedRows[0].Cells["ID"].Value;
                info.CigaretteCode = this.troughdata.SelectedRows[0].Cells["CigaretteCode"].Value.ToString();
                info.CigaretteType = decimal.Parse(this.troughdata.CurrentRow.Cells["CigaretteType"].Value + "");
                info.MachineSeq = (decimal)this.troughdata.SelectedRows[0].Cells["MachineSeq"].Value;
                info.ThroughNum = this.troughdata.SelectedRows[0].Cells["ThroughNum"].Value.ToString();
                info.GroupNo = (decimal)this.troughdata.CurrentRow.Cells["GroupNo"].Value;

                DialogResult MsgBoxResult = MessageBox.Show("确定禁用【设备号：" + info.MachineSeq + "/通道号：" + info.ThroughNum + "】通道吗？",//对话框的显示内容 
                                                             "提示",//对话框的标题 
                                                             MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                                                             MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                                                             MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
                if (MsgBoxResult == DialogResult.Yes)
                {
                    try
                    {
                        info.State = "0";
                        ThroughClass.UpdateThroughState(info);
                        ThroughClass.SetThroughActcount(info.CigaretteCode, info.GroupNo);
                        MessageBox.Show("【设备号：" + info.MachineSeq + "/通道号：" + info.ThroughNum + "】的通道已禁用!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bind();

                    }
                    catch (Exception se)
                    {
                        MessageBox.Show(se.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("请点击选择您要禁用的分拣通道!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            w_Through_Handle trough_handle = new w_Through_Handle("0", "0", "30", "10", "", 0, "0");
            trough_handle.WindowState = FormWindowState.Normal;
            trough_handle.StartPosition = FormStartPosition.CenterScreen;
            trough_handle.ShowDialog();
        }

        private void btn_amend_Click(object sender, EventArgs e)
        {
            int count = this.troughdata.SelectedRows.Count;
            if (count > 0)
            {
                String type = this.troughdata.CurrentRow.Cells["GroupNo"].Value + "";
                if (type.Equals("30") || type.Equals("40"))
                {
                    return;
                }
                amend_id = this.troughdata.SelectedRows[0].Cells["id"].Value.ToString();
                sign = "1";
                String cigarettetype = this.troughdata.CurrentRow.Cells["cigarettetype"].Value + "";
                String type1 = this.troughdata.CurrentRow.Cells["GroupNo"].Value + "";
                String id = this.troughdata.CurrentRow.Cells["ID"].Value + "";
                string machineSeq = this.troughdata.CurrentRow.Cells["MachineSeq"].Value + "";
                //decimal groupNo = Convert.ToDecimal(this.troughdata.CurrentRow.Cells["groupNo"].Value);
                decimal groupNo = 0;
                groupNo = (decimal)this.troughdata.CurrentRow.Cells["GroupNo"].Value;
                //if (tt == "特异形烟")
                //    groupNo = 1;
                //else if (tt == "立式烟仓")
                //    groupNo = 2;
                //else
                //    groupNo = 3;
                string lastCigarettecode = "";
                try
                {
                    lastCigarettecode = this.troughdata.CurrentRow.Cells["cigarettecode"].Value.ToString();
                }
                catch { }



                w_Through_Handle trough_handle = new w_Through_Handle(sign, amend_id, cigarettetype, type1, machineSeq, groupNo, lastCigarettecode);
                trough_handle.WindowState = FormWindowState.Normal;
                trough_handle.StartPosition = FormStartPosition.CenterScreen;
                trough_handle.ShowDialog();
                Bind();
            }
            else
            {
                MessageBox.Show("请点击选择您要修改的设备通道!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void troughdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                String status = this.troughdata.CurrentRow.Cells["state"].Value + "";
                String type = this.troughdata.CurrentRow.Cells["type"].Value + "";
                String cigarettetype = this.troughdata.CurrentRow.Cells["ctype"].Value + "";
                //String groupno = this.troughdata.CurrentRow.Cells["groupno"].Value + "";
                //MessageBox.Show("===" + troughdata.RowCount);
                if (status == "10")
                {
                    this.btn_qy.Enabled = false;
                    this.btn_jy.Enabled = true;
                }
                else
                {
                    this.btn_qy.Enabled = true;
                    this.btn_jy.Enabled = false;
                }
                if (type == "20" || type == "30" || type == "40")//|| (type == "10" && cigarettetype != "20" && groupno == "3")  //移除三线烟仓（原异型烟烟柜）无法修改问题
                {
                    this.btn_amend.Enabled = false;
                }
                else
                {
                    this.btn_amend.Enabled = true;
                }
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            dgVprint1.MainTitle = "分拣通道信息";
            //dgVprint1.SubTitle = "这是子标题，当然也可以不设的";
            dgVprint1.PaperLandscape = true;//用横向打印，默认是纵向

            dgVprint1.Print(troughdata);
        }

        private void btn_toexcel_Click(object sender, EventArgs e)
        {
            dgVprint1.ExportDGVToExcel2(this.troughdata, "设备通道信息", "sorttroughInfo.xls", true);
        }
            
        private void troughdata_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (list[e.RowIndex].GroupNo == 1)
                {

                    e.Value = "特异型烟";
                }
                else if (list[e.RowIndex].GroupNo == 2)
                {
                    e.Value = "立式烟仓";
                }
                else
                {
                    e.Value = "卧式烟仓";
                }
            }
            if (e.ColumnIndex == 5) 
            {
                if (list[e.RowIndex].State == "禁用")
                {

                    troughdata.Rows[e.RowIndex].Cells[5].Style.BackColor = Color.Red;
                }
            }
            
           
           
        }
    }
}
