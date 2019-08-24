namespace HighSpeed.OrderHandle
{
    partial class win_schedule
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblOrderCount = new System.Windows.Forms.Label();
            this.LblCusCount = new System.Windows.Forms.Label();
            this.btn_all = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_codestr = new System.Windows.Forms.TextBox();
            this.btn_schedule = new System.Windows.Forms.Button();
            this.lab_showinfo = new System.Windows.Forms.Label();
            this.orderdata = new System.Windows.Forms.DataGridView();
            this.checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regioncode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderdata)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblOrderCount);
            this.panel1.Controls.Add(this.LblCusCount);
            this.panel1.Controls.Add(this.btn_all);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.txt_codestr);
            this.panel1.Controls.Add(this.btn_schedule);
            this.panel1.Controls.Add(this.lab_showinfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 47);
            this.panel1.TabIndex = 0;
            // 
            // LblOrderCount
            // 
            this.LblOrderCount.AutoSize = true;
            this.LblOrderCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblOrderCount.Location = new System.Drawing.Point(967, 16);
            this.LblOrderCount.Name = "LblOrderCount";
            this.LblOrderCount.Size = new System.Drawing.Size(96, 16);
            this.LblOrderCount.TabIndex = 16;
            this.LblOrderCount.Text = "总订单量：0";
            // 
            // LblCusCount
            // 
            this.LblCusCount.AutoSize = true;
            this.LblCusCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblCusCount.Location = new System.Drawing.Point(847, 16);
            this.LblCusCount.Name = "LblCusCount";
            this.LblCusCount.Size = new System.Drawing.Size(112, 16);
            this.LblCusCount.TabIndex = 15;
            this.LblCusCount.Text = "总订货户数：0";
            // 
            // btn_all
            // 
            this.btn_all.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_all.Location = new System.Drawing.Point(681, 7);
            this.btn_all.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(80, 30);
            this.btn_all.TabIndex = 14;
            this.btn_all.Text = "全 选";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1031, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "设置排序";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_search.Location = new System.Drawing.Point(600, 7);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(80, 30);
            this.btn_search.TabIndex = 10;
            this.btn_search.Text = "查 询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_codestr
            // 
            this.txt_codestr.Location = new System.Drawing.Point(1055, 13);
            this.txt_codestr.Name = "txt_codestr";
            this.txt_codestr.Size = new System.Drawing.Size(60, 21);
            this.txt_codestr.TabIndex = 9;
            this.txt_codestr.Visible = false;
            // 
            // btn_schedule
            // 
            this.btn_schedule.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_schedule.Location = new System.Drawing.Point(765, 7);
            this.btn_schedule.Name = "btn_schedule";
            this.btn_schedule.Size = new System.Drawing.Size(80, 30);
            this.btn_schedule.TabIndex = 5;
            this.btn_schedule.Text = "预排程";
            this.btn_schedule.UseVisualStyleBackColor = true;
            this.btn_schedule.Click += new System.EventHandler(this.btn_schedule_Click);
            // 
            // lab_showinfo
            // 
            this.lab_showinfo.AutoSize = true;
            this.lab_showinfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_showinfo.Location = new System.Drawing.Point(12, 16);
            this.lab_showinfo.Name = "lab_showinfo";
            this.lab_showinfo.Size = new System.Drawing.Size(595, 14);
            this.lab_showinfo.TabIndex = 2;
            this.lab_showinfo.Text = "勾选要排程的订单数据，点击“排程”按钮，进行排程操作。排程的先后顺序由勾选顺序决定。";
            // 
            // orderdata
            // 
            this.orderdata.AllowUserToAddRows = false;
            this.orderdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderdata.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orderdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.orderdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkbox,
            this.Column1,
            this.regioncode,
            this.count,
            this.qty});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.orderdata.DefaultCellStyle = dataGridViewCellStyle2;
            this.orderdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderdata.Location = new System.Drawing.Point(0, 47);
            this.orderdata.MultiSelect = false;
            this.orderdata.Name = "orderdata";
            this.orderdata.RowTemplate.Height = 23;
            this.orderdata.Size = new System.Drawing.Size(1028, 215);
            this.orderdata.TabIndex = 1;
            this.orderdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderdata_CellContentClick);
            // 
            // checkbox
            // 
            this.checkbox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.checkbox.FalseValue = "false";
            this.checkbox.HeaderText = "选择";
            this.checkbox.Name = "checkbox";
            this.checkbox.TrueValue = "true";
            this.checkbox.Width = 46;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "synseq";
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            // 
            // regioncode
            // 
            this.regioncode.DataPropertyName = "regioncode";
            this.regioncode.HeaderText = "车组号";
            this.regioncode.Name = "regioncode";
            // 
            // count
            // 
            this.count.DataPropertyName = "count";
            this.count.HeaderText = "订货户数";
            this.count.Name = "count";
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            this.qty.HeaderText = "订单量";
            this.qty.Name = "qty";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(146, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(826, 89);
            this.panel2.TabIndex = 3;
            this.panel2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "正在读取数据...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(33, 42);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(741, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
            // 
            // win_schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 262);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.orderdata);
            this.Controls.Add(this.panel1);
            this.Name = "win_schedule";
            this.Text = "预排程";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderdata)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView orderdata;
        private System.Windows.Forms.Button btn_schedule;
        private System.Windows.Forms.Label lab_showinfo;
        private System.Windows.Forms.TextBox txt_codestr;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn regioncode;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.Label LblOrderCount;
        private System.Windows.Forms.Label LblCusCount;
    }
}