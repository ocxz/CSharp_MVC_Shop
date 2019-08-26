using Sunny.Mvc.ShopCNM.UI.Models.Filter;
using System.Web;
using System.Web.Mvc;

namespace Sunny.Mvc.ShopCNM.UI
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
