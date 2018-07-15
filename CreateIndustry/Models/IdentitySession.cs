using Models.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreateIndustry.Models
{
    public class IdentitySession
    {
        private static Lazy<IdentitySession> _identitySession = new Lazy<IdentitySession>(() => { return new IdentitySession(); });

        private IdentitySession() { }

        public static IdentitySession Instance => _identitySession.Value;

        public bool IsAuthorization
        {
            get
            {
                return Convert.ToBoolean(HttpContext.Current.Session[SessionKey.IsAuthorization]);
            }

            set
            {
                HttpContext.Current.Session[SessionKey.IsAuthorization] = value;
            }
        }

        public User User
        {
            get
            {
                return (User)HttpContext.Current.Session[SessionKey.User] ?? new User();
            }

            set
            {
                HttpContext.Current.Session[SessionKey.User] = value;
            }
        }
    }

    public class SessionKey
    {
        public const string User = "UserInfo";
        public const string IsAuthorization = "IsAuthorization";

    }
}