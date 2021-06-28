using NeedlesAndScratch.UI.Secured.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NeedlesAndScratch.UI.Secured
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=301868
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            //Response.Redirect("~/Errors/Unresolved");

            //Instead, we can also go the SUPER SAFE route: Send the user to a basic HTML page that is hard to fail
            //Response.Redirect("~/error.html");
        }
    }
}
