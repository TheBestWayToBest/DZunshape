using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Modle;

namespace HighspeedNew.OrderHandle
{
    public partial class w_SortReplace : Form
    {
        public w_SortReplace()
        {
            InitializeComponent();
        }

        private void BtnLastCheck_Click(object sender, EventArgs e)
        {
            w_SortReplaceHandle frm = new w_SortReplaceHandle();
            frm.ShowDialog();

            SortReplaceInfo info = new SortReplaceInfo();
            info = frm.ReturnObj;
            TxtLastThrough.Text = info.MachineSeq.ToString();
            LblLastCode.Text = info.CigaretteCode;
            LblLastName.Text = info.CigaretteName;
        }

        private void BtnNewCheck_Click(object sender, EventArgs e)
        {
            w_SortReplaceHandle frm = new w_SortReplaceHandle();
            frm.ShowDialog();

            SortReplaceInfo info = new SortReplaceInfo();
            info = frm.ReturnObj;
            TxtNewThrough.Text = info.MachineSeq.ToString();
            LblNewCode.Text = info.CigaretteCode;
            LblNewName.Text = info.CigaretteName;
        }
    }
}
