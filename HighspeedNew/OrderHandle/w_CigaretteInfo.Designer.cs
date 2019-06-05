namespace HighSpeed.OrderHandle
{
    partial class w_CigaretteInfo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_keywd = new System.Windows.Forms.TextBox();
            this.box_type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExport = new System.Windows.Forms.Button();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.DgvItemInfo = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.件码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shiptype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.长度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.宽度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JZ_Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvItemInfo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_keywd);
            this.panel1.Controls.Add(this.box_type);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnExport);
            this.panel1.Controls.Add(this.BtnPrint);
            this.panel1.Controls.Add(this.BtnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1268, 33);
            this.panel1.TabIndex = 36;
            // 
            // txt_keywd
            // 
            this.txt_keywd.Location = new System.Drawing.Point(185, 6);
            this.txt_keywd.Name = "txt_keywd";
            this.txt_keywd.Size = new System.Drawing.Size(100, 21);
            this.txt_keywd.TabIndex = 8;
            // 
            // box_type
            // 
            this.box_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_type.FormattingEnabled = true;
            this.box_type.Items.AddRange(new object[] {
            "卷烟编码",
            "卷烟名称"});
            this.box_type.Location = new System.Drawing.Point(81, 7);
            this.box_type.Name = "box_type";
            this.box_type.Size = new System.Drawing.Size(98, 20);
            this.box_type.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "条件选择";
            // 
            // BtnExport
            // 
            this.BtnExport.Location = new System.Drawing.Point(879, 4);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(75, 27);
            this.BtnExport.TabIndex = 6;
            this.BtnExport.Text = "导出";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.Location = new System.Drawing.Point(708, 2);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(75, 27);
            this.BtnPrint.TabIndex = 5;
            this.BtnPrint.Text = "打印";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(530, 4);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 27);
            this.BtnSearch.TabIndex = 0;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // DgvItemInfo
            // 
            this.DgvItemInfo.AllowUserToAddRows = false;
            this.DgvItemInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvItemInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvItemInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNo,
            this.ItemName,
            this.件码,
            this.Shiptype,
            this.RowStatus,
            this.长度,
            this.宽度,
            this.JZ_Size});
            this.DgvItemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvItemInfo.Location = new System.Drawing.Point(0, 33);
            this.DgvItemInfo.Name = "DgvItemInfo";
            this.DgvItemInfo.RowHeadersVisible = false;
            this.DgvItemInfo.RowTemplate.Height = 23;
            this.DgvItemInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvItemInfo.Size = new System.Drawing.Size(1268, 345);
            this.DgvItemInfo.TabIndex = 37;
            this.DgvItemInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvItemInfo_CellFormatting);
            this.DgvItemInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvItemInfo_CellValueChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(320, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 102);
            this.panel2.TabIndex = 38;
            this.panel2.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(36, 45);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(554, 23);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "正在读取数据...";
            this.label2.Visible = false;
            // 
            // ItemNo
            // 
            this.ItemNo.DataPropertyName = "ItemNo";
            this.ItemNo.HeaderText = "卷烟编号";
            this.ItemNo.Name = "ItemNo";
            this.ItemNo.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "名称";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // 件码
            // 
            this.件码.DataPropertyName = "BigBox_Bar";
            this.件码.HeaderText = "件码";
            this.件码.Name = "件码";
            // 
            // Shiptype
            // 
            this.Shiptype.DataPropertyName = "Shiptype";
            this.Shiptype.HeaderText = "卷烟类型";
            this.Shiptype.Name = "Shiptype";
            // 
            // RowStatus
            // 
            this.RowStatus.DataPropertyName = "RowStatus";
            this.RowStatus.HeaderText = "卷烟状态";
            this.RowStatus.Name = "RowStatus";
            // 
            // 长度
            // 
            this.长度.DataPropertyName = "ILength";
            this.长度.HeaderText = "长度";
            this.长度.Name = "长度";
            // 
            // 宽度
            // 
            this.宽度.DataPropertyName = "IWidth";
            this.宽度.HeaderText = "宽度";
            this.宽度.Name = "宽度";
            // 
            // JZ_Size
            // 
            this.JZ_Size.DataPropertyName = "JZ_Size";
            this.JZ_Size.HeaderText = "条/件换算";
            this.JZ_Size.Name = "JZ_Size";
            // 
            // w_CigaretteInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1268, 378);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DgvItemInfo);
            this.Controls.Add(this.panel1);
            this.Name = "w_CigaretteInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "卷烟信息";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvItemInfo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_keywd;
        private System.Windows.Forms.ComboBox box_type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.DataGridView DgvItemInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn 件码;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shiptype;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn 长度;
        private System.Windows.Forms.DataGridViewTextBoxColumn 宽度;
        private System.Windows.Forms.DataGridViewTextBoxColumn JZ_Size;
    }
}