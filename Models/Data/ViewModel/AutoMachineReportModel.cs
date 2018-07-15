using Models.Data.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Data.ViewModel
{
    /// <summary>
    /// 自動機台報表模型
    /// </summary>
    [Serializable]
    public class AutoMachineReportModel
    {
        /// <summary>
        /// 自動機台資料清單
        /// </summary>
        public IEnumerable<AutoMachineDataModel> DataList { get; set; }
    }
}
