namespace SmokeRelenishment
{
    partial class NowView
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
            this.DgvNowView = new System.Windows.Forms.DataGridView();
            this.btnNowPoke = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sendtasknum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TROUGHNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIGARETTECODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIGARETTENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pokenum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvNowView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvNowView
            // 
            this.DgvNowView.AllowUserToAddRows = false;
            this.DgvNowView.AllowUserToDeleteRows = false;
            this.DgvNowView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvNowView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvNowView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sendtasknum,
            this.TROUGHNUM,
            this.CIGARETTECODE,
            this.CIGARETTENAME,
            this.pokenum,
            this.status});
            this.DgvNowView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvNowView.Location = new System.Drawing.Point(3, 17);
            this.DgvNowView.Name = "DgvNowView";
            this.DgvNowView.ReadOnly = true;
            this.DgvNowView.RowTemplate.Height = 23;
            this.DgvNowView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvNowView.Size = new System.Drawing.Size(1299, 499);
            this.DgvNowView.TabIndex = 0;
            // 
            // btnNowPoke
            // 
            this.btnNowPoke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNowPoke.Font = new System.Drawing.Font("宋体", 20F);
            this.btnNowPoke.Location = new System.Drawing.Point(994, 7);
            this.btnNowPoke.Name = "btnNowPoke";
            this.btnNowPoke.Size = new System.Drawing.Size(152, 45);
            this.btnNowPoke.TabIndex = 7;
            this.btnNowPoke.Text = "定位当前";
            this.btnNowPoke.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DgvNowView);
            this.groupBox1.Location = new System.Drawing.Point(3, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1305, 519);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // sendtasknum
            // 
            this.sendtasknum.DataPropertyName = "TaskNum";
            this.sendtasknum.HeaderText = "任务号";
            this.sendtasknum.Name = "sendtasknum";
            this.sendtasknum.ReadOnly = true;
            // 
            // TROUGHNUM
            // 
            this.TROUGHNUM.DataPropertyName = "TROUGHNUM";
            this.TROUGHNUM.HeaderText = "通道号";
            this.TROUGHNUM.Name = "TROUGHNUM";
            this.TROUGHNUM.ReadOnly = true;
            // 
            // CIGARETTECODE
            // 
            this.CIGARETTECODE.DataPropertyName = "CIGARETTECODE";
            this.CIGARETTECODE.HeaderText = "卷烟编码";
            this.CIGARETTECODE.Name = "CIGARETTECODE";
            this.CIGARETTECODE.ReadOnly = true;
            // 
            // CIGARETTENAME
            // 
            this.CIGARETTENAME.DataPropertyName = "CIGARETTENAME";
            this.CIGARETTENAME.HeaderText = "卷烟名称";
            this.CIGARETTENAME.Name = "CIGARETTENAME";
            this.CIGARETTENAME.ReadOnly = true;
            // 
            // pokenum
            // 
            this.pokenum.DataPropertyName = "pokenum";
            this.pokenum.HeaderText = "数量";
            this.pokenum.Name = "pokenum";
            this.pokenum.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "状态";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // NowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 584);
            this.Controls.Add(this.btnNowPoke);
            this.Controls.Add(this.groupBox1);
            this.Name = "NowView";
            this.Text = "NowView";
            ((System.ComponentModel.ISupportInitialize)(this.DgvNowView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvNowView;
        private System.Windows.Forms.Button btnNowPoke;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sendtasknum;
        private System.Windows.Forms.DataGridViewTextBoxColumn TROUGHNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIGARETTECODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIGARETTENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn pokenum;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}