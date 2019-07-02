﻿namespace HighSpeed.OrderHandle
{
    partial class w_Batch
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
            this.cbnormal = new System.Windows.Forms.CheckBox();
            this.cbunnormal = new System.Windows.Forms.CheckBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.batchdata = new System.Windows.Forms.DataGridView();
            this.batchcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.starttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.batchdata)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbnormal);
            this.panel1.Controls.Add(this.cbunnormal);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_new);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 60);
            this.panel1.TabIndex = 1;
            // 
            // cbnormal
            // 
            this.cbnormal.AutoSize = true;
            this.cbnormal.Checked = true;
            this.cbnormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbnormal.Location = new System.Drawing.Point(853, 18);
            this.cbnormal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbnormal.Name = "cbnormal";
            this.cbnormal.Size = new System.Drawing.Size(74, 19);
            this.cbnormal.TabIndex = 3;
            this.cbnormal.Text = "标准烟";
            this.cbnormal.UseVisualStyleBackColor = true;
            this.cbnormal.Visible = false;
            // 
            // cbunnormal
            // 
            this.cbunnormal.AutoSize = true;
            this.cbunnormal.Checked = true;
            this.cbunnormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbunnormal.Location = new System.Drawing.Point(1000, 18);
            this.cbunnormal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbunnormal.Name = "cbunnormal";
            this.cbunnormal.Size = new System.Drawing.Size(74, 19);
            this.cbunnormal.TabIndex = 2;
            this.cbunnormal.Text = "异型烟";
            this.cbunnormal.UseVisualStyleBackColor = true;
            this.cbunnormal.Visible = false;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(185, 18);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(100, 29);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "关闭批次";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(33, 18);
            this.btn_new.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(100, 29);
            this.btn_new.TabIndex = 0;
            this.btn_new.Text = "创建批次";
            this.btn_new.UseCompatibleTextRendering = true;
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // batchdata
            // 
            this.batchdata.AllowUserToAddRows = false;
            this.batchdata.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.batchdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.batchdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.batchcode,
            this.starttime,
            this.endtime,
            this.类型,
            this.status});
            this.batchdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batchdata.Location = new System.Drawing.Point(0, 60);
            this.batchdata.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.batchdata.MultiSelect = false;
            this.batchdata.Name = "batchdata";
            this.batchdata.ReadOnly = true;
            this.batchdata.RowTemplate.Height = 23;
            this.batchdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.batchdata.Size = new System.Drawing.Size(1095, 339);
            this.batchdata.TabIndex = 2;
            this.batchdata.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.batchdata_CellFormatting);
            this.batchdata.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.batchdata_RowPostPaint);
            // 
            // batchcode
            // 
            this.batchcode.DataPropertyName = "batchcode";
            this.batchcode.HeaderText = "批次编号";
            this.batchcode.Name = "batchcode";
            this.batchcode.ReadOnly = true;
            // 
            // starttime
            // 
            this.starttime.DataPropertyName = "starttime";
            this.starttime.HeaderText = "创建时间";
            this.starttime.Name = "starttime";
            this.starttime.ReadOnly = true;
            this.starttime.Width = 150;
            // 
            // endtime
            // 
            this.endtime.DataPropertyName = "endtime";
            this.endtime.HeaderText = "关闭时间";
            this.endtime.Name = "endtime";
            this.endtime.ReadOnly = true;
            this.endtime.Width = 150;
            // 
            // 类型
            // 
            this.类型.DataPropertyName = "batchtype";
            this.类型.HeaderText = "类型";
            this.类型.Name = "类型";
            this.类型.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "state";
            this.status.HeaderText = "批次状态";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // w_Batch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 399);
            this.Controls.Add(this.batchdata);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "w_Batch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "分拣批次管理";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.batchdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbnormal;
        private System.Windows.Forms.CheckBox cbunnormal;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_new;
        public System.Windows.Forms.DataGridView batchdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn starttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn endtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}