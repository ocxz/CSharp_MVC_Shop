using System.Web;
using System.Web.Mvc;

namespace Sunny.ShopCNM.UITest2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
