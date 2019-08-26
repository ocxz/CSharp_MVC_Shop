using Sunny.ShopCNM.UITest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.ShopCNM.UITest2.Controllers
{
    public class UserInfoController : Controller
    {
        DataModelContainer dbContext = new DataModelContainer();
        // GET: UserInfo
        public ActionResult Index()
        {
            ViewData.Model = dbContext.UserInfo;
            return View();
        }

        // GET: UserInfo/Details/5
        public ActionResult Details(int id)
        {
            ViewData.Model = dbContext.UserInfo.Find(id);
            return View();
        }

        // GET: UserInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInfo/Create
        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            try
            {
                // TODO: Add insert logic here
                dbContext.UserInfo.Add(userInfo);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserInfo userInfo)
        {
            try
            {
                // TODO: Add update logic here
                dbContext.Entry(userInfo).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserInfo userInfo)
        {
            try
            {
                // TODO: Add delete logic here
                dbContext.Entry(userInfo).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
