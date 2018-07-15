using Models.Adapter;
using Models.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Module
{
    public class UserModule
    {
        /// <summary>
        /// 取得所有客戶的基本資料
        /// </summary>
        /// <returns>客戶基本資料清單</returns>
        public IEnumerable<User> GetAllUserInfo()
        {
            return new UserAdapter().GetAllUserInfo();
        }

        /// <summary>
        /// 根據客代取得客戶基本資料
        /// </summary>
        /// <param name="userID">客戶代碼</param>
        /// <returns>客戶基本資料</returns>
        public User GetUserInfoByUserID(int userID)
        {
            return new UserAdapter().GetUserInfoByUserID(userID);
        }

        /// <summary>
        /// 新增客戶基本資料
        /// </summary>
        /// <param name="userID">客戶代碼</param>
        /// <param name="userName">客戶姓名</param>
        /// <param name="mobile">客戶手機</param>
        /// <param name="email">客戶信箱</param>
        public void AddUserInfo(int userID, string userName, string mobile, string email)
        {
            new UserAdapter().AddUserInfo(userID, userName, mobile, email);
        }

        /// <summary>
        /// 修改客戶基本資料
        /// </summary>
        /// <param name="userID">客戶代碼</param>
        /// <param name="userName">客戶姓名</param>
        public void UpdateUserInfo(int userID, string userName)
        {
            new UserAdapter().UpdateUserInfo(userID, userName);
        }

        /// <summary>
        /// 刪除客戶基本資料
        /// </summary>
        /// <param name="userID">客戶代碼</param>
        public void RemoveUserInfo(int userID)
        {
            new UserAdapter().RemoveUserInfo(userID);
        }
    }
}
