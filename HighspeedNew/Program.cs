using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HighSpeed
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new w_main());
            }
            catch (Exception ex) 
            {
                if (ex.Message.Contains("Open"))
                    MessageBox.Show("数据库连接失败，请检查网络！");
                else
                    MessageBox.Show(ex.Message);
            }
        }
    }
}
