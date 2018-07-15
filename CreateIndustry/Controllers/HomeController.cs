using Models;
using Models.Data.DataModel;
using Models.Data.ViewModel;
using Models.Module;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreateIndustry.Controllers
{
    public class HomeController : Controller
    {
        private UserModule UserModule = new Lazy<UserModule>().Value;
        private ScoreModule ScoreModule = new Lazy<ScoreModule>().Value;

        public ActionResult Index()
        {
            int userID = 1000001;

            var user = UserModule.GetUserInfoByUserID(userID);

            //scoreModule.AddUserScore(userID, 90.5, 100, 86.8);

            //userModule.UpdateUserInfo(1000003, "Bii");

            var score = ScoreModule.GetScoreInfoByUserID(userID);

            ViewBag.TotalScore = score?.Chinese + score?.English + score?.Math ?? 0;

            var model = new UserViewModel
            {
                UserID = user.UserID,
                UserName = user.UserName,
                Email = user.Email,
                Mobile = user.Mobile,
                Chinese = score?.Chinese ?? 0,
                Math = score?.Math ?? 0,
                English = score?.English ?? 0
            };

            return View(model);
        }

        /// <summary>
        /// 增加總分
        /// </summary>
        /// <param name="score">原始總分</param>
        /// <returns>總分</returns>
        [HttpPost]
        public JsonResult AddScore(float score)
        {
            var value = 100; //每次增加100分

            return Json(new {
                Score = score + value
            });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}