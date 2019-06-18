namespace HighspeedNew.OrderHandle
{
    partial class w_schedulereport
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
            this.orderdata = new System.Windows.Forms.DataGridView();
            this.车组号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cigarettecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cigarettename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.排程数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_print = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.orderdata)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderdata
            // 
            this.orderdata.AllowUserToAddRows = false;
            this.orderdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.车组号,
            this.cigarettecode,
            this.cigarettename,
            this.orderqty,
            this.排程数量});
            this.orderdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderdata.Location = new System.Drawing.Point(0, 43);
            this.orderdata.Name = "orderdata";
            this.orderdata.ReadOnly = true;
            this.orderdata.RowTemplate.Height = 23;
            this.orderdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orderdata.Size = new System.Drawing.Size(1017, 283);
            this.orderdata.TabIndex = 3;
            // 
            // 车组号
            // 
            this.车组号.DataPropertyName = "regioncode";
            this.车组号.HeaderText = "车组号";
            this.车组号.Name = "车组号";
            this.车组号.ReadOnly = true;
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
            // orderqty
            // 
            this.orderqty.DataPropertyName = "quantity";
            this.orderqty.HeaderText = "订货数量";
            this.orderqty.Name = "orderqty";
            this.orderqty.ReadOnly = true;
            // 
            // 排程数量
            // 
            this.排程数量.DataPropertyName = "pokenum";
            this.排程数量.HeaderText = "排程数量";
            this.排程数量.Name = "排程数量";
            this.排程数量.ReadOnly = true;
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(21, 12);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 0;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "导出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_print);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 43);
            this.panel1.TabIndex = 2;
            // 
            // w_schedulereport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 326);
            this.Controls.Add(this.orderdata);
            this.Controls.Add(this.panel1);
            this.Name = "w_schedulereport";
            this.Text = "排程报表";
            ((System.ComponentModel.ISupportInitialize)(this.orderdata)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView orderdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn 车组号;
        private System.Windows.Forms.DataGridViewTextBoxColumn cigarettecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cigarettename;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn 排程数量;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}