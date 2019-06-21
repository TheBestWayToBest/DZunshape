namespace HighspeedNew.OrderHandle
{
    partial class w_relenishment
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
            this.dgvReplenish = new System.Windows.Forms.DataGridView();
            this.ThroughNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CigaretteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JYCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReplenishQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RBAll = new System.Windows.Forms.RadioButton();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.RBFinished = new System.Windows.Forms.RadioButton();
            this.RBFinishing = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RBUnfinish = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplenish)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReplenish
            // 
            this.dgvReplenish.AllowUserToAddRows = false;
            this.dgvReplenish.AllowUserToDeleteRows = false;
            this.dgvReplenish.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReplenish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReplenish.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ThroughNum,
            this.CigaretteName,
            this.JYCode,
            this.ReplenishQTY,
            this.TaskNum});
            this.dgvReplenish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReplenish.Location = new System.Drawing.Point(0, 0);
            this.dgvReplenish.Name = "dgvReplenish";
            this.dgvReplenish.ReadOnly = true;
            this.dgvReplenish.RowHeadersVisible = false;
            this.dgvReplenish.RowTemplate.Height = 23;
            this.dgvReplenish.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReplenish.Size = new System.Drawing.Size(1177, 405);
            this.dgvReplenish.TabIndex = 0;
            // 
            // ThroughNum
            // 
            this.ThroughNum.DataPropertyName = "ThroughNum";
            this.ThroughNum.HeaderText = "烟道";
            this.ThroughNum.Name = "ThroughNum";
            this.ThroughNum.ReadOnly = true;
            // 
            // CigaretteName
            // 
            this.CigaretteName.DataPropertyName = "CigaretteName";
            this.CigaretteName.HeaderText = "品牌名称";
            this.CigaretteName.Name = "CigaretteName";
            this.CigaretteName.ReadOnly = true;
            // 
            // JYCode
            // 
            this.JYCode.DataPropertyName = "JYCode";
            this.JYCode.HeaderText = "件烟码";
            this.JYCode.Name = "JYCode";
            this.JYCode.ReadOnly = true;
            // 
            // ReplenishQTY
            // 
            this.ReplenishQTY.DataPropertyName = "ReplenishQTY";
            this.ReplenishQTY.HeaderText = "数量";
            this.ReplenishQTY.Name = "ReplenishQTY";
            this.ReplenishQTY.ReadOnly = true;
            // 
            // TaskNum
            // 
            this.TaskNum.DataPropertyName = "TaskNum";
            this.TaskNum.HeaderText = "任务号";
            this.TaskNum.Name = "TaskNum";
            this.TaskNum.ReadOnly = true;
            // 
            // RBAll
            // 
            this.RBAll.AutoSize = true;
            this.RBAll.Checked = true;
            this.RBAll.Location = new System.Drawing.Point(29, 15);
            this.RBAll.Name = "RBAll";
            this.RBAll.Size = new System.Drawing.Size(47, 16);
            this.RBAll.TabIndex = 23;
            this.RBAll.TabStop = true;
            this.RBAll.Text = "所有";
            this.RBAll.UseVisualStyleBackColor = true;
            // 
            // BtnPrint
            // 
            this.BtnPrint.Location = new System.Drawing.Point(592, 12);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(75, 23);
            this.BtnPrint.TabIndex = 22;
            this.BtnPrint.Text = "打印";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(440, 12);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 21;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // RBFinished
            // 
            this.RBFinished.AutoSize = true;
            this.RBFinished.Location = new System.Drawing.Point(300, 15);
            this.RBFinished.Name = "RBFinished";
            this.RBFinished.Size = new System.Drawing.Size(59, 16);
            this.RBFinished.TabIndex = 20;
            this.RBFinished.Text = "已完成";
            this.RBFinished.UseVisualStyleBackColor = true;
            // 
            // RBFinishing
            // 
            this.RBFinishing.AutoSize = true;
            this.RBFinishing.Location = new System.Drawing.Point(214, 14);
            this.RBFinishing.Name = "RBFinishing";
            this.RBFinishing.Size = new System.Drawing.Size(59, 16);
            this.RBFinishing.TabIndex = 19;
            this.RBFinishing.Text = "处理中";
            this.RBFinishing.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.RBAll);
            this.panel2.Controls.Add(this.BtnPrint);
            this.panel2.Controls.Add(this.BtnSearch);
            this.panel2.Controls.Add(this.RBFinished);
            this.panel2.Controls.Add(this.RBFinishing);
            this.panel2.Controls.Add(this.RBUnfinish);
            this.panel2.Location = new System.Drawing.Point(2, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1177, 45);
            this.panel2.TabIndex = 3;
            // 
            // RBUnfinish
            // 
            this.RBUnfinish.AutoSize = true;
            this.RBUnfinish.Location = new System.Drawing.Point(125, 14);
            this.RBUnfinish.Name = "RBUnfinish";
            this.RBUnfinish.Size = new System.Drawing.Size(59, 16);
            this.RBUnfinish.TabIndex = 18;
            this.RBUnfinish.Text = "未处理";
            this.RBUnfinish.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvReplenish);
            this.panel1.Location = new System.Drawing.Point(2, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1177, 405);
            this.panel1.TabIndex = 2;
            // 
            // w_relenishment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 468);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "w_relenishment";
            this.Text = "w_relenishment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplenish)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReplenish;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThroughNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn CigaretteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JYCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReplenishQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskNum;
        private System.Windows.Forms.RadioButton RBAll;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.RadioButton RBFinished;
        private System.Windows.Forms.RadioButton RBFinishing;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton RBUnfinish;
        private System.Windows.Forms.Panel panel1;
    }
}