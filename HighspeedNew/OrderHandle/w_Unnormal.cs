using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Modle;
using Business.BusinessClass;

namespace HighspeedNew.OrderHandle
{
    public partial class w_Unnormal : Form
    {
        public w_Unnormal()
        {
            InitializeComponent();
            List<AllOrderData> list=new List<AllOrderData> ();
            list=OrderClass.GetUnnormalCig();
            orderdata.DataSource = list;
        }
    }
}
