using Models.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;

namespace Models.Adapter
{
    public class UserAdapter
    {
        /// <summary>
        /// 取得所有客戶的基本資料
        /// </summary>
        /// <returns>客戶基本資料清單</returns>
        public IEnumerable<User> GetAllUserInfo()
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                //return db.User.ToList();
                string sql = @"SELECT Seq, UserID, UserName, Mobile, Email, CreatedTime FROM [dbo].[User]";
                var result = db.Database.SqlQuery<User>(sql);
                return result.ToList();
            }
        }

        #region 原生SqlConnection寫法
        /// <summary>
        /// 根據客代取得客戶基本資料
        /// </summary>
        public User GetUserInfoByUserIDCopy(int userID)
        {
            var user = new User();

            using (SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["EntityFramework"].ConnectionString))
            {
                sqlConnection.Open();

                string sql = @"[dbo].[sp_GetUserInfo]";

                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 60;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserID", userID));
                    
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.UserID = Convert.ToInt32(reader["UserID"]);
                            user.UserName = reader["UserName"].ToString();
                            user.Email = reader["Email"].ToString();
                            user.Mobile = reader["Mobile"].ToString();
                            user.CreatedTime = Convert.ToDateTime(reader["CreatedTime"]);
                        }
                    }

                    //sqlCommand.ExecuteNonQuery(); //執行新刪修，回傳成功次數的方法
                }
            }

            return user;
        }
        #endregion

        /// <summary>
        /// 根據客代取得客戶基本資料
        /// </summary>
        /// <param name="userID">客戶代碼</param>
        /// <returns>客戶基本資料</returns>
        public User GetUserInfoByUserID(int userID)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                string sp = @"[dbo].[sp_GetUserInfo] @UserID";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserID", userID),
                };
                var result = db.Database.SqlQuery<User>(sp, parameters).FirstOrDefault();
                return result;
            }
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
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                string sql = @"INSERT INTO [dbo].[User] (UserID, UserName, Mobile, Email, CreatedTime)
                                                VALUES (@UserID, @UserName, @Mobile, @Email, GETDATE())";
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserID", userID),
                    new SqlParameter("@UserName", userName),
                    new SqlParameter("@Mobile", mobile),
                    new SqlParameter("@Email", email)
                };
                db.Database.ExecuteSqlCommand(sql, parameters);
            }
        }

        /// <summary>
        /// 修改客戶基本資料
        /// </summary>
        /// <param name="userID">客戶代碼</param>
        /// <param name="userName">客戶姓名</param>
        public void UpdateUserInfo(int userID, string userName)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                string sp = @"[dbo].[sp_UpdateUserName] @UserID, @UserName";
                var parameters = new SqlParameter[]
                {
                    new SqlParameter { ParameterName = "@UserID", Value = userID },
                    new SqlParameter { ParameterName = "@UserName", Value = userName }
                };
                db.Database.ExecuteSqlCommand(sp, parameters);
            }
        }

        /// <summary>
        /// 刪除客戶基本資料
        /// </summary>
        /// <param name="userID">客戶代碼</param>
        public void RemoveUserInfo(int userID)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                string sql = @"DELETE [dbo].[User] WHERE UserID = @UserID";
                var parameters = new SqlParameter[]
                {
                    new SqlParameter { ParameterName = "@UserID", Value = userID }
                };
                db.Database.ExecuteSqlCommand(sql, parameters);
            }
        }
    }
}