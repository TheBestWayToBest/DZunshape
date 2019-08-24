namespace HighSpeed.OrderHandle
{
    partial class w_Order_Recieve
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datePick = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_showinfo = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_recieve = new System.Windows.Forms.Button();
            this.txt_codestr = new System.Windows.Forms.TextBox();
            this.btn_all = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSync = new System.Windows.Forms.Button();
            this.orderdata = new System.Windows.Forms.DataGridView();
            this.checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderdata)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // datePick
            // 
            this.datePick.CustomFormat = "yyyy-MM-dd";
            this.datePick.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.datePick.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePick.Location = new System.Drawing.Point(90, 7);
            this.datePick.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datePick.Name = "datePick";
            this.datePick.Size = new System.Drawing.Size(137, 26);
            this.datePick.TabIndex = 0;
            this.datePick.Value = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "订单日期";
            // 
            // lab_showinfo
            // 
            this.lab_showinfo.AutoSize = true;
            this.lab_showinfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_showinfo.Location = new System.Drawing.Point(648, 14);
            this.lab_showinfo.Name = "lab_showinfo";
            this.lab_showinfo.Size = new System.Drawing.Size(792, 16);
            this.lab_showinfo.TabIndex = 2;
            this.lab_showinfo.Text = "勾选要接收的订单数据，点击“接收”按钮，进行订单接收操作。根据接收量的不同，接收过程需要一定时间。";
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_search.Location = new System.Drawing.Point(238, 7);
            this.btn_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(80, 30);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "查 询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_recieve
            // 
            this.btn_recieve.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_recieve.Location = new System.Drawing.Point(410, 8);
            this.btn_recieve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_recieve.Name = "btn_recieve";
            this.btn_recieve.Size = new System.Drawing.Size(80, 30);
            this.btn_recieve.TabIndex = 4;
            this.btn_recieve.Text = "接 收";
            this.btn_recieve.UseVisualStyleBackColor = true;
            this.btn_recieve.Click += new System.EventHandler(this.btn_recieve_Click);
            // 
            // txt_codestr
            // 
            this.txt_codestr.Enabled = false;
            this.txt_codestr.Location = new System.Drawing.Point(1126, 8);
            this.txt_codestr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_codestr.Name = "txt_codestr";
            this.txt_codestr.Size = new System.Drawing.Size(60, 21);
            this.txt_codestr.TabIndex = 8;
            this.txt_codestr.Visible = false;
            // 
            // btn_all
            // 
            this.btn_all.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_all.Location = new System.Drawing.Point(324, 7);
            this.btn_all.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(80, 30);
            this.btn_all.TabIndex = 9;
            this.btn_all.Text = "全 选";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSync);
            this.panel1.Controls.Add(this.btn_all);
            this.panel1.Controls.Add(this.txt_codestr);
            this.panel1.Controls.Add(this.btn_recieve);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.lab_showinfo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.datePick);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 55);
            this.panel1.TabIndex = 3;
            // 
            // btnSync
            // 
            this.btnSync.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSync.Location = new System.Drawing.Point(496, 8);
            this.btnSync.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(115, 30);
            this.btnSync.TabIndex = 10;
            this.btnSync.Text = "营销接口同步";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
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
            this.RegionCode,
            this.OrderCount,
            this.OrderNum});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.orderdata.DefaultCellStyle = dataGridViewCellStyle2;
            this.orderdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderdata.Location = new System.Drawing.Point(0, 55);
            this.orderdata.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.orderdata.Name = "orderdata";
            this.orderdata.RowTemplate.Height = 23;
            this.orderdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orderdata.Size = new System.Drawing.Size(1028, 207);
            this.orderdata.TabIndex = 4;
            this.orderdata.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderdata_CellEndEdit);
            // 
            // checkbox
            // 
            this.checkbox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.checkbox.FalseValue = "false";
            this.checkbox.HeaderText = "选择";
            this.checkbox.Name = "checkbox";
            this.checkbox.TrueValue = "true";
            this.checkbox.Width = 46;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RowNum";
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // RegionCode
            // 
            this.RegionCode.DataPropertyName = "RegionCode";
            this.RegionCode.HeaderText = "车组号";
            this.RegionCode.Name = "RegionCode";
            this.RegionCode.ReadOnly = true;
            // 
            // OrderCount
            // 
            this.OrderCount.DataPropertyName = "OrderCount";
            this.OrderCount.HeaderText = "订货户数";
            this.OrderCount.Name = "OrderCount";
            this.OrderCount.ReadOnly = true;
            // 
            // OrderNum
            // 
            this.OrderNum.DataPropertyName = "OrderNum";
            this.OrderNum.HeaderText = "订单量";
            this.OrderNum.Name = "OrderNum";
            this.OrderNum.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(182, 106);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(826, 90);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "正在读取数据...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(33, 42);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(741, 22);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // w_Order_Recieve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 262);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.orderdata);
            this.Controls.Add(this.panel1);
            this.Name = "w_Order_Recieve";
            this.Text = "订单接收";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderdata)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_showinfo;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_recieve;
        private System.Windows.Forms.TextBox txt_codestr;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView orderdata;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSync;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNum;
    }
}