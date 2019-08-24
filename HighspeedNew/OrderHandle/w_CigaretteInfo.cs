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


namespace HighSpeed.OrderHandle
{
    public partial class w_CigaretteInfo : Form
    {
        List<ItemInfo> itemInfos = new List<ItemInfo>();
        List<ItemInfo> list = new List<ItemInfo>();
        bool loadState = false;
        public w_CigaretteInfo()
        {
            InitializeComponent();
            box_type.SelectedIndex = 0;
            Bind();
        }
        void Bind()
        {
            loadState = false;
            DgvItemInfo.Rows.Clear();
            string shipType = "1";
            decimal status = 10;
            if (RB0.Checked)
                status = 0;
            else
                status = 10;
            if (RBUnnormal.Checked)
                shipType = "1";
            else
                shipType = "0";
            itemInfos = ItemClass.GetItemInfo(box_type.SelectedIndex, shipType, status, txt_keywd.Text.Trim());
            DgvItemInfo.AutoGenerateColumns = false;
            //DgvItemInfo.DataSource = itemInfos
            foreach (var item in itemInfos)
            {
                DataGridViewCellStyle dgvStyle = new DataGridViewCellStyle();
                dgvStyle.BackColor = Color.LightGreen;
                // 存了状态值  
                int index = this.DgvItemInfo.Rows.Add();
                this.DgvItemInfo.Rows[index].Cells[0].Value = item.ItemNo;
                this.DgvItemInfo.Rows[index].Cells[1].Value = item.ItemName;

                this.DgvItemInfo.Rows[index].Cells[2].Value = item.BigBox_Bar;
                if (item.Shiptype == "0")
                    this.DgvItemInfo.Rows[index].Cells[3].Value = false;
                else if (item.Shiptype == "1")
                    this.DgvItemInfo.Rows[index].Cells[3].Value = true;
                else
                {
                    item.Shiptype = "0";
                    list.Add(item);
                    dgvStyle.BackColor = Color.Yellow;
                    this.DgvItemInfo.Rows[index].Cells[3].Value = false;
                    for (int i = 0; i < DgvItemInfo.Rows[index].Cells.Count; i++)
                    {
                        DgvItemInfo.Rows[index].Cells[i].Style = dgvStyle;
                    }
                }
                //this.DgvItemInfo.Rows[index].Cells[4].Value = item.RowStatus;
                if (item.RowStatus == 10)
                    this.DgvItemInfo.Rows[index].Cells[4].Value = true;
                else
                    this.DgvItemInfo.Rows[index].Cells[4].Value = false;
                this.DgvItemInfo.Rows[index].Cells[5].Value = item.ILength;
                this.DgvItemInfo.Rows[index].Cells[6].Value = item.IWidth;
                this.DgvItemInfo.Rows[index].Cells[7].Value = item.IHeight;
                this.DgvItemInfo.Rows[index].Cells[8].Value = item.JT_Size;
            }
            DgvItemInfo.EndEdit();
            loadState = true;
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (list.Count > 0) 
            {
                MessageBox.Show("请保存更改后再查询其他");
                return;
            }
            Bind();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            dgVprint1.ExportDGVToExcel2(DgvItemInfo, "卷烟基础信息", "cigaretteInfo.xls", true);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {

            dgVprint1.MainTitle = "卷烟信息表";
            // dgVprint1.SubTitle = "这是子标题，当然也可以不设的";
            dgVprint1.PaperLandscape = true;//用横向打印，默认是纵向哦
            dgVprint1.Print(DgvItemInfo);
        }

        private void DgvItemInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loadState) 
            {
                try
                {
                    ItemInfo item = new ItemInfo();
                    item.ItemNo = DgvItemInfo.CurrentRow.Cells["ItemNo"].Value.ToString();
                    item.ItemName = DgvItemInfo.CurrentRow.Cells["ItemName"].Value.ToString();
                    item.ILength = Convert.ToDecimal(DgvItemInfo.CurrentRow.Cells["ILength"].Value);
                    item.IWidth = Convert.ToDecimal(DgvItemInfo.CurrentRow.Cells["IWidth"].Value);
                    item.IHeight = Convert.ToDecimal(DgvItemInfo.CurrentRow.Cells["IHEIGHT"].Value);
                    try { item.BigBox_Bar = DgvItemInfo.CurrentRow.Cells["BigBox_Bar"].Value.ToString(); }
                    catch { item.BigBox_Bar = "0"; }
                    
                    item.JT_Size = Convert.ToDecimal(DgvItemInfo.CurrentRow.Cells["JZ_Size"].Value);
                    if ((bool)DgvItemInfo.CurrentRow.Cells["Type"].EditedFormattedValue == true)
                        item.Shiptype = "1";
                    else
                        item.Shiptype = "0";
                    if ((bool)DgvItemInfo.CurrentRow.Cells["status"].EditedFormattedValue == true)
                        item.RowStatus = 10;
                    else
                        item.RowStatus = 0;
                    list.Add(item);
                    DgvItemInfo.CurrentRow.Cells[e.ColumnIndex].Style.BackColor = Color.LightBlue;
                }
                catch (FormatException ex) 
                {
                    DgvItemInfo.CurrentRow.Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                    MessageBox.Show(ex.Message);
                }
            }
            #region
            //if (itemInfos.Count < 0)
            //{
            //    try
            //    {
            //        DialogResult result = MessageBox.Show("确定要修改吗?",//对话框的显示内容 
            //                                                   "操作提示",//对话框的标题 
            //                                                   MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
            //                                                   MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 

