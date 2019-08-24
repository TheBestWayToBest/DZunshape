using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.BusinessClass;

namespace HighspeedNew.OrderHandle
{
    public partial class w_SpecialShapePosition : Form
    {
        public w_SpecialShapePosition()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal sortNum;
            try
            {
                sortNum=decimal.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("任务号输入错误，请重新输入！");
                return;
            }
            int row = SortClass.SpecialSmokePosition(sortNum);
            if (row > 0)
                MessageBox.Show("任务定位成功");
            else if (row == 0)
                MessageBox.Show("任务定位成功，但受影响的行数为0");
            else
                MessageBox.Show("任务定位失败");
        }
    }
}
