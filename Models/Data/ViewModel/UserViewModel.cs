using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Data.ViewModel
{
    /// <summary>
    /// 客戶資料模型
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// 客戶編號
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 客戶姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 客戶手機
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 客戶信箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 國文分數
        /// </summary>
        public double Chinese { get; set; }

        /// <summary>
        /// 數學分數
        /// </summary>
        public double Math { get; set; }

        /// <summary>
        /// 英文分數
        /// </summary>
        public double English { get; set; }
    }
}
