using System.Web;
using System.Web.Mvc;
using MVC03.Filter;
namespace MVC03
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AllowJsonGetAttribute());
        }
    }
}
