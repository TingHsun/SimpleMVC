using Models.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Adapter
{
    public class ScoreAdapter
    {
        /// <summary>
        /// 根據客代取得客戶分數資料
        /// </summary>
        /// <param name="userID">客戶代碼</param>
        /// <returns>客戶分數資料</returns>
        public Score GetScoreInfoByUserID(int userID)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                var result = db.Score.Where(s => s.UserID == userID).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// 新增客戶的分數資料
        /// </summary>
        /// <param name="userID">客戶代碼</param>
        /// <param name="chinese">國文分數</param>
        /// <param name="math">數學分數</param>
        /// <param name="english">英文分數</param>
        public void AddUserScore(int userID, double chinese, double math, double english)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                db.Score.Add(new Score
                {
                    UserID = userID,
                    Chinese = chinese,
                    Math = math,
                    English = english
                });

                db.SaveChanges();
            }
        }

        /// <summary>
        /// 修改客戶的分數資料
        /// </summary>
        /// <param name="userID">客戶代碼</param>
        /// <param name="chinese">國文分數</param>
        /// <param name="math">數學分數</param>
        /// <param name="english">英文分數</param>
        public void UpdateUserScore(int userID, double chinese, double math, double english)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                var score = db.Score.Where(s => s.UserID == userID).FirstOrDefault();
                score.Chinese = chinese;
                score.Math = math;
                score.English = english;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// 刪除客戶的分數資料
        /// </summary>
        /// <param name="userID">客戶代碼</param>
        public void RemoveUserScore(int userID)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                var score = db.Score.Where(s => s.UserID == userID).FirstOrDefault();
                if (score != null)
                {
                    db.Score.Remove(score);
                }

                db.SaveChanges();
            }
        }
    }
}
