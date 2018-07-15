using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Data.DataModel;
using Models.Data.ViewModel;

namespace Models.Adapter
{
    public class ReportAdapter
    {
        /// <summary>
        /// 取得所有自動機台報表
        /// </summary>
        /// <returns>所有自動機台報表</returns>
        internal IEnumerable<AutoMachineData> GetAllAutoMachineReport()
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                return db.AutoMachineReport.OrderByDescending(x => x.AutoID).ToList();
            }
        }

        /// <summary>
        /// 取得客戶自動機台報表
        /// </summary>
        /// <param name="userID">客戶編號</param>
        /// <returns>客戶自動機台報表</returns>
        internal IEnumerable<AutoMachineData> GetAutoMachineReport(int userID)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                return db.AutoMachineReport.Where(x => x.UserID == userID).OrderByDescending(x => x.AutoID).ToList();
            }
        }

        /// <summary>
        /// 取得客戶自動機台單一資料
        /// </summary>
        /// <param name="userID">客戶編號</param>
        /// <param name="autoID">自動機台編號</param>
        /// <returns>客戶自動機台單一資料</returns>
        internal AutoMachineData GetAutoMachineData(int userID, int autoID)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                return db.AutoMachineReport.Where(x => x.UserID == userID && x.AutoID == autoID).FirstOrDefault();
            }
        }

        /// <summary>
        /// 新增自動機台資料
        /// </summary>
        /// <param name="request">自動機台資料請求</param>
        internal void CreateAutoMachineData(AutoMachineData request)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                db.AutoMachineReport.Add(new AutoMachineData
                {
                    TypeID = request.TypeID,
                    Length = request.Length,
                    Description = request.Description,
                    ProductionCapacity = request.ProductionCapacity,
                    People = request.People,
                    Note = request.Note,
                    TestDate = request.TestDate,
                    UserID = request.UserID,
                    CreatedDate = request.CreatedDate
                });

                db.SaveChanges();
            }
        }

        /// <summary>
        /// 修改自動機台資料
        /// </summary>
        /// <param name="request">自動機台資料請求</param>
        internal void EditAutoMachineData(AutoMachineData request)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                var data = db.AutoMachineReport.Where(x => x.UserID == request.UserID && x.AutoID == request.AutoID).FirstOrDefault();

                if (data != null)
                {
                    data.TypeID = request.TypeID;
                    data.Length = request.Length;
                    data.Description = request.Description;
                    data.ProductionCapacity = request.ProductionCapacity;
                    data.People = request.People;
                    data.Note = request.Note;
                    data.TestDate = request.TestDate;
                }

                db.SaveChanges();
            }
        }

        /// <summary>
        /// 檢查客戶是否擁有自動機台資料
        /// </summary>
        /// <param name="userID">客戶編號</param>
        /// <param name="autoID">自動機台編號</param>
        /// <returns></returns>
        internal bool CheckUserCanDeleteAutoMachineData(int userID, int autoID)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                return db.AutoMachineReport.Any(x => x.UserID == userID && x.AutoID == autoID);
            }
        }

        /// <summary>
        /// 刪除自動機台資料
        /// </summary>
        /// <param name="autoID">自動機台編號</param>
        internal void DeleteAutoMachineData(int autoID)
        {
            using (EntityFrameworkContext db = new EntityFrameworkContext())
            {
                var data = db.AutoMachineReport.Where(s => s.AutoID == autoID).FirstOrDefault();
                if (data != null)
                {
                    db.AutoMachineReport.Remove(data);
                }

                db.SaveChanges();
            }
        }
    }
}
