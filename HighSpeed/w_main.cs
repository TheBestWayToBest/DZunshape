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
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(this);
            this.skinEngine1.SkinFile = Application.StartupPath + @"\Skin\SportsBlack.ssk";
            InitializeComponent();
            
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

    }
}
