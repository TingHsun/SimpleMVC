using Models.Adapter;
using Models.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Module
{
    public class ScoreModule
    {
        /// <summary>
        /// 根據客代取得客戶分數資料
        /// </summary>
        /// <param name="userID">客戶代碼</param>
        /// <returns>客戶分數資料</returns>
        public Score GetScoreInfoByUserID(int userID)
        {
            return new ScoreAdapter().GetScoreInfoByUserID(userID);
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
            new ScoreAdapter().AddUserScore(userID, chinese, math, english);
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
            new ScoreAdapter().UpdateUserScore(userID, chinese, math, english);
        }

        /// <summary>
        /// 刪除客戶的分數資料
        /// </summary>
        /// <param name="userID">客戶代碼</param>
        public void RemoveUserScore(int userID)
        {
            new ScoreAdapter().RemoveUserScore(userID);
        }
    }
}
