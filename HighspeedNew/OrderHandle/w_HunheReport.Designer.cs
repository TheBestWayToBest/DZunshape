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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labeltroughnum = new System.Windows.Forms.Label();
            this.cmbTroughnum = new System.Windows.Forms.ComboBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btn_print = new System.Windows.Forms.Button();
            this.task_data = new System.Windows.Forms.DataGridView();
            this.MachineSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CigaretteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CigaretteNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SortNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Regioncode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.task_data)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labeltroughnum);
            this.panel1.Controls.Add(this.cmbTroughnum);
            this.panel1.Controls.Add(this.BtnSearch);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
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
            this.labeltroughnum.Location = new System.Drawing.Point(294, 15);
            this.labeltroughnum.Name = "labeltroughnum";
            this.labeltroughnum.Size = new System.Drawing.Size(47, 12);
            this.labeltroughnum.TabIndex = 17;
            this.labeltroughnum.Text = "通 道：";
            // 
            // cmbTroughnum
            // 
            this.cmbTroughnum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTroughnum.FormattingEnabled = true;
            this.cmbTroughnum.Location = new System.Drawing.Point(347, 11);
            this.cmbTroughnum.Name = "cmbTroughnum";
            this.cmbTroughnum.Size = new System.Drawing.Size(90, 20);
            this.cmbTroughnum.TabIndex = 16;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(522, 9);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 15;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(207, 13);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(59, 16);
            this.radioButton3.TabIndex = 14;
            this.radioButton3.Text = "已完成";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(121, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.Text = "处理中";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(32, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 16);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "未处理";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(653, 9);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 11;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            // 
            // task_data
            // 
            this.task_data.AllowUserToAddRows = false;
            this.task_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.task_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.task_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.task_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MachineSeq,
            this.CusName,
            this.CigaretteName,
            this.CigaretteNum,
            this.SortNum,
            this.Regioncode});
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
            this.CusName.DataPropertyName = "CusName";
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
            this.CigaretteNum.DataPropertyName = "CigaretteNum";
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
            this.Regioncode.DataPropertyName = "Regioncode";
            this.Regioncode.HeaderText = "车组";
            this.Regioncode.Name = "Regioncode";
            // 
            // w_HunheReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 456);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.task_data);
            this.Name = "w_HunheReport";
            this.Text = "w_HunheReport";
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
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.DataGridView task_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn CusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CigaretteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CigaretteNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Regioncode;
    }
}