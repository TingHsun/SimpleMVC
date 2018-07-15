using Models.Adapter;
using Models.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Models.Module
{
    public class AccountModule
    {
        /// <summary>
        /// 檢查帳號是否已經存在
        /// </summary>
        /// <param name="email">信箱</param>
        /// <returns></returns>
        public bool CheckAccountExist(string email)
        {
            var user = new AccountAdapter().GetAccountInfo(email);
            if (user != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 註冊帳號
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="email">信箱</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        public int Register(string name, string email, string password)
        {
            return new AccountAdapter().Register(name, email, HttpUtility.UrlEncode(password));
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="email">信箱</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        public Tuple<bool, string> Login(string email, string password, out User account)
        {
            account = new AccountAdapter().GetAccountInfo(email);
            if (account == null)
            {
                return new Tuple<bool, string>(false, "帳號不存在");
            }
            else if (HttpUtility.UrlEncode(password) != account.Password)
            {
                return new Tuple<bool, string>(false, "密碼錯誤");
            }
            //else if (account.Level < 0)
            //{
            //    return new Tuple<bool, string>(false, "帳號無法使用");
            //}
            else
            {
                return new Tuple<bool, string>(true, string.Empty);
            }
        }
    }
}
