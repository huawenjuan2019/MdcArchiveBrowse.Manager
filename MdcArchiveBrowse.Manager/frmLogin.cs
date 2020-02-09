using MdcArchiveBrowse.Manager.Model;
using MDK.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MdcArchiveBrowse.Manager
{
    public partial class frmLogin : Form
    {
        frmLogin loginForm = null;
        static string encryptKey = "abcd";//字符串加密密钥(注意：密钥只能是4位)
        private UserInfo uiLogin;//用户登录信息

        public frmLogin(ref UserInfo ui)
        {
            InitializeComponent();
            uiLogin = ui;
            // 预编译条件
            this.MaximizeBox = false;//使最大化窗口失效
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "data.bin")) startUserInfo();
        }

        /// <summary>
        /// 登录程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicUserInfo = new Dictionary<string, string>();
            if (cbxIsRemember.Checked)
            {
                dicUserInfo.Add(txtUserName.Text, txtPassWord.Text);
                string str = JsonConvert.SerializeObject(dicUserInfo); ;
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "data.bin"))
                {
                    System.IO.FileStream f = System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "data.bin");
                    f.Close();
                    f.Dispose();
                }
                StreamWriter strmsave = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "data.bin", false, System.Text.Encoding.Default);
                strmsave.WriteLine(Encrypt(str));
                strmsave.Close();
            }
            if (txtUserName.Text == "Admin" && txtPassWord.Text == "123456")
            {
                uiLogin.UserName = txtUserName.Text.Trim();
                uiLogin.Password = txtPassWord.Text.Trim();

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show("用户名或密码不正确！");
                txtUserName.Focus();
            }
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 初始化用户名密码
        /// </summary>
        public void startUserInfo()
        {
            UserInfo userInfo = new UserInfo();
            StreamReader sr = new StreamReader("data.bin", Encoding.Default);
            string str = sr.ReadLine();
            if (!string.IsNullOrEmpty(str))
            {
                Dictionary<string, string> dicUserInfo = JsonConvert.DeserializeObject<Dictionary<string, string>>(Decrypt(str));
                txtUserName.Text = (dicUserInfo.Keys.ToList())[0];
                txtPassWord.Text = (dicUserInfo.Values.ToList())[0];
                cbxIsRemember.Checked = true;
            }
            sr.Close();
        }

        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.Cancel &&
                this.DialogResult != DialogResult.OK)
                e.Cancel = true;
        }

        /// <summary>
        /// 加密要保存的内容
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Encrypt(string str)
        {//加密字符串
            try
            {
                byte[] key = Encoding.Unicode.GetBytes(encryptKey);//密钥
                byte[] data = Encoding.Unicode.GetBytes(str);//待加密字符串
                DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();//加密、解密对象
                MemoryStream MStream = new MemoryStream();//内存流对象
                                                            //用内存流实例化加密流对象
                CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
                CStream.Write(data, 0, data.Length);//向加密流中写入数据
                CStream.FlushFinalBlock();//将数据压入基础流
                byte[] temp = MStream.ToArray();//从内存流中获取字节序列
                CStream.Close();//关闭加密流
                MStream.Close();//关闭内存流
                return Convert.ToBase64String(temp);//返回加密后的字符串
            }
            catch
            {
                return str;
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Decrypt(string str)
        {//解密字符串
            try
            {
                byte[] key = Encoding.Unicode.GetBytes(encryptKey);//密钥
                byte[] data = Convert.FromBase64String(str);//待解密字符串
                DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();//加密、解密对象
                MemoryStream MStream = new MemoryStream();//内存流对象
                                                            //用内存流实例化解密流对象
                CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
                CStream.Write(data, 0, data.Length);//向加密流中写入数据
                CStream.FlushFinalBlock();//将数据压入基础流
                byte[] temp = MStream.ToArray();//从内存流中获取字节序列
                CStream.Close();//关闭加密流
                MStream.Close();//关闭内存流
                return Encoding.Unicode.GetString(temp);//返回解密后的字符串
            }
            catch
            {
                return str;
            }
        }
    }
    
}
