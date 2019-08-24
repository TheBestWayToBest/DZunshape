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
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPLENISHLINE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TROUGHNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIGARETTECODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIGARETTENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPLENISHQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISCOMPLETED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANSPORTATIONLINE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FINISHTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JYCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MANTISSA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCANTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.id,
            this.REPLENISHLINE,
            this.TROUGHNUM,
            this.CIGARETTECODE,
            this.CIGARETTENAME,
            this.REPLENISHQTY,
            this.ISCOMPLETED,
            this.STATUS,
            this.TRANSPORTATIONLINE,
            this.FINISHTIME,
            this.JYCODE,
            this.TYPE,
            this.MANTISSA,
            this.SCANTIME,
            this.SEQ});
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
            this.btnNowPoke.Click += new System.EventHandler(this.btnNowPoke_Click);
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
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // REPLENISHLINE
            // 
            this.REPLENISHLINE.DataPropertyName = "REPLENISHLINE";
            this.REPLENISHLINE.HeaderText = "REPLENISHLINE";
            this.REPLENISHLINE.Name = "REPLENISHLINE";
            this.REPLENISHLINE.ReadOnly = true;
            this.REPLENISHLINE.Visible = false;
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
            // REPLENISHQTY
            // 
            this.REPLENISHQTY.DataPropertyName = "REPLENISHQTY";
            this.REPLENISHQTY.HeaderText = "数量";
            this.REPLENISHQTY.Name = "REPLENISHQTY";
            this.REPLENISHQTY.ReadOnly = true;
            // 
            // ISCOMPLETED
            // 
            this.ISCOMPLETED.DataPropertyName = "ISCOMPLETED";
            this.ISCOMPLETED.HeaderText = "状态";
            this.ISCOMPLETED.Name = "ISCOMPLETED";
            this.ISCOMPLETED.ReadOnly = true;
            // 
            // STATUS
            // 
            this.STATUS.DataPropertyName = "STATUS";
            this.STATUS.HeaderText = "STATUS";
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            this.STATUS.Visible = false;
            // 
            // TRANSPORTATIONLINE
            // 
            this.TRANSPORTATIONLINE.DataPropertyName = "TRANSPORTATIONLINE";
            this.TRANSPORTATIONLINE.HeaderText = "TRANSPORTATIONLINE";
            this.TRANSPORTATIONLINE.Name = "TRANSPORTATIONLINE";
            this.TRANSPORTATIONLINE.ReadOnly = true;
            this.TRANSPORTATIONLINE.Visible = false;
            // 
            // FINISHTIME
            // 
            this.FINISHTIME.DataPropertyName = "FINISHTIME";
            this.FINISHTIME.HeaderText = "FINISHTIME";
            this.FINISHTIME.Name = "FINISHTIME";
            this.FINISHTIME.ReadOnly = true;
            this.FINISHTIME.Visible = false;
            // 
            // JYCODE
            // 
            this.JYCODE.DataPropertyName = "JYCODE";
            this.JYCODE.HeaderText = "JYCODE";
            this.JYCODE.Name = "JYCODE";
            this.JYCODE.ReadOnly = true;
            this.JYCODE.Visible = false;
            // 
            // TYPE
            // 
            this.TYPE.DataPropertyName = "TYPE";
            this.TYPE.HeaderText = "TYPE";
            this.TYPE.Name = "TYPE";
            this.TYPE.ReadOnly = true;
            this.TYPE.Visible = false;
            // 
            // MANTISSA
            // 
            this.MANTISSA.DataPropertyName = "MANTISSA";
            this.MANTISSA.HeaderText = "MANTISSA";
            this.MANTISSA.Name = "MANTISSA";
            this.MANTISSA.ReadOnly = true;
            this.MANTISSA.Visible = false;
            // 
            // SCANTIME
            // 
            this.SCANTIME.DataPropertyName = "SCANTIME";
            this.SCANTIME.HeaderText = "SCANTIME";
            this.SCANTIME.Name = "SCANTIME";
            this.SCANTIME.ReadOnly = true;
            this.SCANTIME.Visible = false;
            // 
            // SEQ
            // 
            this.SEQ.DataPropertyName = "SEQ";
            this.SEQ.HeaderText = "SEQ";
            this.SEQ.Name = "SEQ";
            this.SEQ.ReadOnly = true;
            this.SEQ.Visible = false;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPLENISHLINE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TROUGHNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIGARETTECODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIGARETTENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPLENISHQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISCOMPLETED;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANSPORTATIONLINE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FINISHTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn JYCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MANTISSA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCANTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ;
    }
}