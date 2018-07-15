using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Data.DataModel
{
    /// <summary>
    /// 分數
    /// </summary>
    public class Score
    {
        [Key]
        [DisplayName("流水號")]
        public int Seq { get; set; }

        [DisplayName("客戶代碼")]
        public int UserID { get; set; }

        [DisplayName("國文")]
        public double Chinese { get; set; }

        [DisplayName("數學")]
        public double Math { get; set; }

        [DisplayName("英文")]
        public double English { get; set; }
    }
}
