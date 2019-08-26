using Sunny.Mvc.ShopCNM.BLL;
using Sunny.Mvc.ShopCNM.Model;
using Sunny.Mvc.ShopCNM.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.Mvc.ShopCNM.UI.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Test()
        {
            TestModel obj = new TestModel()
            {
                id = "1",
                name = "1"
            };
            //return Json(obj);
            //return FileResult();
            //return PartialView();
            //return View("", obj);
            //return RedirectToAction();
            return View(obj);
        }

        //DataModelContainer dbContext = new DataModelContainer();
        AdminInfoService adminInfoService = new AdminInfoService();
        UserInfoService userInfoService = new UserInfoService();
        public ActionResult Index()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        // GET: Admin
        public ActionResult Login(string loginName)
        {
            Session.Clear();
            ViewData["LoginName"] = loginName;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string LoginName,string LoginPwd)
        {
            //int b = dbContext.AdminInfo.Where(u=>u.AdminName == LoginName && u.AdminPwd == LoginPwd).Count();
            int b = adminInfoService.GetEntities(u => u.AdminName == LoginName && u.AdminPwd == LoginPwd).Count();
            if (b != 0)
            {
                Session["userName"] = LoginName;
                Session["level"] = 1;
                return RedirectToAction("Index", "Index");
            }
            else
            {
                //b = dbContext.UserInfo.Where(u =>u.UPhone == LoginName && u.UPwd == LoginPwd).Count();
                b = userInfoService.GetEntities(u => u.UPhone == LoginName && u.UPwd == LoginPwd).Count();
                if (b != 0)
                {
                    Session["userPhone"] = LoginName;
                    //var user = dbContext.UserInfo.Where(u => u.UPhone == LoginName).FirstOrDefault();
                    var user = userInfoService.GetEntities(u => u.UPhone == LoginName).FirstOrDefault();
                    Session["userName"] = user.UName;
                    Session["level"] = user.UCategory;
                    return RedirectToAction("Index", "Index");
                }
                else
                {
                    return RedirectToAction("Login",new {loginName=LoginName });
                }
            }               
        }
    }
}