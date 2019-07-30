namespace SmokeRelenishment
{
    partial class SmokeRelenishment
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnSeq = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.GBToAdd = new System.Windows.Forms.GroupBox();
            this.LblAdd10 = new System.Windows.Forms.Label();
            this.LblAdd9 = new System.Windows.Forms.Label();
            this.LblAdd8 = new System.Windows.Forms.Label();
            this.LblAdd7 = new System.Windows.Forms.Label();
            this.LblAdd1 = new System.Windows.Forms.Label();
            this.LblAdd2 = new System.Windows.Forms.Label();
            this.LblAdd4 = new System.Windows.Forms.Label();
            this.LblAdd5 = new System.Windows.Forms.Label();
            this.LblAdd3 = new System.Windows.Forms.Label();
            this.LblAdd6 = new System.Windows.Forms.Label();
            this.GBAdded = new System.Windows.Forms.GroupBox();
            this.LblAdded10 = new System.Windows.Forms.Label();
            this.LblAdded9 = new System.Windows.Forms.Label();
            this.LblAdded8 = new System.Windows.Forms.Label();
            this.LblAdded7 = new System.Windows.Forms.Label();
            this.LblAdded1 = new System.Windows.Forms.Label();
            this.LblAdded2 = new System.Windows.Forms.Label();
            this.LblAdded4 = new System.Windows.Forms.Label();
            this.LblAdded5 = new System.Windows.Forms.Label();
            this.LblAdded3 = new System.Windows.Forms.Label();
            this.LblAdded6 = new System.Windows.Forms.Label();
            this.TRefresh = new System.Windows.Forms.Timer(this.components);
            this.BGWConn = new System.ComponentModel.BackgroundWorker();
            this.TSender = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.GBToAdd.SuspendLayout();
            this.GBAdded.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::SmokeRelenishment.Properties.Resources.topfj;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.BtnRefresh);
            this.panel1.Controls.Add(this.BtnSearch);
            this.panel1.Controls.Add(this.BtnSeq);
            this.panel1.Controls.Add(this.BtnExit);
            this.panel1.Controls.Add(this.GBToAdd);
            this.panel1.Controls.Add(this.GBAdded);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 378);
            this.panel1.TabIndex = 0;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnRefresh.Location = new System.Drawing.Point(421, 0);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(35, 29);
            this.BtnRefresh.TabIndex = 22;
            this.BtnRefresh.Text = "刷新";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSearch.Location = new System.Drawing.Point(293, 0);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(65, 29);
            this.BtnSearch.TabIndex = 20;
            this.BtnSearch.Text = "件烟定位";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnSeq
            // 
            this.BtnSeq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSeq.Location = new System.Drawing.Point(357, 0);
            this.BtnSeq.Name = "BtnSeq";
            this.BtnSeq.Size = new System.Drawing.Size(65, 29);
            this.BtnSeq.TabIndex = 21;
            this.BtnSeq.Text = "件烟顺序";
            this.BtnSeq.UseVisualStyleBackColor = true;
            this.BtnSeq.Click += new System.EventHandler(this.BtnSeq_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackgroundImage = global::SmokeRelenishment.Properties.Resources.icon_exit;
            this.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExit.Location = new System.Drawing.Point(455, 0);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(23, 29);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // GBToAdd
            // 
            this.GBToAdd.BackColor = System.Drawing.Color.Transparent;
            this.GBToAdd.Controls.Add(this.LblAdd10);
            this.GBToAdd.Controls.Add(this.LblAdd9);
            this.GBToAdd.Controls.Add(this.LblAdd8);
            this.GBToAdd.Controls.Add(this.LblAdd7);
            this.GBToAdd.Controls.Add(this.LblAdd1);
            this.GBToAdd.Controls.Add(this.LblAdd2);
            this.GBToAdd.Controls.Add(this.LblAdd4);
            this.GBToAdd.Controls.Add(this.LblAdd5);
            this.GBToAdd.Controls.Add(this.LblAdd3);
            this.GBToAdd.Controls.Add(this.LblAdd6);
            this.GBToAdd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GBToAdd.ForeColor = System.Drawing.Color.Red;
            this.GBToAdd.Location = new System.Drawing.Point(243, 32);
            this.GBToAdd.Name = "GBToAdd";
            this.GBToAdd.Size = new System.Drawing.Size(235, 343);
            this.GBToAdd.TabIndex = 0;
            this.GBToAdd.TabStop = false;
            this.GBToAdd.Text = "待补";
            // 
            // LblAdd10
            // 
            this.LblAdd10.BackColor = System.Drawing.Color.White;
            this.LblAdd10.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd10.ForeColor = System.Drawing.Color.Black;
            this.LblAdd10.Location = new System.Drawing.Point(2, 306);
            this.LblAdd10.Name = "LblAdd10";
            this.LblAdd10.Size = new System.Drawing.Size(230, 29);
            this.LblAdd10.TabIndex = 9;
            this.LblAdd10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd9
            // 
            this.LblAdd9.BackColor = System.Drawing.Color.White;
            this.LblAdd9.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd9.ForeColor = System.Drawing.Color.Black;
            this.LblAdd9.Location = new System.Drawing.Point(2, 274);
            this.LblAdd9.Name = "LblAdd9";
            this.LblAdd9.Size = new System.Drawing.Size(230, 29);
            this.LblAdd9.TabIndex = 8;
            this.LblAdd9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd8
            // 
            this.LblAdd8.BackColor = System.Drawing.Color.White;
            this.LblAdd8.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd8.ForeColor = System.Drawing.Color.Black;
            this.LblAdd8.Location = new System.Drawing.Point(2, 242);
            this.LblAdd8.Name = "LblAdd8";
            this.LblAdd8.Size = new System.Drawing.Size(230, 29);
            this.LblAdd8.TabIndex = 7;
            this.LblAdd8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd7
            // 
            this.LblAdd7.BackColor = System.Drawing.Color.White;
            this.LblAdd7.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd7.ForeColor = System.Drawing.Color.Black;
            this.LblAdd7.Location = new System.Drawing.Point(2, 210);
            this.LblAdd7.Name = "LblAdd7";
            this.LblAdd7.Size = new System.Drawing.Size(230, 29);
            this.LblAdd7.TabIndex = 6;
            this.LblAdd7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd1
            // 
            this.LblAdd1.BackColor = System.Drawing.Color.White;
            this.LblAdd1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd1.ForeColor = System.Drawing.Color.Black;
            this.LblAdd1.Location = new System.Drawing.Point(2, 18);
            this.LblAdd1.Name = "LblAdd1";
            this.LblAdd1.Size = new System.Drawing.Size(230, 29);
            this.LblAdd1.TabIndex = 0;
            this.LblAdd1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd2
            // 
            this.LblAdd2.BackColor = System.Drawing.Color.White;
            this.LblAdd2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd2.ForeColor = System.Drawing.Color.Black;
            this.LblAdd2.Location = new System.Drawing.Point(2, 50);
            this.LblAdd2.Name = "LblAdd2";
            this.LblAdd2.Size = new System.Drawing.Size(230, 29);
            this.LblAdd2.TabIndex = 1;
            this.LblAdd2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd4
            // 
            this.LblAdd4.BackColor = System.Drawing.Color.White;
            this.LblAdd4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd4.ForeColor = System.Drawing.Color.Black;
            this.LblAdd4.Location = new System.Drawing.Point(2, 114);
            this.LblAdd4.Name = "LblAdd4";
            this.LblAdd4.Size = new System.Drawing.Size(230, 29);
            this.LblAdd4.TabIndex = 3;
            this.LblAdd4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd5
            // 
            this.LblAdd5.BackColor = System.Drawing.Color.White;
            this.LblAdd5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd5.ForeColor = System.Drawing.Color.Black;
            this.LblAdd5.Location = new System.Drawing.Point(2, 146);
            this.LblAdd5.Name = "LblAdd5";
            this.LblAdd5.Size = new System.Drawing.Size(230, 29);
            this.LblAdd5.TabIndex = 4;
            this.LblAdd5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd3
            // 
            this.LblAdd3.BackColor = System.Drawing.Color.White;
            this.LblAdd3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd3.ForeColor = System.Drawing.Color.Black;
            this.LblAdd3.Location = new System.Drawing.Point(2, 82);
            this.LblAdd3.Name = "LblAdd3";
            this.LblAdd3.Size = new System.Drawing.Size(230, 29);
            this.LblAdd3.TabIndex = 2;
            this.LblAdd3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd6
            // 
            this.LblAdd6.BackColor = System.Drawing.Color.White;
            this.LblAdd6.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd6.ForeColor = System.Drawing.Color.Black;
            this.LblAdd6.Location = new System.Drawing.Point(2, 178);
            this.LblAdd6.Name = "LblAdd6";
            this.LblAdd6.Size = new System.Drawing.Size(230, 29);
            this.LblAdd6.TabIndex = 5;
            this.LblAdd6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GBAdded
            // 
            this.GBAdded.BackColor = System.Drawing.Color.Transparent;
            this.GBAdded.Controls.Add(this.LblAdded10);
            this.GBAdded.Controls.Add(this.LblAdded9);
            this.GBAdded.Controls.Add(this.LblAdded8);
            this.GBAdded.Controls.Add(this.LblAdded7);
            this.GBAdded.Controls.Add(this.LblAdded1);
            this.GBAdded.Controls.Add(this.LblAdded2);
            this.GBAdded.Controls.Add(this.LblAdded4);
            this.GBAdded.Controls.Add(this.LblAdded5);
            this.GBAdded.Controls.Add(this.LblAdded3);
            this.GBAdded.Controls.Add(this.LblAdded6);
            this.GBAdded.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GBAdded.ForeColor = System.Drawing.Color.Red;
            this.GBAdded.Location = new System.Drawing.Point(3, 32);
            this.GBAdded.Name = "GBAdded";
            this.GBAdded.Size = new System.Drawing.Size(235, 343);
            this.GBAdded.TabIndex = 0;
            this.GBAdded.TabStop = false;
            this.GBAdded.Text = "已扫码";
            // 
            // LblAdded10
            // 
            this.LblAdded10.BackColor = System.Drawing.Color.White;
            this.LblAdded10.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded10.ForeColor = System.Drawing.Color.Black;
            this.LblAdded10.Location = new System.Drawing.Point(2, 306);
            this.LblAdded10.Name = "LblAdded10";
            this.LblAdded10.Size = new System.Drawing.Size(230, 29);
            this.LblAdded10.TabIndex = 19;
            this.LblAdded10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded9
            // 
            this.LblAdded9.BackColor = System.Drawing.Color.White;
            this.LblAdded9.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded9.ForeColor = System.Drawing.Color.Black;
            this.LblAdded9.Location = new System.Drawing.Point(2, 274);
            this.LblAdded9.Name = "LblAdded9";
            this.LblAdded9.Size = new System.Drawing.Size(230, 29);
            this.LblAdded9.TabIndex = 18;
            this.LblAdded9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded8
            // 
            this.LblAdded8.BackColor = System.Drawing.Color.White;
            this.LblAdded8.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded8.ForeColor = System.Drawing.Color.Black;
            this.LblAdded8.Location = new System.Drawing.Point(2, 242);
            this.LblAdded8.Name = "LblAdded8";
            this.LblAdded8.Size = new System.Drawing.Size(230, 29);
            this.LblAdded8.TabIndex = 17;
            this.LblAdded8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded7
            // 
            this.LblAdded7.BackColor = System.Drawing.Color.White;
            this.LblAdded7.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded7.ForeColor = System.Drawing.Color.Black;
            this.LblAdded7.Location = new System.Drawing.Point(2, 210);
            this.LblAdded7.Name = "LblAdded7";
            this.LblAdded7.Size = new System.Drawing.Size(230, 29);
            this.LblAdded7.TabIndex = 16;
            this.LblAdded7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded1
            // 
            this.LblAdded1.BackColor = System.Drawing.Color.White;
            this.LblAdded1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded1.ForeColor = System.Drawing.Color.Black;
            this.LblAdded1.Location = new System.Drawing.Point(2, 18);
            this.LblAdded1.Name = "LblAdded1";
            this.LblAdded1.Size = new System.Drawing.Size(230, 29);
            this.LblAdded1.TabIndex = 10;
            this.LblAdded1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded2
            // 
            this.LblAdded2.BackColor = System.Drawing.Color.White;
            this.LblAdded2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded2.ForeColor = System.Drawing.Color.Black;
            this.LblAdded2.Location = new System.Drawing.Point(2, 50);
            this.LblAdded2.Name = "LblAdded2";
            this.LblAdded2.Size = new System.Drawing.Size(230, 29);
            this.LblAdded2.TabIndex = 11;
            this.LblAdded2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded4
            // 
            this.LblAdded4.BackColor = System.Drawing.Color.White;
            this.LblAdded4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded4.ForeColor = System.Drawing.Color.Black;
            this.LblAdded4.Location = new System.Drawing.Point(2, 114);
            this.LblAdded4.Name = "LblAdded4";
            this.LblAdded4.Size = new System.Drawing.Size(230, 29);
            this.LblAdded4.TabIndex = 13;
            this.LblAdded4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded5
            // 
            this.LblAdded5.BackColor = System.Drawing.Color.White;
            this.LblAdded5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded5.ForeColor = System.Drawing.Color.Black;
            this.LblAdded5.Location = new System.Drawing.Point(2, 146);
            this.LblAdded5.Name = "LblAdded5";
            this.LblAdded5.Size = new System.Drawing.Size(230, 29);
            this.LblAdded5.TabIndex = 14;
            this.LblAdded5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded3
            // 
            this.LblAdded3.BackColor = System.Drawing.Color.White;
            this.LblAdded3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded3.ForeColor = System.Drawing.Color.Black;
            this.LblAdded3.Location = new System.Drawing.Point(2, 82);
            this.LblAdded3.Name = "LblAdded3";
            this.LblAdded3.Size = new System.Drawing.Size(230, 29);
            this.LblAdded3.TabIndex = 12;
            this.LblAdded3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded6
            // 
            this.LblAdded6.BackColor = System.Drawing.Color.White;
            this.LblAdded6.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded6.ForeColor = System.Drawing.Color.Black;
            this.LblAdded6.Location = new System.Drawing.Point(2, 178);
            this.LblAdded6.Name = "LblAdded6";
            this.LblAdded6.Size = new System.Drawing.Size(230, 29);
            this.LblAdded6.TabIndex = 15;
            this.LblAdded6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TRefresh
            // 
            this.TRefresh.Interval = 8000;
            this.TRefresh.Tick += new System.EventHandler(this.TRefresh_Tick);
            // 
            // BGWConn
            // 
            this.BGWConn.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWConn_DoWork);
            // 
            // TSender
            // 
            this.TSender.Interval = 10000;
            this.TSender.Tick += new System.EventHandler(this.TSender_Tick);
            // 
            // SmokeRelenishment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SmokeRelenishment.Properties.Resources.mainbj;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(480, 378);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SmokeRelenishment";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.SmokeRelenishment_Resize);
            this.panel1.ResumeLayout(false);
            this.GBToAdd.ResumeLayout(false);
            this.GBAdded.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox GBToAdd;
        private System.Windows.Forms.GroupBox GBAdded;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Label LblAdd7;
        private System.Windows.Forms.Label LblAdd1;
        private System.Windows.Forms.Label LblAdd2;
        private System.Windows.Forms.Label LblAdd4;
        private System.Windows.Forms.Label LblAdd5;
        private System.Windows.Forms.Label LblAdd3;
        private System.Windows.Forms.Label LblAdd6;
        private System.Windows.Forms.Label LblAdd10;
        private System.Windows.Forms.Label LblAdd9;
        private System.Windows.Forms.Label LblAdd8;
        private System.Windows.Forms.Label LblAdded10;
        private System.Windows.Forms.Label LblAdded9;
        private System.Windows.Forms.Label LblAdded8;
        private System.Windows.Forms.Label LblAdded7;
        private System.Windows.Forms.Label LblAdded1;
        private System.Windows.Forms.Label LblAdded2;
        private System.Windows.Forms.Label LblAdded4;
        private System.Windows.Forms.Label LblAdded5;
        private System.Windows.Forms.Label LblAdded3;
        private System.Windows.Forms.Label LblAdded6;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnSeq;
        private System.Windows.Forms.Timer TRefresh;
        private System.ComponentModel.BackgroundWorker BGWConn;
        private System.Windows.Forms.Timer TSender;
    }
}

