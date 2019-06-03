namespace HighSpeed.OrderHandle
{
    partial class w_EDITthough
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
            this.cbthroughnum = new System.Windows.Forms.ComboBox();
            this.txt_iteminfo = new System.Windows.Forms.TextBox();
            this.btn_choose = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbthroughnum
            // 
            this.cbthroughnum.FormattingEnabled = true;
            this.cbthroughnum.Location = new System.Drawing.Point(83, 80);
            this.cbthroughnum.Name = "cbthroughnum";
            this.cbthroughnum.Size = new System.Drawing.Size(98, 20);
            this.cbthroughnum.TabIndex = 43;
            // 
            // txt_iteminfo
            // 
            this.txt_iteminfo.Enabled = false;
            this.txt_iteminfo.Location = new System.Drawing.Point(83, 39);
            this.txt_iteminfo.Name = "txt_iteminfo";
            this.txt_iteminfo.Size = new System.Drawing.Size(162, 21);
            this.txt_iteminfo.TabIndex = 35;
            // 
            // btn_choose
            // 
            this.btn_choose.Location = new System.Drawing.Point(251, 39);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(75, 23);
            this.btn_choose.TabIndex = 33;
            this.btn_choose.Text = "选择";
            this.btn_choose.UseVisualStyleBackColor = true;
            this.btn_choose.Click += new System.EventHandler(this.btn_choose_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(184, 170);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 32;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(83, 170);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 31;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "品牌选择";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "通道编号";
            // 
            // w_EDITthough
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 223);
            this.Controls.Add(this.cbthroughnum);
            this.Controls.Add(this.txt_iteminfo);
            this.Controls.Add(this.btn_choose);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Name = "w_EDITthough";
            this.Text = "w_EDITthough";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbthroughnum;
        private System.Windows.Forms.TextBox txt_iteminfo;
        private System.Windows.Forms.Button btn_choose;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}