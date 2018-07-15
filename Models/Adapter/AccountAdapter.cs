using Models.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Adapter
{
    public class AccountAdapter
    {
        /// <summary>
        /// 檢查帳號是否已經存在
        /// </summary>
        /// <param name="email">信箱</param>
        /// <returns></returns>
        internal User GetAccountInfo(string email)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                var result = db.User.Where(s => s.Email == email).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// 註冊帳號
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="email">信箱</param>
        /// <param name="encodePassword">加密密碼</param>
        /// <returns></returns>
        internal int Register(string name, string email, string encodePassword)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                db.User.Add(new User
                {
                    UserName = name,
                    Email = email,
                    Password = encodePassword,
                    CreatedTime = DateTime.Now
                });

                db.SaveChanges();

                int id = db.User.Where(s => s.Email == email).First().UserID;

                return id;
            }
        }
    }
}
