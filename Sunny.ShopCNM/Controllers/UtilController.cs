using Sunny.ShopCNM.Common;
using Sunny.ShopCNM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.ShopCNM.Controllers
{
    public class UtilController : Controller
    {
        DataModelContainer dbContext = new DataModelContainer();
        // GET: Util
        /// <summary>
        /// 根据ajax获取城市
        /// </summary>
        /// <param name="aid">要获取城市的id</param>
        /// <returns></returns>
        public ActionResult AjaxToGetCity(string aid)
        {
            // aid = 360000
            var pid = dbContext.Address.Where(a => a.Aid == aid).FirstOrDefault().Pid;
            var citys = dbContext.Address.Where(a => a.Pid == pid).ToList();
            Dictionary<string, string> cityDic = new Dictionary<string, string>();
            foreach (var city in citys)
            {
                cityDic.Add(city.Aid, city.Name);
            }
            return Content(MyUtils.SerializeDictionaryToJsonString<string, string>(cityDic));
        }

        /// <summary>
        /// 根据ajax获取城市
        /// </summary>
        /// <param name="aid">要获取城市的id</param>
        /// <returns></returns>
        public ActionResult AjaxToGetCityByChange(string aid)
        {
            // aid = 360000   pid = aid
            //var pid = dbContext.Address.Where(a => a.Aid == aid).FirstOrDefault().Pid;
            var citys = dbContext.Address.Where(a => a.Pid == aid).ToList();
            Dictionary<string, string> cityDic = new Dictionary<string, string>();
            foreach (var city in citys)
            {
                cityDic.Add(city.Aid, city.Name);
            }
            return Content(MyUtils.SerializeDictionaryToJsonString<string, string>(cityDic));
        }

        public ActionResult AjaxGetAllPro()
        {
            Dictionary<int, string> allPro = new Dictionary<int, string>();
            foreach (var pro in dbContext.Provider)
            {
                allPro.Add(pro.Id, pro.PName);
            }
            return Content(MyUtils.SerializeDictionaryToJsonString(allPro));
        }

        public ActionResult AjaxCheckLogName()
        {
            string name = Request.QueryString["v"];
            //dbContext.UserInfo.Where()
            return Content("???");
        }

        [HttpPost]
        public ActionResult AjaxCheckLogin(string LoginName, string ajaxparam)
        {
            LoginName = Session["userName"] == null ? LoginName : Session["userPhone"] == null ? Session["userName"].ToString() : Session["userPhone"].ToString();
            int b = dbContext.AdminInfo.Where(u => u.AdminName == LoginName && u.AdminPwd == ajaxparam).Count();
            if (b != 0)
            {
                return Content("ok");
            }
            else
            {
                b = dbContext.UserInfo.Where(u => u.UPhone == LoginName && u.UPwd == ajaxparam).Count();
                if (b != 0)
                {
                    return Content("ok");
                }
                else
                {
                    return Content(LoginName + ":" + ajaxparam);
                }
            }
        }

        public ActionResult AjaxCheckPhone(string ajaxparam)
        {
            return Content(dbContext.UserInfo.Where(u => u.UPhone == ajaxparam).Count() > 0 ? "no" : "ok");
        }
    }
}