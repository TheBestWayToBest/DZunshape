namespace HighspeedNew.OrderHandle
{
    partial class w_SortStrategy
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.RBAll = new System.Windows.Forms.RadioButton();
            this.RBMost = new System.Windows.Forms.RadioButton();
            this.RBOne = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(43, 159);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // RBAll
            // 
            this.RBAll.AutoSize = true;
            this.RBAll.Location = new System.Drawing.Point(43, 42);
            this.RBAll.Name = "RBAll";
            this.RBAll.Size = new System.Drawing.Size(155, 16);
            this.RBAll.TabIndex = 1;
            this.RBAll.Text = "全车一条烟订单优先分拣";
            this.RBAll.UseVisualStyleBackColor = true;
            // 
            // RBMost
            // 
            this.RBMost.AutoSize = true;
            this.RBMost.Location = new System.Drawing.Point(43, 78);
            this.RBMost.Name = "RBMost";
            this.RBMost.Size = new System.Drawing.Size(155, 16);
            this.RBMost.TabIndex = 2;
            this.RBMost.Text = "线区一条烟订单优先分拣";
            this.RBMost.UseVisualStyleBackColor = true;
            // 
            // RBOne
            // 
            this.RBOne.AutoSize = true;
            this.RBOne.Checked = true;
            this.RBOne.Location = new System.Drawing.Point(43, 114);
            this.RBOne.Name = "RBOne";
            this.RBOne.Size = new System.Drawing.Size(155, 16);
            this.RBOne.TabIndex = 3;
            this.RBOne.TabStop = true;
            this.RBOne.Text = "线路一条烟订单优先分拣";
            this.RBOne.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "请选择排程策略：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // w_SortStrategy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 208);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RBOne);
            this.Controls.Add(this.RBMost);
            this.Controls.Add(this.RBAll);
            this.Controls.Add(this.btnConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "w_SortStrategy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择排程策略";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.RadioButton RBAll;
        private System.Windows.Forms.RadioButton RBMost;
        private System.Windows.Forms.RadioButton RBOne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}