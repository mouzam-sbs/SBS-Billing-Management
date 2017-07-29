using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using Microsoft.Owin.Security.Cookies;

 

namespace SBSBillingSoftware.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Billing",
                LoginPath = new PathString("/Account"),
                CookieSecure = CookieSecureOption.SameAsRequest,
                ExpireTimeSpan = TimeSpan.FromDays(1),
            });
            System.Web.Helpers.AntiForgeryConfig.SuppressIdentityHeuristicChecks = true;
        }
    }
}
