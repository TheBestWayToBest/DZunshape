namespace HighspeedNew.OrderHandle
{
    partial class w_RegionSortManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.batchdata = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RegionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.batchdata)).BeginInit();
            this.SuspendLayout();
            // 
            // batchdata
            // 
            this.batchdata.AllowUserToAddRows = false;
            this.batchdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.batchdata.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.batchdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.batchdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.batchdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RegionCode,
            this.RegionDesc,
            this.endtime});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.batchdata.DefaultCellStyle = dataGridViewCellStyle4;
            this.batchdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batchdata.Location = new System.Drawing.Point(0, 48);
            this.batchdata.MultiSelect = false;
            this.batchdata.Name = "batchdata";
            this.batchdata.ReadOnly = true;
            this.batchdata.RowTemplate.Height = 23;
            this.batchdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.batchdata.Size = new System.Drawing.Size(535, 359);
            this.batchdata.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 48);
            this.panel1.TabIndex = 3;
            // 
            // RegionCode
            // 
            this.RegionCode.DataPropertyName = "batchcode";
            this.RegionCode.HeaderText = "车组编号";
            this.RegionCode.Name = "RegionCode";
            this.RegionCode.ReadOnly = true;
            // 
            // RegionDesc
            // 
            this.RegionDesc.DataPropertyName = "starttime";
            this.RegionDesc.HeaderText = "车组名称";
            this.RegionDesc.Name = "RegionDesc";
            this.RegionDesc.ReadOnly = true;
            // 
            // endtime
            // 
            this.endtime.DataPropertyName = "endtime";
            this.endtime.HeaderText = "车组顺序";
            this.endtime.Name = "endtime";
            this.endtime.ReadOnly = true;
            // 
            // w_RegionSortManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 407);
            this.Controls.Add(this.batchdata);
            this.Controls.Add(this.panel1);
            this.Name = "w_RegionSortManage";
            this.Text = "w_RegionSortManage";
            ((System.ComponentModel.ISupportInitialize)(this.batchdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView batchdata;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn endtime;
    }
}