            //                                                   MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
            //        if (result == DialogResult.Yes) 
            //        {
            //            ItemInfo item = new ItemInfo();

            //            item.ItemNo = DgvItemInfo.CurrentRow.Cells["ItemNo"].Value.ToString();
            //            item.ItemName = DgvItemInfo.CurrentRow.Cells["ItemName"].Value.ToString();
            //            item.ILength = Convert.ToDecimal(DgvItemInfo.CurrentRow.Cells["ILength"].Value);
            //            item.IWidth = Convert.ToDecimal(DgvItemInfo.CurrentRow.Cells["IWidth"].Value);
            //            item.IHeight = Convert.ToDecimal(DgvItemInfo.CurrentRow.Cells["IHEIGHT"].Value);
            //            item.BigBox_Bar = DgvItemInfo.CurrentRow.Cells["BigBox_Bar"].Value.ToString();
            //            item.JT_Size = Convert.ToDecimal(DgvItemInfo.CurrentRow.Cells["JZ_Size"].Value);

            //            if (DgvItemInfo.CurrentRow.Cells["Type"].EditedFormattedValue.ToString() == "标准烟")
            //                item.Shiptype = "0";
            //            else
            //                item.Shiptype = "1";
            //            if (DgvItemInfo.CurrentRow.Cells["status"].EditedFormattedValue.ToString() == "正常")
            //                item.RowStatus = 10;
            //            else
            //                item.RowStatus = 0;

            //            if (ItemClass.UpdateItemInfo(item))
            //            {

            //                itemInfos = new List<ItemInfo>();
            //                DgvItemInfo.DataSource = itemInfos;
            //                Bind(); 
            //                MessageBox.Show("卷烟品牌信息修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("卷烟品牌信息修改失败!" + ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //DgvItemInfo.
            //if (e.ColumnIndex == 3)
            //{
            //    if (itemInfos[e.RowIndex].Shiptype == "0")
            //    {
            //        (sender as DataGridViewCheckBoxColumn).Selected = false;
            //        e.Value = true;
            //    }
            //    else if (itemInfos[e.RowIndex].Shiptype == "1")
            //    {
            //        (sender as DataGridViewCheckBoxColumn)
            //         = false;

            //    }
            //}
            //this.DgvItemInfo.CurrentCell = null;
            #endregion
        }
       

        private void DgvItemInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               DgvItemInfo.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                   DgvItemInfo.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   DgvItemInfo.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void DgvItemInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (DgvItemInfo.Rows[e.RowIndex].IsNewRow) return;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (!ItemClass.UpdateItemInfo(item))
                    {
                        MessageBox.Show("保存修改失败！");
                        return;
                    }
                }
                MessageBox.Show("保存修改成功！");
                list.Clear();
                Bind();
            }
            else 
            {
                MessageBox.Show("请修改数据后再点击保存");
            }
        }
    }
}
