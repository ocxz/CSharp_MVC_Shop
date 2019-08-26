using Sunny.ShopCNM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.ShopCNM.Controllers
{
    public class RPasswordController : Controller
    {
        DataModelContainer dbContext = new DataModelContainer();
        // GET: RPassword
        public ActionResult Index()
        {
            Session["toLook"] = "4";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string NewPassword)
        {
            string LoginName = Session["userPhone"] == null ? Session["userName"].ToString() : Session["userPhone"].ToString();

            if (Session["userPhone"] == null)
            {
                var admin = dbContext.AdminInfo.Where(a => a.AdminName == LoginName).FirstOrDefault();
                //int id = admin.Id;
                admin.AdminPwd = NewPassword;
                dbContext.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            else
            {
                var user = dbContext.UserInfo.Where(u => u.UPhone == LoginName).FirstOrDefault();
                user.UPwd = NewPassword;
                dbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Index");
        }
    }
}