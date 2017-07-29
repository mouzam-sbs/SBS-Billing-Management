using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BOL.Helpers.Enums;
namespace BOL.Extensions
{
    public static class Extensions
    {
        public static Int64 GetID(this IIdentity identity)
        {
            if (identity == null)
                return 0;

            var claims = identity as ClaimsIdentity;

            if (claims.FindFirst("ID") == null)
                return 0;

            return Convert.ToInt64(claims.FindFirst("ID").Value);
        }

        public static UserRole GetRole(this IIdentity identity)
        {
            if (identity == null)
                return UserRole.Empty;

            var claims = identity as ClaimsIdentity;

            if (claims.FindFirst("Role") == null)
                return UserRole.Empty;

            UserRole role = (UserRole)LoggedInnMessage.Parse(typeof(UserRole), claims.FindFirst("Role").Value);
            return role;
        } 
    }
}
