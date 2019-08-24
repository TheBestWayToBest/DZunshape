namespace HighspeedNew.OrderHandle
{
    partial class w_HunheReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labeltroughnum = new System.Windows.Forms.Label();
            this.cmbTroughnum = new System.Windows.Forms.ComboBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.task_data = new System.Windows.Forms.DataGridView();
            this.MachineSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CigaretteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CigaretteNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SortNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Regioncode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVprint1 = new VBprinter.DGVprint(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.task_data)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labeltroughnum);
            this.panel1.Controls.Add(this.cmbTroughnum);
            this.panel1.Controls.Add(this.BtnSearch);
            this.panel1.Controls.Add(this.btn_print);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 48);
            this.panel1.TabIndex = 2;
            // 
            // labeltroughnum
            // 
            this.labeltroughnum.AutoSize = true;
            this.labeltroughnum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labeltroughnum.Location = new System.Drawing.Point(54, 14);
            this.labeltroughnum.Name = "labeltroughnum";
            this.labeltroughnum.Size = new System.Drawing.Size(64, 16);
            this.labeltroughnum.TabIndex = 17;
            this.labeltroughnum.Text = "通 道：";
            // 
            // cmbTroughnum
            // 
            this.cmbTroughnum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTroughnum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbTroughnum.FormattingEnabled = true;
            this.cmbTroughnum.Location = new System.Drawing.Point(124, 11);
            this.cmbTroughnum.Name = "cmbTroughnum";
            this.cmbTroughnum.Size = new System.Drawing.Size(90, 24);
            this.cmbTroughnum.TabIndex = 16;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSearch.Location = new System.Drawing.Point(242, 7);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(80, 30);
            this.BtnSearch.TabIndex = 15;
            this.BtnSearch.Text = "查 询";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btn_print
            // 
            this.btn_print.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_print.Location = new System.Drawing.Point(651, 7);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(80, 30);
            this.btn_print.TabIndex = 11;
            this.btn_print.Text = "打 印";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // task_data
            // 
            this.task_data.AllowUserToAddRows = false;
            this.task_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.task_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.task_data.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.task_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.task_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.task_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MachineSeq,
            this.CusName,
            this.CigaretteName,
            this.CigaretteNum,
            this.SortNum,
            this.Regioncode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.task_data.DefaultCellStyle = dataGridViewCellStyle2;
            this.task_data.Location = new System.Drawing.Point(0, 54);
            this.task_data.Name = "task_data";
            this.task_data.RowTemplate.Height = 23;
            this.task_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.task_data.Size = new System.Drawing.Size(1020, 402);
            this.task_data.TabIndex = 3;
            // 
            // MachineSeq
            // 
            this.MachineSeq.DataPropertyName = "MachineSeq";
            this.MachineSeq.HeaderText = "烟道";
            this.MachineSeq.Name = "MachineSeq";
            // 
            // CusName
            // 
            this.CusName.DataPropertyName = "CUSTOMERNAME";
            this.CusName.HeaderText = "客户名称";
            this.CusName.Name = "CusName";
            // 
            // CigaretteName
            // 
            this.CigaretteName.DataPropertyName = "CigaretteName";
            this.CigaretteName.HeaderText = "品牌名称";
            this.CigaretteName.Name = "CigaretteName";
            // 
            // CigaretteNum
            // 
            this.CigaretteNum.DataPropertyName = "POKENUM";
            this.CigaretteNum.HeaderText = "数量";
            this.CigaretteNum.Name = "CigaretteNum";
            // 
            // SortNum
            // 
            this.SortNum.DataPropertyName = "SortNum";
            this.SortNum.HeaderText = "任务号";
            this.SortNum.Name = "SortNum";
            // 
            // Regioncode
            // 
            this.Regioncode.DataPropertyName = "RegionDESC";
            this.Regioncode.HeaderText = "车组";
            this.Regioncode.Name = "Regioncode";
            // 
            // dgVprint1
            // 
            this.dgVprint1.Alignment = System.Drawing.StringAlignment.Center;
            this.dgVprint1.AutoFormat = false;
            this.dgVprint1.AutoResizeRowHeight = false;
            this.dgVprint1.Border = "1111";
            this.dgVprint1.CanEditPrintSettings = true;
            this.dgVprint1.Columns = 2;
            this.dgVprint1.ColumnSpace = 50F;
            this.dgVprint1.DefaultColor = System.Drawing.Color.Black;
            this.dgVprint1.DocuMentName = "DataGridView打印控件";
            this.dgVprint1.DoubleLineSpace = 10.16F;
            this.dgVprint1.EnableChangeGroup = true;
            this.dgVprint1.EnableChangeHeaderAndFooter = true;
            this.dgVprint1.EnableChangePageSettings = true;
            this.dgVprint1.EnableChangeSum = true;
            this.dgVprint1.EnableChangeTableSettings = true;
            this.dgVprint1.EnableChangeTableStyle = true;
            this.dgVprint1.EnableChangeTitle = true;
            this.dgVprint1.EnableChangeWaterMark = true;
            this.dgVprint1.EnableChangeZDX = true;
            this.dgVprint1.EnabledPrint = true;
            this.dgVprint1.FixedCols = 1;
            this.dgVprint1.GridColor = System.Drawing.Color.Black;
            this.dgVprint1.GroupColumn = "";
            this.dgVprint1.GroupNewPage = false;
            this.dgVprint1.IsAddRowID = false;
            this.dgVprint1.IsAutoAddEmptyRow = false;
            this.dgVprint1.IsDGVCellValignmentCenter = true;
            this.dgVprint1.IsDrawmargin = true;
            this.dgVprint1.IsDrawPageFooterLine = false;
            this.dgVprint1.IsDrawPageHeaderLine = false;
            this.dgVprint1.IsDrawTableFooterEveryPage = false;
            this.dgVprint1.IsDrawZDX = false;
            this.dgVprint1.IsGroupNewRowID = false;
            this.dgVprint1.IsImmediatePrint = false;
            this.dgVprint1.IsImmediatePrintShowPrintDialog = true;
            this.dgVprint1.IsPrintRowHeaderColumn = false;
            this.dgVprint1.IsShowAboutPage = true;
            this.dgVprint1.IsShowUnvisibleColum = true;
            this.dgVprint1.IsUseAPIprintDialog = false;
            this.dgVprint1.IsUseDoubleLine = false;
            this.dgVprint1.LastPageMode = true;
            this.dgVprint1.LineSpace = 50F;
            this.dgVprint1.MainTitle = "表格主标题";
            this.dgVprint1.MainTitleFont = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.dgVprint1.MinFontSize = 6F;
            this.dgVprint1.OuterBorder = false;
            this.dgVprint1.OuterBorderColor = System.Drawing.Color.Black;
            this.dgVprint1.OuterBorderWidth = 5.08F;
            this.dgVprint1.PageFooterColor = System.Drawing.Color.Black;
            this.dgVprint1.PageFooterFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dgVprint1.PageFooterLeft = null;
            this.dgVprint1.PageFooterMiddle = "共[总页数]页 第[页码]页";
            this.dgVprint1.PageFooterRight = null;
            this.dgVprint1.PageHeaderColor = System.Drawing.Color.Black;
            this.dgVprint1.PageHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dgVprint1.PageHeaderLeft = null;
            this.dgVprint1.PageHeaderMiddle = null;
            this.dgVprint1.PageHeaderRight = null;
            this.dgVprint1.PaperHeight = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.dgVprint1.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.dgVprint1.PaperLandscape = false;
            this.dgVprint1.PaperMargins = new System.Drawing.Printing.Margins(254, 254, 254, 254);
            this.dgVprint1.PaperName = "";
            this.dgVprint1.PaperWidth = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.dgVprint1.PrintBackColor = true;
            this.dgVprint1.PrinterName = "";
            this.dgVprint1.PrintRange = VBprinter.DGVprint.DGVPrintRange.AllVisibleRowsAndColumns;
            this.dgVprint1.PrintTitlePerPage = true;
            this.dgVprint1.PrintType = VBprinter.DGVprint.mytype.GeneralPrint;
            this.dgVprint1.PrintZero = false;
            this.dgVprint1.RowHeight = 0F;
            this.dgVprint1.ShapeDepth = 18;
            this.dgVprint1.SortColumn = "";
            this.dgVprint1.SortMode = System.ComponentModel.ListSortDirection.Ascending;
            this.dgVprint1.SubTitle = "";
            this.dgVprint1.SubTitleFont = new System.Drawing.Font("宋体", 12F);
            this.dgVprint1.SubTitleStyle = 0;
            this.dgVprint1.SumBackColor = System.Drawing.Color.Empty;
            this.dgVprint1.SumColumns = "";
            this.dgVprint1.SumFont = null;
            this.dgVprint1.SumForeColor = System.Drawing.Color.Empty;
            this.dgVprint1.SumNumberAlign = System.Drawing.StringAlignment.Center;
            this.dgVprint1.TableBottomLeftTitleAlign = System.Drawing.StringAlignment.Near;
            this.dgVprint1.TableBottomMiddleTitleAlign = System.Drawing.StringAlignment.Center;
            this.dgVprint1.TableBottomRightTitleAlign = System.Drawing.StringAlignment.Far;
            this.dgVprint1.TableFooterFont = new System.Drawing.Font("宋体", 10F);
            this.dgVprint1.TableFooterLeft = null;
            this.dgVprint1.TableFooterMiddle = null;
            this.dgVprint1.TableFooterRight = null;
            this.dgVprint1.TableHeaderFont = new System.Drawing.Font("宋体", 10F);
            this.dgVprint1.TableHeaderLeft = null;
            this.dgVprint1.TableHeaderMiddle = null;
            this.dgVprint1.TableHeaderRight = null;
            this.dgVprint1.TableTopLeftTitleAlign = System.Drawing.StringAlignment.Near;
            this.dgVprint1.TableTopMiddleTitleAlign = System.Drawing.StringAlignment.Center;
            this.dgVprint1.TableTopRightTitleAlign = System.Drawing.StringAlignment.Far;
            this.dgVprint1.TitleTextStyle = 0;
            this.dgVprint1.WaterMarkColor = System.Drawing.Color.Red;
            this.dgVprint1.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Bold);
            this.dgVprint1.WaterMarkLandscape = true;
            this.dgVprint1.WaterMarkOpacity = ((byte)(128));
            this.dgVprint1.WaterMarkText = "";
            this.dgVprint1.WindowTitle = "打印预览结果";
            this.dgVprint1.ZDXFont = new System.Drawing.Font("宋体", 9F);
            this.dgVprint1.ZDXLinecoLor = System.Drawing.Color.Black;
            this.dgVprint1.ZDXLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.dgVprint1.ZDXPosition = 0F;
            this.dgVprint1.ZDXText = "装订线";
            this.dgVprint1.ZDXTextColor = System.Drawing.Color.Black;
            this.dgVprint1.ZDXType = VBprinter.DGVprint.TheZDXTYPE.LEFT;
            this.dgVprint1.ZoomToPaperWidth = true;
            // 
            // w_HunheReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 456);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.task_data);
            this.Name = "w_HunheReport";
            this.Text = "混合道补烟报表";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.task_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labeltroughnum;
        private System.Windows.Forms.ComboBox cmbTroughnum;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.DataGridView task_data;
        private VBprinter.DGVprint dgVprint1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn CusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CigaretteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CigaretteNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Regioncode;
    }
}