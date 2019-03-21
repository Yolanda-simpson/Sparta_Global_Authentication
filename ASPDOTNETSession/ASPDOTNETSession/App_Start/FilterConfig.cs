using System.Web;
using System.Web.Mvc;

namespace ASPDOTNETSession
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
