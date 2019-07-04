namespace HighspeedNew.OrderHandle
{
    partial class w_SortFm_New
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
            this.TimerByTime = new System.Windows.Forms.Timer(this.components);
            this.btnRef = new System.Windows.Forms.Button();
            this.btn_replenishplan = new System.Windows.Forms.Button();
            this.lblInFO = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnTransfor = new System.Windows.Forms.Button();
            this.btnVid = new System.Windows.Forms.Button();
            this.btnPokeSeq = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.dgvSortInfo = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.synseq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regioncode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortInfo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerByTime
            // 
            this.TimerByTime.Interval = 1000;
            // 
            // btnRef
            // 
            this.btnRef.Location = new System.Drawing.Point(387, 8);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(75, 23);
            this.btnRef.TabIndex = 3;
            this.btnRef.Text = "刷 新";
            this.btnRef.UseVisualStyleBackColor = true;
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
            // 
            // btn_replenishplan
            // 
            this.btn_replenishplan.Location = new System.Drawing.Point(583, 8);
            this.btn_replenishplan.Margin = new System.Windows.Forms.Padding(2);
            this.btn_replenishplan.Name = "btn_replenishplan";
            this.btn_replenishplan.Size = new System.Drawing.Size(74, 23);
            this.btn_replenishplan.TabIndex = 7;
            this.btn_replenishplan.Text = "补货计划";
            this.btn_replenishplan.UseVisualStyleBackColor = true;
            this.btn_replenishplan.Click += new System.EventHandler(this.btn_replenishplan_Click);
            // 
            // lblInFO
            // 
            this.lblInFO.AutoSize = true;
            this.lblInFO.Font = new System.Drawing.Font("宋体", 9F);
            this.lblInFO.Location = new System.Drawing.Point(12, 12);
            this.lblInFO.Name = "lblInFO";
            this.lblInFO.Size = new System.Drawing.Size(0, 12);
            this.lblInFO.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTime);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Location = new System.Drawing.Point(14, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(797, 89);
            this.panel2.TabIndex = 32;
            this.panel2.Visible = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("宋体", 11F);
            this.lblTime.Location = new System.Drawing.Point(31, 14);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(75, 15);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "已用时间:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pbLoading);
            this.panel3.Font = new System.Drawing.Font("宋体", 11F);
            this.panel3.Location = new System.Drawing.Point(173, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(359, 100);
            this.panel3.TabIndex = 9;
            this.panel3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "条烟顺序生成中。。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(184, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "正在排程......";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(33, 42);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(741, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
            // 
            // btnTransfor
            // 
            this.btnTransfor.Location = new System.Drawing.Point(853, 12);
            this.btnTransfor.Name = "btnTransfor";
            this.btnTransfor.Size = new System.Drawing.Size(75, 23);
            this.btnTransfor.TabIndex = 6;
            this.btnTransfor.Text = "订单拆分";
            this.btnTransfor.UseVisualStyleBackColor = true;
            this.btnTransfor.Visible = false;
            // 
            // btnVid
            // 
            this.btnVid.Location = new System.Drawing.Point(941, 12);
            this.btnVid.Name = "btnVid";
            this.btnVid.Size = new System.Drawing.Size(98, 23);
            this.btnVid.TabIndex = 5;
            this.btnVid.Text = "验证下游数据";
            this.btnVid.UseVisualStyleBackColor = true;
            this.btnVid.Visible = false;
            // 
            // btnPokeSeq
            // 
            this.btnPokeSeq.Location = new System.Drawing.Point(756, 12);
            this.btnPokeSeq.Name = "btnPokeSeq";
            this.btnPokeSeq.Size = new System.Drawing.Size(75, 23);
            this.btnPokeSeq.TabIndex = 4;
            this.btnPokeSeq.Text = "条烟顺序";
            this.btnPokeSeq.UseVisualStyleBackColor = true;
            this.btnPokeSeq.Visible = false;
            // 
            // btnSort
            // 
            this.btnSort.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSort.Location = new System.Drawing.Point(487, 8);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 0;
            this.btnSort.Text = "排  程";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // dgvSortInfo
            // 
            this.dgvSortInfo.AllowUserToAddRows = false;
            this.dgvSortInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSortInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSortInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.synseq,
            this.regioncode,
            this.count,
            this.qty,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15});
            this.dgvSortInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSortInfo.Location = new System.Drawing.Point(0, 48);
            this.dgvSortInfo.MultiSelect = false;
            this.dgvSortInfo.Name = "dgvSortInfo";
            this.dgvSortInfo.ReadOnly = true;
            this.dgvSortInfo.RowTemplate.Height = 23;
            this.dgvSortInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSortInfo.Size = new System.Drawing.Size(1012, 551);
            this.dgvSortInfo.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_replenishplan);
            this.panel1.Controls.Add(this.btnTransfor);
            this.panel1.Controls.Add(this.btnVid);
            this.panel1.Controls.Add(this.btnPokeSeq);
            this.panel1.Controls.Add(this.btnRef);
            this.panel1.Controls.Add(this.lblInFO);
            this.panel1.Controls.Add(this.btnSort);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 48);
            this.panel1.TabIndex = 30;
            // 
            // pbLoading
            // 
            this.pbLoading.Location = new System.Drawing.Point(-2, -2);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(206, 100);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoading.TabIndex = 27;
            this.pbLoading.TabStop = false;
            // 
            // synseq
            // 
            this.synseq.DataPropertyName = "SYNSEQ";
            this.synseq.HeaderText = "序号";
            this.synseq.Name = "synseq";
            this.synseq.ReadOnly = true;
            // 
            // regioncode
            // 
            this.regioncode.DataPropertyName = "REGIONCODE";
            this.regioncode.HeaderText = "车组号";
            this.regioncode.Name = "regioncode";
            this.regioncode.ReadOnly = true;
            // 
            // count
            // 
            this.count.DataPropertyName = "COUNT";
            this.count.HeaderText = "订货户数";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "QTY";
            this.qty.HeaderText = "订单条烟数量";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "FinishQTY";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "FinishCount";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Rate";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MACHINESEQ";
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "GROUPNO";
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "POKENUM";
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "UNIONTASKNUM";
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "TROUGHNUM";
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "BATCHODE";
            this.Column10.HeaderText = "Column10";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "CUSTOMERNAME";
            this.Column11.HeaderText = "Column11";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "ORDERDATE";
            this.Column12.HeaderText = "Column12";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "LINENUM";
            this.Column13.HeaderText = "Column13";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "FinishCountStr";
            this.Column14.HeaderText = "Column14";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Visible = false;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "FinishQtyStr";
            this.Column15.HeaderText = "Column15";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Visible = false;
            // 
            // w_SortFm_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 599);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvSortInfo);
            this.Controls.Add(this.panel1);
            this.Name = "w_SortFm_New";
            this.Text = "w_SortFm_New";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimerByTime;
        private System.Windows.Forms.Button btnRef;
        private System.Windows.Forms.Button btn_replenishplan;
        private System.Windows.Forms.Label lblInFO;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnTransfor;
        private System.Windows.Forms.Button btnVid;
        private System.Windows.Forms.Button btnPokeSeq;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.DataGridView dgvSortInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn synseq;
        private System.Windows.Forms.DataGridViewTextBoxColumn regioncode;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
    }
}