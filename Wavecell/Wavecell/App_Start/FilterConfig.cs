using System.Web;
using System.Web.Mvc;
using Wavecell.Security;

namespace Wavecell
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogonAuthorize());
        }
    }
}