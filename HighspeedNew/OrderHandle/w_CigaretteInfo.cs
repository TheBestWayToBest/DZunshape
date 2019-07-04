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
        public w_CigaretteInfo()
        {
            InitializeComponent();
            box_type.SelectedIndex = 0;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            itemInfos = ItemClass.GetItemInfo(box_type.SelectedIndex, txt_keywd.Text.Trim());
            DgvItemInfo.AutoGenerateColumns = false;
            DgvItemInfo.DataSource = itemInfos;
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
            if (itemInfos.Count > 0)
            {
                try
                {
                    DialogResult result = MessageBox.Show("确定要修改吗?",//对话框的显示内容 
                                                               "操作提示",//对话框的标题 
                                                               MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                                                               MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                      
                                                               MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
                    if (result == DialogResult.Yes) 
                    {
                        ItemInfo item = new ItemInfo();

                        item.ItemNo = DgvItemInfo.CurrentRow.Cells["ItemNo"].Value.ToString();
                        item.ItemName = DgvItemInfo.CurrentRow.Cells["ItemName"].Value.ToString();
                        item.ILength = Convert.ToDecimal(DgvItemInfo.CurrentRow.Cells["ILength"].Value);
                        item.IWidth = Convert.ToDecimal(DgvItemInfo.CurrentRow.Cells["IWidth"].Value);
                        item.IHeight = Convert.ToDecimal(DgvItemInfo.CurrentRow.Cells["IHEIGHT"].Value);
                        item.BigBox_Bar = DgvItemInfo.CurrentRow.Cells["BigBox_Bar"].Value.ToString();
                        item.JT_Size = Convert.ToDecimal(DgvItemInfo.CurrentRow.Cells["JZ_Size"].Value);

                        if (DgvItemInfo.CurrentRow.Cells["Type"].EditedFormattedValue.ToString() == "标准烟")
                            item.Shiptype = "0";
                        else
                            item.Shiptype = "1";
                        if (DgvItemInfo.CurrentRow.Cells["status"].EditedFormattedValue.ToString() == "正常")
                            item.RowStatus = 10;
                        else
                            item.RowStatus = 0;

                        if (ItemClass.UpdateItemInfo(item))
                        {
                            
                            itemInfos = new List<ItemInfo>();
                            DgvItemInfo.DataSource = itemInfos;
                            itemInfos = ItemClass.GetItemInfo(0, "");
                            DgvItemInfo.AutoGenerateColumns = false;
                            DgvItemInfo.DataSource = itemInfos;
                            MessageBox.Show("卷烟品牌信息修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("卷烟品牌信息修改失败!" + ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        private void DgvItemInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (itemInfos[e.RowIndex].Shiptype == "0")
                {

                    e.Value = "标准烟";
                }
                else
                {
                    e.Value = "异型烟";
                }
            }
            if (e.ColumnIndex == 4)
            {
                if (itemInfos[e.RowIndex].RowStatus == 10)
                {

                    e.Value = "正常";
                }
                else
                {
                    e.Value = "删除";
                }
            }
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
    }
}
