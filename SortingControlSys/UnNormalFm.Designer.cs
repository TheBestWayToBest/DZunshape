namespace SortingControlSys
{
    partial class UnNormalFm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnNormalFm));
            this.TimeToClike = new System.Windows.Forms.Timer(this.components);
            this.task_data = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regioncode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regiondesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerSendTask = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.list_data = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnEnd = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.BtnStatrt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.task_data)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimeToClike
            // 
            this.TimeToClike.Interval = 5000;
            this.TimeToClike.Tick += new System.EventHandler(this.TimeToClike_Tick);
            // 
            // task_data
            // 
            this.task_data.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.task_data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.task_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.task_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.task_data.ColumnHeadersHeight = 35;
            this.task_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.regioncode,
            this.regiondesc,
            this.cuscount,
            this.finishqty,
            this.percent});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.task_data.DefaultCellStyle = dataGridViewCellStyle3;
            this.task_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.task_data.Location = new System.Drawing.Point(0, 43);
            this.task_data.Name = "task_data";
            this.task_data.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.task_data.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.task_data.RowHeadersWidth = 35;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.task_data.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.task_data.RowTemplate.Height = 35;
            this.task_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.task_data.Size = new System.Drawing.Size(1038, 403);
            this.task_data.TabIndex = 47;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "货主";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "订单日期";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "批次";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // regioncode
            // 
            this.regioncode.HeaderText = "线路编号";
            this.regioncode.Name = "regioncode";
            this.regioncode.ReadOnly = true;
            // 
            // regiondesc
            // 
            this.regiondesc.HeaderText = "线路名称";
            this.regiondesc.Name = "regiondesc";
            this.regiondesc.ReadOnly = true;
            // 
            // cuscount
            // 
            this.cuscount.HeaderText = "客户数";
            this.cuscount.Name = "cuscount";
            this.cuscount.ReadOnly = true;
            // 
            // finishqty
            // 
            this.finishqty.HeaderText = "完成量";
            this.finishqty.Name = "finishqty";
            this.finishqty.ReadOnly = true;
            // 
            // percent
            // 
            this.percent.HeaderText = "完成百分比";
            this.percent.Name = "percent";
            this.percent.ReadOnly = true;
            // 
            // timerSendTask
            // 
            this.timerSendTask.Tick += new System.EventHandler(this.timerSendTask_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(825, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 2;
            // 
            // list_data
            // 
            this.list_data.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.list_data.FormattingEnabled = true;
            this.list_data.ItemHeight = 12;
            this.list_data.Location = new System.Drawing.Point(0, 446);
            this.list_data.Name = "list_data";
            this.list_data.Size = new System.Drawing.Size(1038, 220);
            this.list_data.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "提示信息";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 666);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1038, 19);
            this.panel2.TabIndex = 44;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 43);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackgroundImage = global::SortingControlSys.Properties.Resources.edit;
            this.BtnUpdate.Location = new System.Drawing.Point(288, 0);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(101, 43);
            this.BtnUpdate.TabIndex = 9;
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnEnd
            // 
            this.BtnEnd.BackgroundImage = global::SortingControlSys.Properties.Resources.stop;
            this.BtnEnd.Location = new System.Drawing.Point(97, 0);
            this.BtnEnd.Name = "BtnEnd";
            this.BtnEnd.Size = new System.Drawing.Size(99, 43);
            this.BtnEnd.TabIndex = 8;
            this.BtnEnd.UseVisualStyleBackColor = true;
            this.BtnEnd.Click += new System.EventHandler(this.BtnEnd_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.BtnUpdate);
            this.panel3.Controls.Add(this.BtnEnd);
            this.panel3.Controls.Add(this.BtnRefresh);
            this.panel3.Controls.Add(this.BtnStatrt);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1038, 43);
            this.panel3.TabIndex = 36;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.BackgroundImage = global::SortingControlSys.Properties.Resources.rfresh;
            this.BtnRefresh.Location = new System.Drawing.Point(194, 0);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(99, 43);
            this.BtnRefresh.TabIndex = 7;
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // BtnStatrt
            // 
            this.BtnStatrt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnStatrt.BackgroundImage")));
            this.BtnStatrt.Location = new System.Drawing.Point(0, 0);
            this.BtnStatrt.Name = "BtnStatrt";
            this.BtnStatrt.Size = new System.Drawing.Size(99, 43);
            this.BtnStatrt.TabIndex = 0;
            this.BtnStatrt.UseVisualStyleBackColor = true;
            this.BtnStatrt.Click += new System.EventHandler(this.BtnStatrt_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 43);
            this.panel1.TabIndex = 43;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(953, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "导出";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(782, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "打印";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(692, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "清空条件";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(531, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(484, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "品名：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(872, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // UnNormalFm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1038, 685);
            this.Controls.Add(this.task_data);
            this.Controls.Add(this.list_data);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UnNormalFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "异型烟分拣信息系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.task_data)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimeToClike;
        private System.Windows.Forms.DataGridView task_data;
        private System.Windows.Forms.Timer timerSendTask;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox list_data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnEnd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnStatrt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn regioncode;
        private System.Windows.Forms.DataGridViewTextBoxColumn regiondesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn percent;

    }
}