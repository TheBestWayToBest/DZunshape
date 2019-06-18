namespace HighSpeed.OrderHandle
{
    partial class w_SortFm
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
            this.btnTransfor = new System.Windows.Forms.Button();
            this.btnVid = new System.Windows.Forms.Button();
            this.btnPokeSeq = new System.Windows.Forms.Button();
            this.btnRef = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_replenishplan = new System.Windows.Forms.Button();
            this.lblInFO = new System.Windows.Forms.Label();
            this.btnSort = new System.Windows.Forms.Button();
            this.dgvSortInfo = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.synseq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regioncode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortInfo)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimerByTime
            // 
            this.TimerByTime.Interval = 1000;
            // 
            // btnTransfor
            // 
            this.btnTransfor.Location = new System.Drawing.Point(1137, 15);
            this.btnTransfor.Margin = new System.Windows.Forms.Padding(4);
            this.btnTransfor.Name = "btnTransfor";
            this.btnTransfor.Size = new System.Drawing.Size(100, 29);
            this.btnTransfor.TabIndex = 6;
            this.btnTransfor.Text = "订单拆分";
            this.btnTransfor.UseVisualStyleBackColor = true;
            this.btnTransfor.Visible = false;
            // 
            // btnVid
            // 
            this.btnVid.Location = new System.Drawing.Point(1255, 15);
            this.btnVid.Margin = new System.Windows.Forms.Padding(4);
            this.btnVid.Name = "btnVid";
            this.btnVid.Size = new System.Drawing.Size(131, 29);
            this.btnVid.TabIndex = 5;
            this.btnVid.Text = "验证下游数据";
            this.btnVid.UseVisualStyleBackColor = true;
            this.btnVid.Visible = false;
            // 
            // btnPokeSeq
            // 
            this.btnPokeSeq.Location = new System.Drawing.Point(1008, 15);
            this.btnPokeSeq.Margin = new System.Windows.Forms.Padding(4);
            this.btnPokeSeq.Name = "btnPokeSeq";
            this.btnPokeSeq.Size = new System.Drawing.Size(100, 29);
            this.btnPokeSeq.TabIndex = 4;
            this.btnPokeSeq.Text = "条烟顺序";
            this.btnPokeSeq.UseVisualStyleBackColor = true;
            this.btnPokeSeq.Visible = false;
            // 
            // btnRef
            // 
            this.btnRef.Location = new System.Drawing.Point(516, 10);
            this.btnRef.Margin = new System.Windows.Forms.Padding(4);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(100, 29);
            this.btnRef.TabIndex = 3;
            this.btnRef.Text = "刷 新";
            this.btnRef.UseVisualStyleBackColor = true;
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1349, 60);
            this.panel1.TabIndex = 7;
            // 
            // btn_replenishplan
            // 
            this.btn_replenishplan.Location = new System.Drawing.Point(777, 10);
            this.btn_replenishplan.Name = "btn_replenishplan";
            this.btn_replenishplan.Size = new System.Drawing.Size(99, 29);
            this.btn_replenishplan.TabIndex = 7;
            this.btn_replenishplan.Text = "补货计划";
            this.btn_replenishplan.UseVisualStyleBackColor = true;
            this.btn_replenishplan.Click += new System.EventHandler(this.btn_replenishplan_Click);
            // 
            // lblInFO
            // 
            this.lblInFO.AutoSize = true;
            this.lblInFO.Font = new System.Drawing.Font("宋体", 9F);
            this.lblInFO.Location = new System.Drawing.Point(16, 15);
            this.lblInFO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInFO.Name = "lblInFO";
            this.lblInFO.Size = new System.Drawing.Size(0, 15);
            this.lblInFO.TabIndex = 1;
            // 
            // btnSort
            // 
            this.btnSort.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSort.Location = new System.Drawing.Point(649, 10);
            this.btnSort.Margin = new System.Windows.Forms.Padding(4);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(100, 29);
            this.btnSort.TabIndex = 0;
            this.btnSort.Text = "排  程";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // dgvSortInfo
            // 
            this.dgvSortInfo.AllowUserToAddRows = false;
            this.dgvSortInfo.AllowUserToDeleteRows = false;
            this.dgvSortInfo.AllowUserToResizeColumns = false;
            this.dgvSortInfo.AllowUserToResizeRows = false;
            this.dgvSortInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSortInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSortInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.synseq,
            this.regioncode,
            this.count,
            this.qty});
            this.dgvSortInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSortInfo.Location = new System.Drawing.Point(0, 60);
            this.dgvSortInfo.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSortInfo.MultiSelect = false;
            this.dgvSortInfo.Name = "dgvSortInfo";
            this.dgvSortInfo.ReadOnly = true;
            this.dgvSortInfo.RowTemplate.Height = 23;
            this.dgvSortInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSortInfo.Size = new System.Drawing.Size(1349, 772);
            this.dgvSortInfo.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pbLoading);
            this.panel3.Font = new System.Drawing.Font("宋体", 11F);
            this.panel3.Location = new System.Drawing.Point(231, 66);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(477, 124);
            this.panel3.TabIndex = 9;
            this.panel3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 19);
            this.label1.TabIndex = 28;
            this.label1.Text = "条烟顺序生成中。。";
            // 
            // pbLoading
            // 
            this.pbLoading.Location = new System.Drawing.Point(-3, -2);
            this.pbLoading.Margin = new System.Windows.Forms.Padding(4);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(275, 125);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoading.TabIndex = 27;
            this.pbLoading.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTime);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Location = new System.Drawing.Point(19, 82);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1063, 111);
            this.panel2.TabIndex = 29;
            this.panel2.Visible = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("宋体", 11F);
            this.lblTime.Location = new System.Drawing.Point(41, 18);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(95, 19);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "已用时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(245, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "正在排程......";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(44, 52);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(988, 29);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
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
            this.qty.Width = 120;
            // 
            // w_SortFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 832);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvSortInfo);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "w_SortFm";
            this.Text = "任务排序";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortInfo)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimerByTime;
        private System.Windows.Forms.Button btnTransfor;
        private System.Windows.Forms.Button btnVid;
        private System.Windows.Forms.Button btnPokeSeq;
        private System.Windows.Forms.Button btnRef;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.DataGridView dgvSortInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblInFO;
        private System.Windows.Forms.Button btn_replenishplan;
        private System.Windows.Forms.DataGridViewTextBoxColumn synseq;
        private System.Windows.Forms.DataGridViewTextBoxColumn regioncode;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
    }
}