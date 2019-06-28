namespace SortingControlSys
{
    partial class StatusManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtCusID = new System.Windows.Forms.TextBox();
            this.TxtRegionCode = new System.Windows.Forms.TextBox();
            this.TxtSortNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtEndNum = new System.Windows.Forms.TextBox();
            this.TxtStartNum = new System.Windows.Forms.TextBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.CmbState = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.BtnJump = new System.Windows.Forms.Button();
            this.TxtIndex = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnEnd = new System.Windows.Forms.Button();
            this.BtnFirst = new System.Windows.Forms.Button();
            this.BtnPre = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.DgvData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.BtnSearch);
            this.groupBox1.Controls.Add(this.TxtCusID);
            this.groupBox1.Controls.Add(this.TxtRegionCode);
            this.groupBox1.Controls.Add(this.TxtSortNum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1127, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据查询";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(799, 16);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 6;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtCusID
            // 
            this.TxtCusID.Location = new System.Drawing.Point(573, 17);
            this.TxtCusID.Name = "TxtCusID";
            this.TxtCusID.Size = new System.Drawing.Size(100, 21);
            this.TxtCusID.TabIndex = 5;
            // 
            // TxtRegionCode
            // 
            this.TxtRegionCode.Location = new System.Drawing.Point(318, 17);
            this.TxtRegionCode.Name = "TxtRegionCode";
            this.TxtRegionCode.Size = new System.Drawing.Size(100, 21);
            this.TxtRegionCode.TabIndex = 4;
            // 
            // TxtSortNum
            // 
            this.TxtSortNum.Location = new System.Drawing.Point(90, 17);
            this.TxtSortNum.Name = "TxtSortNum";
            this.TxtSortNum.Size = new System.Drawing.Size(100, 21);
            this.TxtSortNum.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(502, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "专卖证号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "车组号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "分拣任务号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.TxtEndNum);
            this.groupBox2.Controls.Add(this.TxtStartNum);
            this.groupBox2.Controls.Add(this.BtnUpdate);
            this.groupBox2.Controls.Add(this.CmbState);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(0, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1127, 50);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "状态修改";
            // 
            // TxtEndNum
            // 
            this.TxtEndNum.Location = new System.Drawing.Point(291, 19);
            this.TxtEndNum.Name = "TxtEndNum";
            this.TxtEndNum.Size = new System.Drawing.Size(100, 21);
            this.TxtEndNum.TabIndex = 9;
            // 
            // TxtStartNum
            // 
            this.TxtStartNum.Location = new System.Drawing.Point(90, 19);
            this.TxtStartNum.Name = "TxtStartNum";
            this.TxtStartNum.Size = new System.Drawing.Size(100, 21);
            this.TxtStartNum.TabIndex = 8;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(799, 17);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(75, 23);
            this.BtnUpdate.TabIndex = 7;
            this.BtnUpdate.Text = "更新";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // CmbState
            // 
            this.CmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbState.FormattingEnabled = true;
            this.CmbState.Items.AddRange(new object[] {
            "新增",
            "已发送",
            "已完成"});
            this.CmbState.Location = new System.Drawing.Point(552, 20);
            this.CmbState.Name = "CmbState";
            this.CmbState.Size = new System.Drawing.Size(121, 20);
            this.CmbState.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "到";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "更新任务号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "状态为";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.lblCount);
            this.groupBox3.Controls.Add(this.lblPageCount);
            this.groupBox3.Controls.Add(this.BtnJump);
            this.groupBox3.Controls.Add(this.TxtIndex);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.BtnEnd);
            this.groupBox3.Controls.Add(this.BtnFirst);
            this.groupBox3.Controls.Add(this.BtnPre);
            this.groupBox3.Controls.Add(this.BtnNext);
            this.groupBox3.Controls.Add(this.DgvData);
            this.groupBox3.Location = new System.Drawing.Point(0, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1127, 574);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询结果";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(1010, 555);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(89, 12);
            this.lblCount.TabIndex = 10;
            this.lblCount.Text = "共000000条记录";
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.Location = new System.Drawing.Point(933, 555);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(53, 12);
            this.lblPageCount.TabIndex = 9;
            this.lblPageCount.Text = "共0000页";
            // 
            // BtnJump
            // 
            this.BtnJump.Location = new System.Drawing.Point(648, 550);
            this.BtnJump.Name = "BtnJump";
            this.BtnJump.Size = new System.Drawing.Size(75, 23);
            this.BtnJump.TabIndex = 8;
            this.BtnJump.Text = "跳转";
            this.BtnJump.UseVisualStyleBackColor = true;
            this.BtnJump.Click += new System.EventHandler(this.BtnJump_Click);
            // 
            // TxtIndex
            // 
            this.TxtIndex.Location = new System.Drawing.Point(565, 552);
            this.TxtIndex.Name = "TxtIndex";
            this.TxtIndex.Size = new System.Drawing.Size(40, 21);
            this.TxtIndex.TabIndex = 7;
            this.TxtIndex.TextChanged += new System.EventHandler(this.TxtIndex_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(614, 555);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "页";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(542, 555);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "第";
            // 
            // BtnEnd
            // 
            this.BtnEnd.Location = new System.Drawing.Point(843, 550);
            this.BtnEnd.Name = "BtnEnd";
            this.BtnEnd.Size = new System.Drawing.Size(75, 23);
            this.BtnEnd.TabIndex = 4;
            this.BtnEnd.Text = "尾页";
            this.BtnEnd.UseVisualStyleBackColor = true;
            this.BtnEnd.Click += new System.EventHandler(this.BtnEnd_Click);
            // 
            // BtnFirst
            // 
            this.BtnFirst.Location = new System.Drawing.Point(353, 550);
            this.BtnFirst.Name = "BtnFirst";
            this.BtnFirst.Size = new System.Drawing.Size(75, 23);
            this.BtnFirst.TabIndex = 3;
            this.BtnFirst.Text = "首页";
            this.BtnFirst.UseVisualStyleBackColor = true;
            this.BtnFirst.Click += new System.EventHandler(this.BtnFirst_Click);
            // 
            // BtnPre
            // 
            this.BtnPre.Location = new System.Drawing.Point(441, 550);
            this.BtnPre.Name = "BtnPre";
            this.BtnPre.Size = new System.Drawing.Size(75, 23);
            this.BtnPre.TabIndex = 2;
            this.BtnPre.Text = "上一页";
            this.BtnPre.UseVisualStyleBackColor = true;
            this.BtnPre.Click += new System.EventHandler(this.BtnPre_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.Location = new System.Drawing.Point(750, 550);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(75, 23);
            this.BtnNext.TabIndex = 1;
            this.BtnNext.Text = "下一页";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // DgvData
            // 
            this.DgvData.AllowUserToAddRows = false;
            this.DgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column10,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.DgvData.Location = new System.Drawing.Point(0, 17);
            this.DgvData.Name = "DgvData";
            this.DgvData.ReadOnly = true;
            this.DgvData.RowHeadersVisible = false;
            this.DgvData.RowTemplate.Height = 23;
            this.DgvData.Size = new System.Drawing.Size(1127, 528);
            this.DgvData.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "户序";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "分拣任务号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "车组号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "客户编码";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "客户名称";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "卷烟编码";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "卷烟名称";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "状态位";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "通道";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "订单号";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // StatusManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 686);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "StatusManager";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "异形烟状态管理";
            this.Resize += new System.EventHandler(this.StatusManager_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtCusID;
        private System.Windows.Forms.TextBox TxtRegionCode;
        private System.Windows.Forms.TextBox TxtSortNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtEndNum;
        private System.Windows.Forms.TextBox TxtStartNum;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.ComboBox CmbState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DgvData;
        private System.Windows.Forms.Button BtnEnd;
        private System.Windows.Forms.Button BtnFirst;
        private System.Windows.Forms.Button BtnPre;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Button BtnJump;
        private System.Windows.Forms.TextBox TxtIndex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;

    }
}