using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Adapter;
using Models.Data.DataModel;
using Models.Data.ViewModel;

namespace Models.Module
{
    public class ReportModule
    {
        /// <summary>
        /// 取得自動機台報表
        /// </summary>
        /// <param name="userID">客戶編號</param>
        /// <param name="userLevel">客戶等級</param>
        /// <returns>客戶自動機台報表</returns>
        public IEnumerable<AutoMachineData> GetAutoMachineReport(int userID, int userLevel)
        {
            if (userLevel == 99) //管理員等級
                return new ReportAdapter().GetAllAutoMachineReport();
            else
                return new ReportAdapter().GetAutoMachineReport(userID);
        }

        /// <summary>
        /// 取得客戶自動機台單一資料
        /// </summary>
        /// <param name="userID">客戶編號</param>
        /// <param name="autoID">自動機台編號</param>
        /// <returns>客戶自動機台單一資料</returns>
        public AutoMachineData GetAutoMachineData(int userID, int autoID)
        {
            return new ReportAdapter().GetAutoMachineData(userID, autoID);
        }

        /// <summary>
        /// 新增自動機台資料
        /// </summary>
        /// <param name="data">自動機台資料模型</param>
        /// <param name="userID">客戶編號</param>
        public void CreateAutoMachineData(AutoMachineDataModel data, int userID)
        {
            var request = new AutoMachineData
            {
                TypeID = data.TypeID,
                Length = data.Length,
                Description = data.Description,
                ProductionCapacity = data.ProductionCapacity,
                People = data.People,
                Note = data.Note,
                TestDate = Convert.ToDateTime(data.TestDate),
                AutoID = data.AutoID,
                UserID = userID,
                CreatedDate = DateTime.Now
            };

            new ReportAdapter().CreateAutoMachineData(request);
        }

        /// <summary>
        /// 修改自動機台資料
        /// </summary>
        /// <param name="model">自動機台資料模型</param>
        /// <param name="userID">客戶編號</param>
        public void EditAutoMachineData(AutoMachineDataModel data, int userID)
        {
            var request = new AutoMachineData
            {
                TypeID = data.TypeID,
                Length = data.Length,
                Description = data.Description,
                ProductionCapacity = data.ProductionCapacity,
                People = data.People,
                Note = data.Note,
                TestDate = Convert.ToDateTime(data.TestDate),
                AutoID = data.AutoID,
                UserID = userID,
            };

            new ReportAdapter().EditAutoMachineData(request);
        }

        /// <summary>
        /// 檢查客戶是否擁有自動機台資料
        /// </summary>
        /// <param name="userID">客戶編號</param>
        /// <param name="autoID">自動機台編號</param>
        /// <returns></returns>
        public bool CheckUserCanDeleteAutoMachineData(int userID, int autoID)
        {
            bool result = new ReportAdapter().CheckUserCanDeleteAutoMachineData(userID, autoID);
            return result;
        }

        /// <summary>
        /// 刪除自動機台資料
        /// </summary>
        /// <param name="autoID">自動機台編號</param>
        public void DeleteAutoMachineData(int userID, int autoID)
        {
            if (this.CheckUserCanDeleteAutoMachineData(userID, autoID))
                new ReportAdapter().DeleteAutoMachineData(autoID);
            else
                throw new MissingFieldException();
        }
    }
}
