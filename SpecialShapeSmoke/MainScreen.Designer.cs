namespace SpecialShapeSmoke
{
    partial class MainScreen
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
            this.LblAdded2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnSeq = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.GBToAdd = new System.Windows.Forms.GroupBox();
            this.LblAdd15 = new System.Windows.Forms.Label();
            this.LblAdd14 = new System.Windows.Forms.Label();
            this.LblAdd13 = new System.Windows.Forms.Label();
            this.LblAdd12 = new System.Windows.Forms.Label();
            this.LblAdd11 = new System.Windows.Forms.Label();
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
            this.LblAdded15 = new System.Windows.Forms.Label();
            this.LblAdded14 = new System.Windows.Forms.Label();
            this.LblAdded13 = new System.Windows.Forms.Label();
            this.LblAdded12 = new System.Windows.Forms.Label();
            this.LblAdded11 = new System.Windows.Forms.Label();
            this.LblAdded10 = new System.Windows.Forms.Label();
            this.LblAdded9 = new System.Windows.Forms.Label();
            this.LblAdded8 = new System.Windows.Forms.Label();
            this.LblAdded7 = new System.Windows.Forms.Label();
            this.LblAdded1 = new System.Windows.Forms.Label();
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
            // LblAdded2
            // 
            this.LblAdded2.BackColor = System.Drawing.Color.White;
            this.LblAdded2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded2.ForeColor = System.Drawing.Color.Black;
            this.LblAdded2.Location = new System.Drawing.Point(2, 42);
            this.LblAdded2.Name = "LblAdded2";
            this.LblAdded2.Size = new System.Drawing.Size(230, 19);
            this.LblAdded2.TabIndex = 11;
            this.LblAdded2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::SpecialShapeSmoke.Properties.Resources.topfj;
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
            this.panel1.TabIndex = 2;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnRefresh.Location = new System.Drawing.Point(423, 0);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(35, 22);
            this.BtnRefresh.TabIndex = 22;
            this.BtnRefresh.Text = "刷新";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSearch.Location = new System.Drawing.Point(295, 0);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(65, 22);
            this.BtnSearch.TabIndex = 20;
            this.BtnSearch.Text = "条烟定位";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnSeq
            // 
            this.BtnSeq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSeq.Location = new System.Drawing.Point(359, 0);
            this.BtnSeq.Name = "BtnSeq";
            this.BtnSeq.Size = new System.Drawing.Size(65, 22);
            this.BtnSeq.TabIndex = 21;
            this.BtnSeq.Text = "条烟顺序";
            this.BtnSeq.UseVisualStyleBackColor = true;
            // 
            // BtnExit
            // 
            this.BtnExit.BackgroundImage = global::SpecialShapeSmoke.Properties.Resources.icon_exit;
            this.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExit.Location = new System.Drawing.Point(457, 0);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(23, 22);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // GBToAdd
            // 
            this.GBToAdd.BackColor = System.Drawing.Color.Transparent;
            this.GBToAdd.Controls.Add(this.LblAdd15);
            this.GBToAdd.Controls.Add(this.LblAdd14);
            this.GBToAdd.Controls.Add(this.LblAdd13);
            this.GBToAdd.Controls.Add(this.LblAdd12);
            this.GBToAdd.Controls.Add(this.LblAdd11);
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
            // LblAdd15
            // 
            this.LblAdd15.BackColor = System.Drawing.Color.White;
            this.LblAdd15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd15.ForeColor = System.Drawing.Color.Black;
            this.LblAdd15.Location = new System.Drawing.Point(2, 315);
            this.LblAdd15.Name = "LblAdd15";
            this.LblAdd15.Size = new System.Drawing.Size(230, 19);
            this.LblAdd15.TabIndex = 39;
            this.LblAdd15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd14
            // 
            this.LblAdd14.BackColor = System.Drawing.Color.White;
            this.LblAdd14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd14.ForeColor = System.Drawing.Color.Black;
            this.LblAdd14.Location = new System.Drawing.Point(2, 294);
            this.LblAdd14.Name = "LblAdd14";
            this.LblAdd14.Size = new System.Drawing.Size(230, 19);
            this.LblAdd14.TabIndex = 38;
            this.LblAdd14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd13
            // 
            this.LblAdd13.BackColor = System.Drawing.Color.White;
            this.LblAdd13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd13.ForeColor = System.Drawing.Color.Black;
            this.LblAdd13.Location = new System.Drawing.Point(2, 273);
            this.LblAdd13.Name = "LblAdd13";
            this.LblAdd13.Size = new System.Drawing.Size(230, 19);
            this.LblAdd13.TabIndex = 37;
            this.LblAdd13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd12
            // 
            this.LblAdd12.BackColor = System.Drawing.Color.White;
            this.LblAdd12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd12.ForeColor = System.Drawing.Color.Black;
            this.LblAdd12.Location = new System.Drawing.Point(2, 252);
            this.LblAdd12.Name = "LblAdd12";
            this.LblAdd12.Size = new System.Drawing.Size(230, 19);
            this.LblAdd12.TabIndex = 36;
            this.LblAdd12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd11
            // 
            this.LblAdd11.BackColor = System.Drawing.Color.White;
            this.LblAdd11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd11.ForeColor = System.Drawing.Color.Black;
            this.LblAdd11.Location = new System.Drawing.Point(2, 231);
            this.LblAdd11.Name = "LblAdd11";
            this.LblAdd11.Size = new System.Drawing.Size(230, 19);
            this.LblAdd11.TabIndex = 35;
            this.LblAdd11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd10
            // 
            this.LblAdd10.BackColor = System.Drawing.Color.White;
            this.LblAdd10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd10.ForeColor = System.Drawing.Color.Black;
            this.LblAdd10.Location = new System.Drawing.Point(2, 210);
            this.LblAdd10.Name = "LblAdd10";
            this.LblAdd10.Size = new System.Drawing.Size(230, 19);
            this.LblAdd10.TabIndex = 34;
            this.LblAdd10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd9
            // 
            this.LblAdd9.BackColor = System.Drawing.Color.White;
            this.LblAdd9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd9.ForeColor = System.Drawing.Color.Black;
            this.LblAdd9.Location = new System.Drawing.Point(2, 189);
            this.LblAdd9.Name = "LblAdd9";
            this.LblAdd9.Size = new System.Drawing.Size(230, 19);
            this.LblAdd9.TabIndex = 33;
            this.LblAdd9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd8
            // 
            this.LblAdd8.BackColor = System.Drawing.Color.White;
            this.LblAdd8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd8.ForeColor = System.Drawing.Color.Black;
            this.LblAdd8.Location = new System.Drawing.Point(2, 168);
            this.LblAdd8.Name = "LblAdd8";
            this.LblAdd8.Size = new System.Drawing.Size(230, 19);
            this.LblAdd8.TabIndex = 32;
            this.LblAdd8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd7
            // 
            this.LblAdd7.BackColor = System.Drawing.Color.White;
            this.LblAdd7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd7.ForeColor = System.Drawing.Color.Black;
            this.LblAdd7.Location = new System.Drawing.Point(2, 147);
            this.LblAdd7.Name = "LblAdd7";
            this.LblAdd7.Size = new System.Drawing.Size(230, 19);
            this.LblAdd7.TabIndex = 31;
            this.LblAdd7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd1
            // 
            this.LblAdd1.BackColor = System.Drawing.Color.White;
            this.LblAdd1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd1.ForeColor = System.Drawing.Color.Black;
            this.LblAdd1.Location = new System.Drawing.Point(2, 21);
            this.LblAdd1.Name = "LblAdd1";
            this.LblAdd1.Size = new System.Drawing.Size(230, 19);
            this.LblAdd1.TabIndex = 25;
            this.LblAdd1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd2
            // 
            this.LblAdd2.BackColor = System.Drawing.Color.White;
            this.LblAdd2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd2.ForeColor = System.Drawing.Color.Black;
            this.LblAdd2.Location = new System.Drawing.Point(2, 42);
            this.LblAdd2.Name = "LblAdd2";
            this.LblAdd2.Size = new System.Drawing.Size(230, 19);
            this.LblAdd2.TabIndex = 26;
            this.LblAdd2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd4
            // 
            this.LblAdd4.BackColor = System.Drawing.Color.White;
            this.LblAdd4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd4.ForeColor = System.Drawing.Color.Black;
            this.LblAdd4.Location = new System.Drawing.Point(2, 84);
            this.LblAdd4.Name = "LblAdd4";
            this.LblAdd4.Size = new System.Drawing.Size(230, 19);
            this.LblAdd4.TabIndex = 28;
            this.LblAdd4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd5
            // 
            this.LblAdd5.BackColor = System.Drawing.Color.White;
            this.LblAdd5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd5.ForeColor = System.Drawing.Color.Black;
            this.LblAdd5.Location = new System.Drawing.Point(2, 105);
            this.LblAdd5.Name = "LblAdd5";
            this.LblAdd5.Size = new System.Drawing.Size(230, 19);
            this.LblAdd5.TabIndex = 29;
            this.LblAdd5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd3
            // 
            this.LblAdd3.BackColor = System.Drawing.Color.White;
            this.LblAdd3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd3.ForeColor = System.Drawing.Color.Black;
            this.LblAdd3.Location = new System.Drawing.Point(2, 63);
            this.LblAdd3.Name = "LblAdd3";
            this.LblAdd3.Size = new System.Drawing.Size(230, 19);
            this.LblAdd3.TabIndex = 27;
            this.LblAdd3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdd6
            // 
            this.LblAdd6.BackColor = System.Drawing.Color.White;
            this.LblAdd6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdd6.ForeColor = System.Drawing.Color.Black;
            this.LblAdd6.Location = new System.Drawing.Point(2, 126);
            this.LblAdd6.Name = "LblAdd6";
            this.LblAdd6.Size = new System.Drawing.Size(230, 19);
            this.LblAdd6.TabIndex = 30;
            this.LblAdd6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GBAdded
            // 
            this.GBAdded.BackColor = System.Drawing.Color.Transparent;
            this.GBAdded.Controls.Add(this.LblAdded15);
            this.GBAdded.Controls.Add(this.LblAdded14);
            this.GBAdded.Controls.Add(this.LblAdded13);
            this.GBAdded.Controls.Add(this.LblAdded12);
            this.GBAdded.Controls.Add(this.LblAdded11);
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
            // LblAdded15
            // 
            this.LblAdded15.BackColor = System.Drawing.Color.White;
            this.LblAdded15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded15.ForeColor = System.Drawing.Color.Black;
            this.LblAdded15.Location = new System.Drawing.Point(2, 315);
            this.LblAdded15.Name = "LblAdded15";
            this.LblAdded15.Size = new System.Drawing.Size(230, 19);
            this.LblAdded15.TabIndex = 24;
            this.LblAdded15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded14
            // 
            this.LblAdded14.BackColor = System.Drawing.Color.White;
            this.LblAdded14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded14.ForeColor = System.Drawing.Color.Black;
            this.LblAdded14.Location = new System.Drawing.Point(2, 294);
            this.LblAdded14.Name = "LblAdded14";
            this.LblAdded14.Size = new System.Drawing.Size(230, 19);
            this.LblAdded14.TabIndex = 23;
            this.LblAdded14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded13
            // 
            this.LblAdded13.BackColor = System.Drawing.Color.White;
            this.LblAdded13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded13.ForeColor = System.Drawing.Color.Black;
            this.LblAdded13.Location = new System.Drawing.Point(2, 273);
            this.LblAdded13.Name = "LblAdded13";
            this.LblAdded13.Size = new System.Drawing.Size(230, 19);
            this.LblAdded13.TabIndex = 22;
            this.LblAdded13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded12
            // 
            this.LblAdded12.BackColor = System.Drawing.Color.White;
            this.LblAdded12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded12.ForeColor = System.Drawing.Color.Black;
            this.LblAdded12.Location = new System.Drawing.Point(2, 252);
            this.LblAdded12.Name = "LblAdded12";
            this.LblAdded12.Size = new System.Drawing.Size(230, 19);
            this.LblAdded12.TabIndex = 21;
            this.LblAdded12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded11
            // 
            this.LblAdded11.BackColor = System.Drawing.Color.White;
            this.LblAdded11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded11.ForeColor = System.Drawing.Color.Black;
            this.LblAdded11.Location = new System.Drawing.Point(2, 231);
            this.LblAdded11.Name = "LblAdded11";
            this.LblAdded11.Size = new System.Drawing.Size(230, 19);
            this.LblAdded11.TabIndex = 20;
            this.LblAdded11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded10
            // 
            this.LblAdded10.BackColor = System.Drawing.Color.White;
            this.LblAdded10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded10.ForeColor = System.Drawing.Color.Black;
            this.LblAdded10.Location = new System.Drawing.Point(2, 210);
            this.LblAdded10.Name = "LblAdded10";
            this.LblAdded10.Size = new System.Drawing.Size(230, 19);
            this.LblAdded10.TabIndex = 19;
            this.LblAdded10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded9
            // 
            this.LblAdded9.BackColor = System.Drawing.Color.White;
            this.LblAdded9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded9.ForeColor = System.Drawing.Color.Black;
            this.LblAdded9.Location = new System.Drawing.Point(2, 189);
            this.LblAdded9.Name = "LblAdded9";
            this.LblAdded9.Size = new System.Drawing.Size(230, 19);
            this.LblAdded9.TabIndex = 18;
            this.LblAdded9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded8
            // 
            this.LblAdded8.BackColor = System.Drawing.Color.White;
            this.LblAdded8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded8.ForeColor = System.Drawing.Color.Black;
            this.LblAdded8.Location = new System.Drawing.Point(2, 168);
            this.LblAdded8.Name = "LblAdded8";
            this.LblAdded8.Size = new System.Drawing.Size(230, 19);
            this.LblAdded8.TabIndex = 17;
            this.LblAdded8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded7
            // 
            this.LblAdded7.BackColor = System.Drawing.Color.White;
            this.LblAdded7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded7.ForeColor = System.Drawing.Color.Black;
            this.LblAdded7.Location = new System.Drawing.Point(2, 147);
            this.LblAdded7.Name = "LblAdded7";
            this.LblAdded7.Size = new System.Drawing.Size(230, 19);
            this.LblAdded7.TabIndex = 16;
            this.LblAdded7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded1
            // 
            this.LblAdded1.BackColor = System.Drawing.Color.White;
            this.LblAdded1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded1.ForeColor = System.Drawing.Color.Black;
            this.LblAdded1.Location = new System.Drawing.Point(2, 21);
            this.LblAdded1.Name = "LblAdded1";
            this.LblAdded1.Size = new System.Drawing.Size(230, 19);
            this.LblAdded1.TabIndex = 10;
            this.LblAdded1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded4
            // 
            this.LblAdded4.BackColor = System.Drawing.Color.White;
            this.LblAdded4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded4.ForeColor = System.Drawing.Color.Black;
            this.LblAdded4.Location = new System.Drawing.Point(2, 84);
            this.LblAdded4.Name = "LblAdded4";
            this.LblAdded4.Size = new System.Drawing.Size(230, 19);
            this.LblAdded4.TabIndex = 13;
            this.LblAdded4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded5
            // 
            this.LblAdded5.BackColor = System.Drawing.Color.White;
            this.LblAdded5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded5.ForeColor = System.Drawing.Color.Black;
            this.LblAdded5.Location = new System.Drawing.Point(2, 105);
            this.LblAdded5.Name = "LblAdded5";
            this.LblAdded5.Size = new System.Drawing.Size(230, 19);
            this.LblAdded5.TabIndex = 14;
            this.LblAdded5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded3
            // 
            this.LblAdded3.BackColor = System.Drawing.Color.White;
            this.LblAdded3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded3.ForeColor = System.Drawing.Color.Black;
            this.LblAdded3.Location = new System.Drawing.Point(2, 63);
            this.LblAdded3.Name = "LblAdded3";
            this.LblAdded3.Size = new System.Drawing.Size(230, 19);
            this.LblAdded3.TabIndex = 12;
            this.LblAdded3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAdded6
            // 
            this.LblAdded6.BackColor = System.Drawing.Color.White;
            this.LblAdded6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAdded6.ForeColor = System.Drawing.Color.Black;
            this.LblAdded6.Location = new System.Drawing.Point(2, 126);
            this.LblAdded6.Name = "LblAdded6";
            this.LblAdded6.Size = new System.Drawing.Size(230, 19);
            this.LblAdded6.TabIndex = 15;
            this.LblAdded6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TRefresh
            // 
            this.TRefresh.Interval = 8000;
            // 
            // TSender
            // 
            this.TSender.Interval = 10000;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SpecialShapeSmoke.Properties.Resources.mainbj;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(480, 378);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.MainScreen_Resize);
            this.panel1.ResumeLayout(false);
            this.GBToAdd.ResumeLayout(false);
            this.GBAdded.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblAdded2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnSeq;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.GroupBox GBToAdd;
        private System.Windows.Forms.Label LblAdd15;
        private System.Windows.Forms.Label LblAdd14;
        private System.Windows.Forms.Label LblAdd13;
        private System.Windows.Forms.Label LblAdd12;
        private System.Windows.Forms.Label LblAdd11;
        private System.Windows.Forms.Label LblAdd10;
        private System.Windows.Forms.Label LblAdd9;
        private System.Windows.Forms.Label LblAdd8;
        private System.Windows.Forms.Label LblAdd7;
        private System.Windows.Forms.Label LblAdd1;
        private System.Windows.Forms.Label LblAdd2;
        private System.Windows.Forms.Label LblAdd4;
        private System.Windows.Forms.Label LblAdd5;
        private System.Windows.Forms.Label LblAdd3;
        private System.Windows.Forms.Label LblAdd6;
        private System.Windows.Forms.GroupBox GBAdded;
        private System.Windows.Forms.Label LblAdded15;
        private System.Windows.Forms.Label LblAdded14;
        private System.Windows.Forms.Label LblAdded13;
        private System.Windows.Forms.Label LblAdded12;
        private System.Windows.Forms.Label LblAdded11;
        private System.Windows.Forms.Label LblAdded10;
        private System.Windows.Forms.Label LblAdded9;
        private System.Windows.Forms.Label LblAdded8;
        private System.Windows.Forms.Label LblAdded7;
        private System.Windows.Forms.Label LblAdded1;
        private System.Windows.Forms.Label LblAdded4;
        private System.Windows.Forms.Label LblAdded5;
        private System.Windows.Forms.Label LblAdded3;
        private System.Windows.Forms.Label LblAdded6;
        private System.Windows.Forms.Timer TRefresh;
        private System.ComponentModel.BackgroundWorker BGWConn;
        private System.Windows.Forms.Timer TSender;
    }
}

