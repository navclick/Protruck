using ProTrukWeb.CustomFilters;
using System.Web;
using System.Web.Mvc;

namespace ProTrukWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           // filters.Add(new UserAuthenticationFilter());
        }
    }
}
