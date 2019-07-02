namespace HighSpeed.OrderHandle
{
    partial class w_Cigarette_LeftCount
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
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.打印 = new System.Windows.Forms.Button();
            this.codedata = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cigarettecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cigarettename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineseq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mantissa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THRESHOLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codedata)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.打印);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 39);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(309, 8);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "修改";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(468, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "导出";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // 打印
            // 
            this.打印.Location = new System.Drawing.Point(377, 8);
            this.打印.Name = "打印";
            this.打印.Size = new System.Drawing.Size(75, 23);
            this.打印.TabIndex = 0;
            this.打印.Text = "打印";
            this.打印.UseVisualStyleBackColor = true;
            // 
            // codedata
            // 
            this.codedata.AllowUserToAddRows = false;
            this.codedata.AllowUserToDeleteRows = false;
            this.codedata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codedata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.codedata.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.codedata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.codedata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cigarettecode,
            this.cigarettename,
            this.machineseq,
            this.mantissa,
            this.THRESHOLD});
            this.codedata.Location = new System.Drawing.Point(0, 45);
            this.codedata.MultiSelect = false;
            this.codedata.Name = "codedata";
            this.codedata.RowHeadersWidth = 30;
            this.codedata.RowTemplate.Height = 23;
            this.codedata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.codedata.Size = new System.Drawing.Size(904, 447);
            this.codedata.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Location = new System.Drawing.Point(247, 202);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 91);
            this.panel2.TabIndex = 3;
            this.panel2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "正在读取数据...";
            this.label2.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 49);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(380, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "请选择类型:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "立式烟仓",
            "卧式烟仓"});
            this.comboBox1.Location = new System.Drawing.Point(91, 13);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(105, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // cigarettecode
            // 
            this.cigarettecode.DataPropertyName = "cigarettecode";
            this.cigarettecode.HeaderText = "品牌代码";
            this.cigarettecode.Name = "cigarettecode";
            this.cigarettecode.ReadOnly = true;
            // 
            // cigarettename
            // 
            this.cigarettename.DataPropertyName = "cigarettename";
            this.cigarettename.HeaderText = "品牌名称";
            this.cigarettename.Name = "cigarettename";
            this.cigarettename.ReadOnly = true;
            // 
            // machineseq
            // 
            this.machineseq.DataPropertyName = "machineseq";
            this.machineseq.HeaderText = "烟道号";
            this.machineseq.Name = "machineseq";
            this.machineseq.ReadOnly = true;
            // 
            // mantissa
            // 
            this.mantissa.DataPropertyName = "mantissa";
            this.mantissa.HeaderText = "尾数";
            this.mantissa.Name = "mantissa";
            this.mantissa.ReadOnly = true;
            // 
            // THRESHOLD
            // 
            this.THRESHOLD.DataPropertyName = "THRESHOLD";
            this.THRESHOLD.HeaderText = "阀值";
            this.THRESHOLD.Name = "THRESHOLD";
            this.THRESHOLD.ReadOnly = true;
            // 
            // w_Cigarette_LeftCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 494);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.codedata);
            this.Controls.Add(this.panel1);
            this.Name = "w_Cigarette_LeftCount";
            this.Text = "品牌尾数维护";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codedata)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button 打印;
        private System.Windows.Forms.DataGridView codedata;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cigarettecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cigarettename;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineseq;
        private System.Windows.Forms.DataGridViewTextBoxColumn mantissa;
        private System.Windows.Forms.DataGridViewTextBoxColumn THRESHOLD;
    }
}