using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.Mvc.ShopCNM.UI.Models.Filter
{
    [AttributeUsage(AttributeTargets.All,AllowMultiple =true,Inherited =true)]
    public class AllowFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.Session["userName"] == null&& filterContext.HttpContext.Request.Path != "/Admin/Login")
            {
                filterContext.HttpContext.Response.Redirect("/Admin/Login");
            }
        }
    }
}