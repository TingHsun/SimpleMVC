using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Data.ViewModel
{
    /// <summary>
    /// 自動機台資料模型
    /// </summary>
    public class AutoMachineDataModel
    {
        [Required]
        [Display(Name = "型號")]
        public string TypeID { get; set; }

        [Required]
        [Display(Name = "長度")]
        public int Length { get; set; }

        [Display(Name = "作業描述")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "產能")]
        public int ProductionCapacity { get; set; }

        [Required]
        [Display(Name = "人數")]
        public int People { get; set; }

        [Display(Name = "備註")]
        public string Note { get; set; }

        [Required]
        [Display(Name = "測定日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TestDate { get; set; }

        [Display(Name = "流水號")]
        public int AutoID { get; set; }
    }
}
