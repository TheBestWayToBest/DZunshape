using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HighSpeed.OrderHandle;

namespace HighSpeed
{
    public partial class w_main : Form
    {
        public w_main()
        {
            //this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(this);
            //this.skinEngine1.SkinFile = Application.StartupPath + @"\Skin\SportsBlack.ssk";

            InitializeComponent();
            toolStripStatusLabel1.Text = "长株潭烟草物流";
            toolStripStatusLabel2.Text = "当前用户：";//+ //PublicFun.PubStruserempname;
            toolStripStatusLabel3.Text = "登录时间：" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void TSM_OrderReceive_Click(object sender, EventArgs e)
        {
            w_Order_Recieve frm = new w_Order_Recieve();
            if (CheckExist(frm))
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        #region 查找是否已经打开
        /// <summary>
        /// 查找是否已经打开
        /// </summary>
        /// <param name="frm"></param>
        /// <returns></returns>
        private bool CheckExist(Form frm)
        {
            bool blResult = false;
            for (int i = 0; i < MdiChildren.Length; i++)
            {
                if (MdiChildren[i].GetType().Name == frm.GetType().Name)
                {
                    Form tmpFrm = MdiChildren[i];
                    if (tmpFrm.Text == frm.Text)
                    {
                        blResult = true;
                        tmpFrm.Activate();
                    }
                    else if (frm.Text == "")
                    {
                        blResult = true;
                        tmpFrm.Activate();
                    }
                    else if (frm.GetType().Name.ToLower() == "w_export_new")
                    {
                        blResult = true;
                        tmpFrm.Activate();
                    }
                }
            }
            return blResult;
        }
        #endregion

        private void 数据库设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 分拣批次管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            w_Batch frm = new w_Batch();
            if (CheckExist(frm))
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 分拣通道管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            win_trough frm = new win_trough();
            if (CheckExist(frm) == true)
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 预排程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            win_schedule frm = new win_schedule();
            if (CheckExist(frm) == true)
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 任务排程ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            w_SortFm frm = new w_SortFm();
            if (CheckExist(frm) == true)
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 订单信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            w_CigaretteInfo frm = new w_CigaretteInfo();
            if (CheckExist(frm) == true)
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 任务导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            w_CigaretteInfo frm = new w_CigaretteInfo();
            if (CheckExist(frm) == true)
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

    }
}
