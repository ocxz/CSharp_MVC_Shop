using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.ShopCNM.Models
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class LimitFilterAttribute : ActionFilterAttribute
    {
        public int ToLook { get; set; }
        public string ToJumpUrl { get; set; }
        public LimitFilterAttribute()
        {

        }
        public LimitFilterAttribute(int toLook,string toJumpUrl)
        {
            this.ToLook = toLook;
            this.ToJumpUrl = toJumpUrl;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int toLook = int.Parse(filterContext.HttpContext.Session["level"].ToString());
            if (toLook > ToLook)
            {
                filterContext.HttpContext.Response.Redirect(ToJumpUrl);
            }
        }
    }
}
