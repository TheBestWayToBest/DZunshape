namespace HighSpeed
{
    partial class w_Database_Set
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.server_pwd = new System.Windows.Forms.TextBox();
            this.BtnConnTest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.server_uid = new System.Windows.Forms.TextBox();
            this.server_server = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.server_database = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnLogin);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Controls.Add(this.server_pwd);
            this.groupBox2.Controls.Add(this.BtnConnTest);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.server_uid);
            this.groupBox2.Controls.Add(this.server_server);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.server_database);
            this.groupBox2.Location = new System.Drawing.Point(8, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 194);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接口数据库连接配置";
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(347, 145);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(75, 23);
            this.BtnLogin.TabIndex = 37;
            this.BtnLogin.Text = "登录";
            this.BtnLogin.UseVisualStyleBackColor = true;
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(266, 145);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 23);
            this.BtnExit.TabIndex = 36;
            this.BtnExit.Text = "退出";
            this.BtnExit.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "密码";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(178, 145);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 35;
            this.BtnSave.Text = "保存配置";
            this.BtnSave.UseVisualStyleBackColor = true;
            // 
            // server_pwd
            // 
            this.server_pwd.Location = new System.Drawing.Point(254, 106);
            this.server_pwd.Name = "server_pwd";
            this.server_pwd.Size = new System.Drawing.Size(166, 21);
            this.server_pwd.TabIndex = 34;
            this.server_pwd.UseSystemPasswordChar = true;
            // 
            // BtnConnTest
            // 
            this.BtnConnTest.Location = new System.Drawing.Point(97, 145);
            this.BtnConnTest.Name = "BtnConnTest";
            this.BtnConnTest.Size = new System.Drawing.Size(75, 23);
            this.BtnConnTest.TabIndex = 35;
            this.BtnConnTest.Text = "连接测试";
            this.BtnConnTest.UseVisualStyleBackColor = true;
            this.BtnConnTest.Click += new System.EventHandler(this.BtnConnTest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "用户名";
            // 
            // server_uid
            // 
            this.server_uid.Location = new System.Drawing.Point(81, 108);
            this.server_uid.Name = "server_uid";
            this.server_uid.Size = new System.Drawing.Size(113, 21);
            this.server_uid.TabIndex = 33;
            // 
            // server_server
            // 
            this.server_server.Location = new System.Drawing.Point(81, 20);
            this.server_server.Name = "server_server";
            this.server_server.Size = new System.Drawing.Size(340, 21);
            this.server_server.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "数据库名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "服务器名";
            // 
            // server_database
            // 
            this.server_database.Location = new System.Drawing.Point(81, 65);
            this.server_database.Name = "server_database";
            this.server_database.Size = new System.Drawing.Size(340, 21);
            this.server_database.TabIndex = 29;
            // 
            // w_Database_Set
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(458, 208);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "w_Database_Set";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "接口服务器数据库配置";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox server_pwd;
        private System.Windows.Forms.Button BtnConnTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox server_uid;
        private System.Windows.Forms.TextBox server_server;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox server_database;
    }
}