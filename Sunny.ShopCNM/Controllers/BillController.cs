using Sunny.ShopCNM.Models;
using Sunny.ShopCNM.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.ShopCNM.Controllers
{
    public class BillController : Controller
    {
        DataModelContainer dbContext = new DataModelContainer();
        // GET: Bill
        public ActionResult Index(int pageIndex = 1, string bNamelike = "", string proId = "", string isPaid = "")
        {
            int pageSize = Request.Cookies["pageSize"] == null ? 5 : int.Parse(Request.Cookies["pageSize"].Value);
            //return Content(bNamelike + "---" + proId + "----" + isPaid);
            IQueryable<Bill> bill = MyUtils.GetBills(bNamelike, proId, isPaid);
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
            var user = dbContext.UserInfo.Where(u => u.UPhone == phone).FirstOrDefault();
            bill.UserInfoId = user.Id;
            bill.UserInfo = user;
            dbContext.Bill.Add(bill);
            dbContext.SaveChanges();
            return RedirectToAction("Index", new { pageIndex = Session["pageIndex"] });
        }

        public ActionResult Show(int bId, int pageIndex = 1, string bNamelike = "", string proId = "", string isPaid = "")
        {
            Bill bill = dbContext.Bill.Find(bId);
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
            Bill bill = dbContext.Bill.Find(bId);
            dbContext.Entry(bill).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
            return RedirectToAction("Index", new { pageIndex = Session["pageIndex"] });
        }

        [LimitFilter(3, "../Index/Index")]
        public ActionResult Update(int bId)
        {
            Bill bill = dbContext.Bill.Find(bId);
            ViewData["bId"] = bId;
            ViewData.Model = bill;
            Session["Bill"] = dbContext.Bill.Find(bId);
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
            dbContext.Entry(bill).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index", new { pageIndex = Session["pageIndex"] });

        }
    }
}