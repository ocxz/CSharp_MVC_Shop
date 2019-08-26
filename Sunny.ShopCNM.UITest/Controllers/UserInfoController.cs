using Sunny.ShopCNM.UITest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.ShopCNM.UITest.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        public ActionResult Index()
        {
            DataModelContainer dbContext = new DataModelContainer();
            ViewData.Model = dbContext.UserInfo;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            DataModelContainer dbContext = new DataModelContainer();
            dbContext.UserInfo.Add(userInfo);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}