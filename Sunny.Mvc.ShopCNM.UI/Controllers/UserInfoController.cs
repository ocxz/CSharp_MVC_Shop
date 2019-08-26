using Sunny.Mvc.ShopCNM.BLL;
using Sunny.Mvc.ShopCNM.IBLL;
using Sunny.Mvc.ShopCNM.Model;
using Sunny.Mvc.ShopCNM.UI.Models.Filter;
using Sunny.Mvc.ShopCNM.UI.Models.Show;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.ShopCNM.Controllers
{
    public class UserInfoController : Controller
    {
        UserInfoService userInfoService = new UserInfoService();
        AddressService addressService = new AddressService();
        DataModelContainer t = new DataModelContainer();
        // GET: UserInfo
        public ActionResult Index(int pageIndex = 1, string uNamelike="")
        {
            int pageSize = Request.Cookies["pageSize"] == null ? 5 : int.Parse(Request.Cookies["pageSize"].Value);
            IQueryable<UserInfo> userInfo;
            // 如果没有名字查询
            if (string.IsNullOrEmpty(uNamelike.Trim()))
            {
                //userInfo = dbContext.UserInfo;
                userInfo = userInfoService.GetEntities(u => true);
                uNamelike = "";
            }
            else
            {
                //userInfo = dbContext.UserInfo.Where(u => u.UName.Contains(uNamelike));
                userInfo = userInfoService.GetEntities(u => u.UName.Contains(uNamelike));
            }
            ViewData["totalPage"] = userInfo.Count(); ;
            ViewData["pageSize"] = pageSize;
            ViewData["pageIndex"] = pageIndex;
            ViewData["uNamelike"] = uNamelike;
            ViewData["limited"] = int.Parse(Session["level"].ToString()) > 1;
            Session["pageIndex"] = pageIndex;
            Session["toLook"] = "3";
            Response.Cookies["pageSize"].Value = "5";
            List<UserInfoShow> userInfoShows = new List<UserInfoShow>();
            foreach (var item in userInfo.OrderBy(u => u.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize))
            {
                userInfoShows.Add(new UserInfoShow(item));
            }
            ViewData.Model = userInfoShows;

            return View();
        }

        [LimitFilter(1, "../Index/Index")]
        public ActionResult AddUser()
        {
            //ViewData.Model = dbContext.Address.Where(a => a.Pid == "100000").ToList();
            //ViewData.Model = userInfoService.GetEntities(a => a.Pid == "100000").ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserInfo userInfo, string UCounty)
        {
            //userInfo.AddressId = dbContext.Address.Where(a => a.Aid == UCounty).FirstOrDefault().Id;
            userInfo.AddressId = addressService.GetEntities(a => a.Aid == UCounty).FirstOrDefault().Id;
            //dbContext.UserInfo.Add(userInfo);
            userInfoService.Add(userInfo);
            //dbContext.SaveChanges();
            userInfoService.DbSession.SaveChanges<DataModelContainer>();
            return RedirectToAction("Index", new { pageIndex = Session["pageIndex"] });
        }

        public ActionResult ShowUser(int userId,string uNamelike="")
        {
            //UserInfo userInfo = dbContext.UserInfo.Find(userId);
            UserInfo userInfo = userInfoService.GetEntities(u => u.Id == userId).FirstOrDefault();
            UserInfoShow userInfoShow = new UserInfoShow(userInfo);
            ViewData["UBirthday"] = userInfo.UBirthday == null ? "暂无" : ((DateTime)userInfo.UBirthday)
                .ToString("yyyy年MM月dd日");
            ViewData["uNamelike"] = uNamelike;
            ViewData.Model = userInfoShow;
            return View();
        }

        [LimitFilter(1, "../Index/Index")]
        public ActionResult DeleteUser(int userId)
        {
            //UserInfo userInfo = dbContext.UserInfo.Find(userId);
            UserInfo userInfo = userInfoService.GetEntities(u => u.Id == userId).FirstOrDefault();
            //dbContext.Entry(userInfo).State = System.Data.Entity.EntityState.Deleted;
            userInfoService.Delete(userInfo);
            //dbContext.SaveChanges();
            userInfoService.DbSession.SaveChanges<DataModelContainer>();
            return RedirectToAction("Index", new { pageIndex = Session["pageIndex"] });
        }

        [LimitFilter(1, "../Index/Index")]
        public ActionResult UpdateUser(int userId)
        {
            //UserInfo userInfo = dbContext.UserInfo.Find(userId);
            UserInfo userInfo = userInfoService.GetEntities(u => u.Id == userId).FirstOrDefault();
            //var City = dbContext.Address.Where(a => a.Aid == userInfo.Address.Pid).FirstOrDefault();
            var City = addressService.GetEntities(a => a.Aid == userInfo.Address.Pid).FirstOrDefault();
            //var Pro = dbContext.Address.Where(a => a.Aid == City.Pid).FirstOrDefault();
            var Pro = addressService.GetEntities(a => a.Aid == City.Pid).FirstOrDefault();
            ViewData["userId"] = userId;
            ViewData["City"] = City;
            ViewData["Pro"] = Pro;
            ViewData.Model = userInfo;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUser(UserInfo userInfo, string UCounty)
        {
            //userInfo.AddressId = dbContext.Address.Where(a => a.Aid == UCounty).FirstOrDefault().Id;
            userInfo.AddressId = addressService.GetEntities(a => a.Aid == UCounty).FirstOrDefault().Id;
            //string str = "";
            //foreach (var prop in userInfo.GetType().GetProperties())
            //{
            //    str += prop.Name + "  " + prop.GetValue(userInfo) + "</br>";
            //}
            //return Content(str);
            //dbContext.Entry(userInfo).State = System.Data.Entity.EntityState.Modified;
            //dbContext.SaveChanges();
            addressService.DbSession.SaveChanges<DataModelContainer>();
            return RedirectToAction("Index", new { pageIndex = Session["pageIndex"]});

        }
    }
}