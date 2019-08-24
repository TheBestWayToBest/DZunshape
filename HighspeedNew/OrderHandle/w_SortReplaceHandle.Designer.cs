namespace HighspeedNew.OrderHandle
{
    partial class w_SortReplaceHandle
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.RBWoshi = new System.Windows.Forms.RadioButton();
            this.RBLishi = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MachineSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThroughNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CigaretteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CigaretteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnSubmit);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.RBWoshi);
            this.groupBox1.Controls.Add(this.RBLishi);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 42);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Enabled = false;
            this.BtnSubmit.Location = new System.Drawing.Point(451, 13);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(75, 23);
            this.BtnSubmit.TabIndex = 6;
            this.BtnSubmit.Text = "提交";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(234, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "通道编号：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RBWoshi
            // 
            this.RBWoshi.AutoSize = true;
            this.RBWoshi.Location = new System.Drawing.Point(83, 16);
            this.RBWoshi.Name = "RBWoshi";
            this.RBWoshi.Size = new System.Drawing.Size(71, 16);
            this.RBWoshi.TabIndex = 3;
            this.RBWoshi.Text = "卧式烟仓";
            this.RBWoshi.UseVisualStyleBackColor = true;
            // 
            // RBLishi
            // 
            this.RBLishi.AutoSize = true;
            this.RBLishi.Checked = true;
            this.RBLishi.Location = new System.Drawing.Point(6, 16);
            this.RBLishi.Name = "RBLishi";
            this.RBLishi.Size = new System.Drawing.Size(71, 16);
            this.RBLishi.TabIndex = 2;
            this.RBLishi.TabStop = true;
            this.RBLishi.Text = "立式烟仓";
            this.RBLishi.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(3, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 238);
            this.panel1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MachineSeq,
            this.ThroughNum,
            this.CigaretteCode,
            this.CigaretteName});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(534, 238);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // MachineSeq
            // 
            this.MachineSeq.DataPropertyName = "MachineSeq";
            this.MachineSeq.HeaderText = "物理通道号";
            this.MachineSeq.Name = "MachineSeq";
            this.MachineSeq.ReadOnly = true;
            // 
            // ThroughNum
            // 
            this.ThroughNum.DataPropertyName = "ThroughNum";
            this.ThroughNum.HeaderText = "通道号";
            this.ThroughNum.Name = "ThroughNum";
            this.ThroughNum.ReadOnly = true;
            // 
            // CigaretteCode
            // 
            this.CigaretteCode.DataPropertyName = "CigaretteCode";
            this.CigaretteCode.HeaderText = "卷烟编码";
            this.CigaretteCode.Name = "CigaretteCode";
            this.CigaretteCode.ReadOnly = true;
            // 
            // CigaretteName
            // 
            this.CigaretteName.DataPropertyName = "CigaretteName";
            this.CigaretteName.HeaderText = "卷烟名称";
            this.CigaretteName.Name = "CigaretteName";
            this.CigaretteName.ReadOnly = true;
            // 
            // w_SortReplaceHandle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 289);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "w_SortReplaceHandle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton RBWoshi;
        private System.Windows.Forms.RadioButton RBLishi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnSubmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThroughNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn CigaretteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CigaretteName;
    }
}