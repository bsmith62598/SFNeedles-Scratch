using System.Web.Mvc;

namespace NeedlesAndScratch.UI.Secured
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
