namespace HighspeedNew.OrderHandle
{
    partial class w_PackageReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CmbRegion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ORDERDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BATCHCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROTECODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROTENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDERID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEVSEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PACKINFO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PACKNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAYSTATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.dgVprint1 = new VBprinter.DGVprint(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CmbRegion);
            this.groupBox1.Location = new System.Drawing.Point(0, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1062, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(0, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 334);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ORDERDATE,
            this.BATCHCODE,
            this.ROTECODE,
            this.ROTENAME,
            this.CUSTCODE,
            this.CUSTNAME,
            this.ORDERID,
            this.DEVSEQ,
            this.PACKINFO,
            this.PACKNUM,
            this.QUANTITY,
            this.AMOUNT,
            this.PAYSTATE});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1062, 334);
            this.dataGridView1.TabIndex = 0;
            // 
            // CmbRegion
            // 
            this.CmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRegion.FormattingEnabled = true;
            this.CmbRegion.Location = new System.Drawing.Point(108, 24);
            this.CmbRegion.Name = "CmbRegion";
            this.CmbRegion.Size = new System.Drawing.Size(121, 20);
            this.CmbRegion.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "车辆名称：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ORDERDATE
            // 
            this.ORDERDATE.DataPropertyName = "ORDERDATE";
            this.ORDERDATE.HeaderText = "订单日期";
            this.ORDERDATE.Name = "ORDERDATE";
            // 
            // BATCHCODE
            // 
            this.BATCHCODE.DataPropertyName = "BATCHCODE";
            this.BATCHCODE.HeaderText = "批次号";
            this.BATCHCODE.Name = "BATCHCODE";
            // 
            // ROTECODE
            // 
            this.ROTECODE.DataPropertyName = "ROTECODE";
            this.ROTECODE.HeaderText = "线路编码";
            this.ROTECODE.Name = "ROTECODE";
            // 
            // ROTENAME
            // 
            this.ROTENAME.DataPropertyName = "ROTENAME";
            this.ROTENAME.HeaderText = "线路名称";
            this.ROTENAME.Name = "ROTENAME";
            // 
            // CUSTCODE
            // 
            this.CUSTCODE.DataPropertyName = "CUSTCODE";
            this.CUSTCODE.HeaderText = "客户代码";
            this.CUSTCODE.Name = "CUSTCODE";
            // 
            // CUSTNAME
            // 
            this.CUSTNAME.DataPropertyName = "CUSTNAME";
            this.CUSTNAME.HeaderText = "客户名称";
            this.CUSTNAME.Name = "CUSTNAME";
            // 
            // ORDERID
            // 
            this.ORDERID.DataPropertyName = "ORDERID";
            this.ORDERID.HeaderText = "订单号";
            this.ORDERID.Name = "ORDERID";
            // 
            // DEVSEQ
            // 
            this.DEVSEQ.DataPropertyName = "DEVSEQ";
            this.DEVSEQ.HeaderText = "包序";
            this.DEVSEQ.Name = "DEVSEQ";
            // 
            // PACKINFO
            // 
            this.PACKINFO.DataPropertyName = "PACKINFO";
            this.PACKINFO.HeaderText = "包信息";
            this.PACKINFO.Name = "PACKINFO";
            // 
            // PACKNUM
            // 
            this.PACKNUM.DataPropertyName = "PACKNUM";
            this.PACKNUM.HeaderText = "包数";
            this.PACKNUM.Name = "PACKNUM";
            // 
            // QUANTITY
            // 
            this.QUANTITY.DataPropertyName = "QUANTITY";
            this.QUANTITY.HeaderText = "订货数量";
            this.QUANTITY.Name = "QUANTITY";
            // 
            // AMOUNT
            // 
            this.AMOUNT.DataPropertyName = "AMOUNT";
            this.AMOUNT.HeaderText = "金额";
            this.AMOUNT.Name = "AMOUNT";
            // 
            // PAYSTATE
            // 
            this.PAYSTATE.DataPropertyName = "PAYSTATE";
            this.PAYSTATE.HeaderText = "付款状态";
            this.PAYSTATE.Name = "PAYSTATE";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(755, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "导出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // w_PackageReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 409);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "w_PackageReport";
            this.Text = "包装机数据";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDERDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BATCHCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROTECODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROTENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDERID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEVSEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn PACKINFO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PACKNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYSTATE;
        private System.Windows.Forms.Button button2;
        private VBprinter.DGVprint dgVprint1;
    }
}