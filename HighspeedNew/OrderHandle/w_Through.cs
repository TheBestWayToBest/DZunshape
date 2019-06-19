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
        public w_Through()
        {
            InitializeComponent();
            
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

        void Bind() 
        {
            List<ThroughInfo> list = new List<ThroughInfo>();
            list = ThroughClass.GetThroughInfo(box_condition.SelectedIndex, txt_keywd.Text);

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
                ThroughInfo info = new ThroughInfo();
                info.ID = (decimal)this.troughdata.SelectedRows[0].Cells["ID"].Value;
                //string desc = this.troughdata.SelectedRows[0].Cells[9].Value.ToString();
                info.CigaretteCode = this.troughdata.SelectedRows[0].Cells["CigaretteCode"].Value.ToString();
                info.CigeretteType = this.troughdata.CurrentRow.Cells["CigeretteType"].Value + "";
                info.ThroughType = this.troughdata.CurrentRow.Cells["ThroughType"].Value + "";
                info.MachineSeq = (decimal)this.troughdata.SelectedRows[0].Cells["MachineSeq"].Value;
                info.ThroughNum = this.troughdata.SelectedRows[0].Cells["ThroughNum"].Value.ToString();
                DialogResult MsgBoxResult = MessageBox.Show("确定启用【设备号：" + info.MachineSeq + "/通道号：" + info.ThroughNum + "】通道吗？",//对话框的显示内容 
                                                            "提示",//对话框的标题 
                                                            MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                                                            MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                                                            MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
                if (MsgBoxResult == DialogResult.Yes)
                {
                    if (info.ThroughType == "10" || info.ThroughType == "20")
                    {
                        if (info.CigaretteCode == null || info.CigaretteCode == "")
                        {
                            MessageBox.Show("请选择品牌再启用通道.");
                            return;

                        }
                    }
                    
                    try
                    {
                        info.State="10";
                        ThroughClass.UpdateThroughState(info);
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
                //string desc = this.troughdata.SelectedRows[0].Cells[9].Value.ToString();
                info.CigaretteCode = this.troughdata.SelectedRows[0].Cells["CigaretteCode"].Value.ToString();
                info.CigeretteType = this.troughdata.CurrentRow.Cells["CigeretteType"].Value + "";
                info.ThroughType = this.troughdata.CurrentRow.Cells["ThroughType"].Value + "";
                info.MachineSeq = (decimal)this.troughdata.SelectedRows[0].Cells["MachineSeq"].Value;
                info.ThroughNum = this.troughdata.SelectedRows[0].Cells["ThroughNum"].Value.ToString();
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
    }
}
