using CreateIndustry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CreateIndustry.Attribute
{
    /// <summary>
    /// 登入拒絕造訪
    /// </summary>
    public class LogonRejectAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated && IdentitySession.Instance.IsAuthorization)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                           { "controller", "Home" },
                           { "action", "Index" },
                           { "id", UrlParameter.Optional }
                    });
            }
        }
    }
}