using System.Web;
using System.Web.Mvc;

namespace Sunny.ShopCNM.UITest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
