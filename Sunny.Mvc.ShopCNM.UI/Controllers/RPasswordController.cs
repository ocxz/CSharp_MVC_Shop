using Sunny.Mvc.ShopCNM.BLL;
using Sunny.Mvc.ShopCNM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.ShopCNM.Controllers
{
    public class RPasswordController : Controller
    {
        DataModelContainer t = new DataModelContainer();
        AdminInfoService adminInfoService = new AdminInfoService();
        UserInfoService userInfoService = new UserInfoService();
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
                //var admin = dbContext.AdminInfo.Where(a => a.AdminName == LoginName).FirstOrDefault();
                var admin = adminInfoService.GetEntities(a => a.AdminName == LoginName).FirstOrDefault();
                //int id = admin.Id;
                admin.AdminPwd = NewPassword;
                //dbContext.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                adminInfoService.Update(admin);
                //dbContext.SaveChanges();
                adminInfoService.DbSession.SaveChanges<DataModelContainer>();
            }
            else
            {
                //var user = dbContext.UserInfo.Where(u => u.UPhone == LoginName).FirstOrDefault();
                var user = userInfoService.GetEntities(u => u.UPhone == LoginName).FirstOrDefault();
                user.UPwd = NewPassword;
                //dbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
                userInfoService.Update(user);
                //dbContext.SaveChanges();
                userInfoService.DbSession.SaveChanges<DataModelContainer>();
            }
            return RedirectToAction("Index", "Index");
        }
    }
}