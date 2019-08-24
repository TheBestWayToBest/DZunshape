namespace HighSpeed.OrderHandle
{
    partial class w_CigInfo
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
            this.itemdata = new System.Windows.Forms.DataGridView();
            this.txt_itemname = new System.Windows.Forms.TextBox();
            this.txt_itemno = new System.Windows.Forms.TextBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_keywd = new System.Windows.Forms.TextBox();
            this.box_type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemdata)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemdata
            // 
            this.itemdata.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.itemdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemdata.Location = new System.Drawing.Point(0, 42);
            this.itemdata.MultiSelect = false;
            this.itemdata.Name = "itemdata";
            this.itemdata.ReadOnly = true;
            this.itemdata.RowTemplate.Height = 23;
            this.itemdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemdata.Size = new System.Drawing.Size(814, 440);
            this.itemdata.TabIndex = 3;
            this.itemdata.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemdata_CellClick);
            // 
            // txt_itemname
            // 
            this.txt_itemname.Location = new System.Drawing.Point(596, 8);
            this.txt_itemname.Name = "txt_itemname";
            this.txt_itemname.Size = new System.Drawing.Size(100, 21);
            this.txt_itemname.TabIndex = 7;
            // 
            // txt_itemno
            // 
            this.txt_itemno.Location = new System.Drawing.Point(702, 8);
            this.txt_itemno.Name = "txt_itemno";
            this.txt_itemno.Size = new System.Drawing.Size(100, 21);
            this.txt_itemno.TabIndex = 6;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(488, 7);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(397, 8);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 23);
            this.btn_submit.TabIndex = 4;
            this.btn_submit.Text = "提交";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(306, 8);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_itemname);
            this.panel1.Controls.Add(this.txt_itemno);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_submit);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.txt_keywd);
            this.panel1.Controls.Add(this.box_type);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 42);
            this.panel1.TabIndex = 2;
            // 
            // txt_keywd
            // 
            this.txt_keywd.Location = new System.Drawing.Point(162, 7);
            this.txt_keywd.Name = "txt_keywd";
            this.txt_keywd.Size = new System.Drawing.Size(100, 21);
            this.txt_keywd.TabIndex = 2;
            // 
            // box_type
            // 
            this.box_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_type.FormattingEnabled = true;
            this.box_type.Location = new System.Drawing.Point(71, 8);
            this.box_type.Name = "box_type";
            this.box_type.Size = new System.Drawing.Size(85, 20);
            this.box_type.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询条件";
            // 
            // w_CigInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 482);
            this.Controls.Add(this.itemdata);
            this.Controls.Add(this.panel1);
            this.Name = "w_CigInfo";
            this.Text = "w_CigInfo";
            ((System.ComponentModel.ISupportInitialize)(this.itemdata)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView itemdata;
        private System.Windows.Forms.TextBox txt_itemname;
        private System.Windows.Forms.TextBox txt_itemno;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_keywd;
        private System.Windows.Forms.ComboBox box_type;
        private System.Windows.Forms.Label label1;
    }
}