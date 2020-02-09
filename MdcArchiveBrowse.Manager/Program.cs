using MdcArchiveBrowse.Manager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MdcArchiveBrowse.Manager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            UserInfo ui = new UserInfo();//用户登录信息

            frmLogin myLogin = new frmLogin(ref ui);//加载登录窗体

            if (myLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());//如果登录成功则打开主窗体
            }
            else
            {

                MessageBox.Show("登陆失败!");

            }
        }
    }
}
