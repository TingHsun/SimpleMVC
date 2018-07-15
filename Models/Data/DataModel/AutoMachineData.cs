using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Data.DataModel
{
    /// <summary>
    /// 自動機台資料
    /// </summary>
    public class AutoMachineData
    {
        [Display(Name = "型號")]
        public string TypeID { get; set; }

        [Display(Name = "長度")]
        public int Length { get; set; }

        [Display(Name = "作業描述")]
        public string Description { get; set; }

        [Display(Name = "產能")]
        public int ProductionCapacity { get; set; }

        [Display(Name = "人數")]
        public int People { get; set; }

        [Display(Name = "備註")]
        public string Note { get; set; }

        [Display(Name = "測定日期")]
        [DataType(DataType.Date)]
        public DateTime TestDate { get; set; }

        [Key]
        [Display(Name = "流水號")]
        public int AutoID { get; set; }

        [Display(Name = "客戶編號")]
        public int UserID { get; set; }

        [Display(Name = "建立日期")]
        public DateTime CreatedDate { get; set; }
    }
}
