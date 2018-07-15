using CreateIndustry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreateIndustry.Attribute
{
    public class IdentityAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            else if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }

            if (!filterContext.HttpContext.User.Identity.IsAuthenticated || !IdentitySession.Instance.IsAuthorization)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}