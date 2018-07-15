using CreateIndustry.Attribute;
using CreateIndustry.Models;
using Models.Data.DataModel;
using Models.Data.ViewModel;
using Models.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CreateIndustry.Controllers
{
    [IdentityAuthorize]
    public class ReportController : Controller
    {
        private ReportModule ReportModule = new Lazy<ReportModule>().Value;

        #region 自動機台報表

        public ActionResult AutoMachine()
        {
            int userLevel = IdentitySession.Instance.User.UserLevel;
            int userID = IdentitySession.Instance.User.UserID;

            IEnumerable<AutoMachineData> report = ReportModule.GetAutoMachineReport(userID, userLevel);

            var model = report.Select(data => new AutoMachineDataModel
            {
                TypeID = data.TypeID,
                Length = data.Length,
                Description = data.Description,
                ProductionCapacity = data.ProductionCapacity,
                People = data.People,
                Note = data.Note,
                TestDate = data.TestDate,
                AutoID = data.AutoID
            });

            return View(new AutoMachineReportModel { DataList = model });
        }

        public ActionResult AutoMachineCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AutoMachineCreate(AutoMachineDataModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                int userID = IdentitySession.Instance.User.UserID;
                ReportModule.CreateAutoMachineData(model, userID);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                return View(model);
            }

            return RedirectToAction("AutoMachine");
        }

        public ActionResult AutoMachineEdit(int id)
        {
            int userID = IdentitySession.Instance.User.UserID;

            var data = ReportModule.GetAutoMachineData(userID, id);

            if (data == null)
            {
                return RedirectToAction("AutoMachine");
            }

            var model = new AutoMachineDataModel
            {
                TypeID = data.TypeID,
                Length = data.Length,
                Description = data.Description,
                ProductionCapacity = data.ProductionCapacity,
                People = data.People,
                Note = data.Note,
                TestDate = data.TestDate,
                AutoID = data.AutoID
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AutoMachineEdit(AutoMachineDataModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                int userID = IdentitySession.Instance.User.UserID;
                ReportModule.EditAutoMachineData(model, userID);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                return View(model);
            }

            return RedirectToAction("AutoMachine");
        }

        [HttpPost]
        public JsonResult AutoMachineDelete(int autoID)
        {
            try
            {
                int userID = IdentitySession.Instance.User.UserID;

                ReportModule.DeleteAutoMachineData(userID, autoID);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Result = false,
                    Message = "刪除失敗"
                });
            }

            return Json(new
            {
                Result = true,
                Message = string.Empty
            });
        }

        #endregion 自動機台報表
    }
}