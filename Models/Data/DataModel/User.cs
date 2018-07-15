using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Data.DataModel
{
    /// <summary>
    /// 使用者資料
    /// </summary>
    public class User
    {
        [Key]
        [DisplayName("客戶代碼")]
        public int UserID { get; set; }

        [DisplayName("客戶名稱")]
        public string UserName { get; set; }

        [DisplayName("客戶等級")]
        public int UserLevel { get; set; }

        [DisplayName("客戶手機")]
        public string Mobile { get; set; }

        [DisplayName("客戶信箱")]
        public string Email { get; set; }

        [DisplayName("客戶密碼")]
        public string Password { get; set; }

        [DisplayName("建立時間")]
        public DateTime CreatedTime { get; set; }
    }
}
