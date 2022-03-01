using System.Web;
using System.Web.Mvc;

namespace MVCVidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Very restrictive filter - you can't get pass the home page.
            filters.Add(new AuthorizeAttribute());

            filters.Add(new RequireHttpsAttribute());
        }
    }
}
