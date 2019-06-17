using HighSpeed.OrderHandle;

namespace HighSpeed.OrderHandle
{
    partial class win_trough
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_amend = new System.Windows.Forms.Button();
            this.btn_qy = new System.Windows.Forms.Button();
            this.btn_jy = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_keywd = new System.Windows.Forms.TextBox();
            this.box_condition = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvdate = new System.Windows.Forms.DataGridView();
            this.expressionDrawer1 = new VBprinter.ExpressionDrawer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_amend);
            this.panel1.Controls.Add(this.btn_qy);
            this.panel1.Controls.Add(this.btn_jy);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.txt_keywd);
            this.panel1.Controls.Add(this.box_condition);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1669, 110);
            this.panel1.TabIndex = 0;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(684, 26);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(68, 29);
            this.btn_Add.TabIndex = 15;
            this.btn_Add.Text = "增加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(841, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "验证";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_amend
            // 
            this.btn_amend.Location = new System.Drawing.Point(761, 26);
            this.btn_amend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_amend.Name = "btn_amend";
            this.btn_amend.Size = new System.Drawing.Size(72, 29);
            this.btn_amend.TabIndex = 8;
            this.btn_amend.Text = "修改";
            this.btn_amend.UseVisualStyleBackColor = true;
            this.btn_amend.Click += new System.EventHandler(this.btn_amend_Click);
            // 
            // btn_qy
            // 
            this.btn_qy.Location = new System.Drawing.Point(515, 26);
            this.btn_qy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_qy.Name = "btn_qy";
            this.btn_qy.Size = new System.Drawing.Size(75, 29);
            this.btn_qy.TabIndex = 7;
            this.btn_qy.Text = "启用";
            this.btn_qy.UseVisualStyleBackColor = true;
            this.btn_qy.Click += new System.EventHandler(this.btn_qy_Click);
            // 
            // btn_jy
            // 
            this.btn_jy.Location = new System.Drawing.Point(599, 26);
            this.btn_jy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_jy.Name = "btn_jy";
            this.btn_jy.Size = new System.Drawing.Size(75, 29);
            this.btn_jy.TabIndex = 6;
            this.btn_jy.Text = "禁用";
            this.btn_jy.UseVisualStyleBackColor = true;
            this.btn_jy.Click += new System.EventHandler(this.btn_jy_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(440, 26);
            this.btn_search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(68, 29);
            this.btn_search.TabIndex = 5;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_keywd
            // 
            this.txt_keywd.Location = new System.Drawing.Point(221, 28);
            this.txt_keywd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_keywd.Name = "txt_keywd";
            this.txt_keywd.Size = new System.Drawing.Size(132, 25);
            this.txt_keywd.TabIndex = 4;
            this.txt_keywd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_keywd_KeyDown);
            // 
            // box_condition
            // 
            this.box_condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_condition.FormattingEnabled = true;
            this.box_condition.Location = new System.Drawing.Point(80, 29);
            this.box_condition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.box_condition.Name = "box_condition";
            this.box_condition.Size = new System.Drawing.Size(132, 23);
            this.box_condition.TabIndex = 3;
            this.box_condition.SelectedIndexChanged += new System.EventHandler(this.box_condition_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "查询条件";
            // 
            // dgvdate
            // 
            this.dgvdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdate.Location = new System.Drawing.Point(0, 110);
            this.dgvdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvdate.Name = "dgvdate";
            this.dgvdate.RowTemplate.Height = 23;
            this.dgvdate.Size = new System.Drawing.Size(1669, 589);
            this.dgvdate.TabIndex = 1;
            this.dgvdate.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdate_CellClick);
            // 
            // expressionDrawer1
            // 
            this.expressionDrawer1.DisplayText = true;
            this.expressionDrawer1.DivisionsX = 5;
            this.expressionDrawer1.DivisionsY = 5;
            this.expressionDrawer1.ExpressionTextFont = new System.Drawing.Font("宋体", 10F);
            this.expressionDrawer1.ForwardX = 0D;
            this.expressionDrawer1.ForwardY = 0D;
            this.expressionDrawer1.GraphMode = VBprinter.GraphMode.Rectangular;
            this.expressionDrawer1.Grids = false;
            this.expressionDrawer1.PenWidth = 1;
            this.expressionDrawer1.PolarSensitivity = 100;
            this.expressionDrawer1.PrintStepX = 1;
            this.expressionDrawer1.PrintStepY = 1;
            this.expressionDrawer1.ScaleFont = new System.Drawing.Font("宋体", 8F);
            this.expressionDrawer1.ScaleX = 10D;
            this.expressionDrawer1.ScaleY = 10D;
            // 
            // win_trough
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1669, 699);
            this.Controls.Add(this.dgvdate);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "win_trough";
            this.Text = "分拣通道管理";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox box_condition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_keywd;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_qy;
        private System.Windows.Forms.Button btn_jy;
        private System.Windows.Forms.Button btn_amend;
        private WHC.Pager.WinControl.Pager pager1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridView dgvdate;
        private VBprinter.ExpressionDrawer expressionDrawer1;
    }
}