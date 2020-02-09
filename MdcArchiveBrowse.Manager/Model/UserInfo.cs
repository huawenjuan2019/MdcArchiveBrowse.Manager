using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MdcArchiveBrowse.Manager.Model
{
     /// <summary>
     /// 用户登录信息
     /// </summary>
    public class UserInfo
    {

        private string strUserName;

        private string strPassword;

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }

        public UserInfo()
        {
            strUserName = "";
            strPassword = "";
        }
    }
}
