using Sunny.Mvc.ShopCNM.BLL;
using Sunny.Mvc.ShopCNM.Model;
using Sunny.Mvc.ShopCNM.UI.Models.Filter;
using Sunny.Mvc.ShopCNM.UI.Models.Show;
using Sunny.Mvc.ShopCNM.UI.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.Mvc.ShopCNM.UI.Controllers
{
    public class BillController : Controller
    {
        //DataModelContainer dbContext = new DataModelContainer();
        BillService billService = new BillService();
        UserInfoService userInfoService = new UserInfoService();
        // GET: Bill
        public ActionResult Index(int pageIndex = 1, string bNamelike = "", string proId = "", string isPaid = "")
        {
            int pageSize = Request.Cookies["pageSize"] == null ? 5 : int.Parse(Request.Cookies["pageSize"].Value);
            //return Content(bNamelike + "---" + proId + "----" + isPaid);
            IQueryable<Bill> bill = Utils.GetBills(bNamelike, proId, isPaid);
            ViewData["totalPage"] = bill.Count();   // 0
            ViewData["pageSize"] = pageSize;     // 5
            ViewData["pageIndex"] = pageIndex;   // 1
            ViewData["bNamelike"] = bNamelike;
            ViewData["proId"] = proId;
            ViewData["isPaid"] = isPaid;
            Session["pageIndex"] = pageIndex;
            Session["toLook"] = "1";
            ViewData["limited"] = int.Parse(Session["level"].ToString()) > 3;
            Response.Cookies["pageSize"].Value = "5";
            List<BillShow> billShows = new List<BillShow>();
            foreach (var item in bill.OrderBy(u => u.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize))
            {
                billShows.Add(new BillShow(item));
            }
            ViewData.Model = billShows;

            return View();
        }

        [HttpPost]
        public ActionResult Index(string bNamelike = "", string proId = "", string isPaid = "")
        {
            return Content(bNamelike + "---" + proId + "----" + isPaid);
        }

        [LimitFilter(3, "../../Index/Index")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Bill bill)
        {
            bill.CreateTime = DateTime.Now;
            string phone = Session["userPhone"].ToString();
            //var user = dbContext.UserInfo.Where(u => u.UPhone == phone).FirstOrDefault();
            var user = userInfoService.GetEntities(u => u.UPhone == phone).FirstOrDefault();
            bill.UserInfoId = user.Id;
            bill.UserInfo = user;
            //dbContext.Bill.Add(bill);
            billService.Add(bill);
            billService.DbSession.SaveChanges<DataModelContainer>();
            //dbContext.SaveChanges();
            return RedirectToAction("Index", new { pageIndex = Session["pageIndex"] });
        }

        public ActionResult Show(int bId, int pageIndex = 1, string bNamelike = "", string proId = "", string isPaid = "")
        {
            //Bill bill = dbContext.Bill.Find(bId);
            Bill bill = billService.GetEntities(b => b.Id == bId).FirstOrDefault();
            BillShow billShow = new BillShow(bill);
            ViewData["pageIndex"] = pageIndex;   // 1
            ViewData["bNamelike"] = bNamelike;
            ViewData["proId"] = proId;
            ViewData["isPaid"] = isPaid;
            //ViewData["uNamelike"] = uNamelike;
            ViewData.Model = billShow;
            return View();
        }

        [LimitFilter(3, "../../Index/Index")]
        public ActionResult Delete(int bId)
        {
            //Bill bill = dbContext.Bill.Find(bId);
            Bill bill = billService.GetEntities(b => b.Id == bId).FirstOrDefault();
            //dbContext.Entry(bill).State = System.Data.Entity.EntityState.Deleted;
            billService.Delete(bill);
            //dbContext.SaveChanges();
            billService.DbSession.SaveChanges<DataModelContainer>();
            return RedirectToAction("Index", new { pageIndex = Session["pageIndex"] });
        }

        [LimitFilter(3, "../Index/Index")]
        public ActionResult Update(int bId)
        {
            //Bill bill = dbContext.Bill.Find(bId);
            Bill bill = billService.GetEntities(b => b.Id == bId).FirstOrDefault();
            ViewData["bId"] = bId;
            ViewData.Model = bill;
            Session["Bill"] = bill;
            return View();
        }

        [HttpPost]
        public ActionResult Update(Bill bill)
        {
            Bill oldBill = Session["Bill"] as Bill;
            Session["Bill"] = null;
            bill.CreateTime = oldBill.CreateTime;
            bill.DelFlag = oldBill.DelFlag;
            bill.UserInfoId = oldBill.UserInfoId;
            billService.Update(bill);
            //dbContext.SaveChanges();
            billService.DbSession.SaveChanges<DataModelContainer>();
            return RedirectToAction("Index", new { pageIndex = Session["pageIndex"] });

        }
    }
}