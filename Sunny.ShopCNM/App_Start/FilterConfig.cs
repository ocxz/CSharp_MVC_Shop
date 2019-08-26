using Sunny.ShopCNM.Models;
using System.Web;
using System.Web.Mvc;

namespace Sunny.ShopCNM
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AllowFilterAttribute());
        }
    }
}
