using Sunny.Mvc.ShopCNM.BLL;
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
    public class ProviderController : Controller
    {
        DataModelContainer t = new DataModelContainer();
        ProviderService providerService = new ProviderService();
        AddressService addressService = new AddressService();

        // GET: Provider
        public ActionResult Index(int pageIndex = 1, string pNamelike = "")
        {
            int pageSize = Request.Cookies["pageSize"] == null ? 5 : int.Parse(Request.Cookies["pageSize"].Value);
            IQueryable<Provider> provider;
            // 如果没有名字查询
            if (string.IsNullOrEmpty(pNamelike.Trim()))
            {
                //provider = dbContext.Provider;
                provider = providerService.GetEntities(p => true);
                pNamelike = "";
            }
            else
            {
                //provider = dbContext.Provider.Where(p => p.PName.Contains(pNamelike));
                provider = providerService.GetEntities(p => p.PName.Contains(pNamelike));
            }
            ViewData["totalPage"] = provider.Count(); ;
            ViewData["pageSize"] = pageSize;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pNamelike"] = pNamelike;
            Session["pageIndex"] = pageIndex;
            Session["toLook"] = "2";
            ViewData["limited"] = int.Parse(Session["level"].ToString()) > 2;
            Response.Cookies["pageSize"].Value = "5";
            List<ProviderShow> providerShows = new List<ProviderShow>();
            foreach (var item in provider.OrderBy(p => p.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize))
            {
                providerShows.Add(new ProviderShow(item));
            }
            ViewData.Model = providerShows;

            return View();
        }

        [LimitFilter(2, "../Index/Index")]
        public ActionResult Add()
        {
            //ViewData.Model = dbContext.Address.Where(a => a.Pid == "100000").ToList();
            ViewData.Model = addressService.GetEntities(a => a.Pid == "100000").ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Provider provider, string UCounty)
        {
            provider.CreateTime = DateTime.Now;
            provider.AddressId = addressService.GetEntities(a => a.Aid == UCounty).FirstOrDefault().Id;
            providerService.Add(provider);
            providerService.DbSession.SaveChanges<DataModelContainer>();
            return RedirectToAction("Index", new { pageIndex = Session["pageIndex"] });
        }

        public ActionResult Show(int proId, string pNamelike = "")
        {
            //Provider provider = dbContext.Provider.Find(proId);
            Provider provider = providerService.GetEntities(p => p.Id == proId).FirstOrDefault();
            ProviderShow providerShow = new ProviderShow(provider);
            ViewData["CreateTime"] = provider.CreateTime == null ? "暂无" : ((DateTime)provider.CreateTime)
                .ToString("yyyy年MM月dd日");
            ViewData["pNamelike"] = pNamelike;
            ViewData.Model = providerShow;
            return View();
        }

        [LimitFilter(2, "../Index/Index")]
        public ActionResult Delete(int proId)
        {
            //Provider provider = dbContext.Provider.Find(proId);
            Provider provider = providerService.GetEntities(p => p.Id == proId).FirstOrDefault();
            //dbContext.Entry(provider).State = System.Data.Entity.EntityState.Deleted;
            providerService.Delete(provider);
            //dbContext.SaveChanges();
            providerService.DbSession.SaveChanges<DataModelContainer>();
            return RedirectToAction("Index", new { pageIndex = Session["pageIndex"] });
        }

        [LimitFilter(2, "../Index/Index")]
        public ActionResult Update(int proId)
        {
            //Provider provider = dbContext.Provider.Find(proId);
            Provider provider = providerService.GetEntities(p => p.Id == proId).FirstOrDefault();
            //var City = dbContext.Address.Where(a => a.Aid == provider.Address.Pid).FirstOrDefault();
            var City = addressService.GetEntities(a => a.Aid == provider.Address.Pid).FirstOrDefault();
            //var Pro = dbContext.Address.Where(a => a.Aid == City.Pid).FirstOrDefault();
            var Pro = addressService.GetEntities(a => a.Aid == City.Pid).FirstOrDefault();
            ViewData["proId"] = proId;
            ViewData["City"] = City;
            ViewData["Pro"] = Pro;
            ViewData.Model = provider;
            return View();
        }

        [HttpPost]
        public ActionResult Update(Provider provider, string UCounty)
        {
            //provider.AddressId = dbContext.Address.Where(a => a.Aid == UCounty).FirstOrDefault().Id;
            provider.AddressId = addressService.GetEntities(a => a.Aid == UCounty).FirstOrDefault().Id;
            //dbContext.Entry(provider).State = System.Data.Entity.EntityState.Modified;
            providerService.Update(provider);
            //dbContext.SaveChanges();
            providerService.DbSession.SaveChanges<DataModelContainer>();
            return RedirectToAction("Index", new { pageIndex = Session["pageIndex"] });
        }
    }
}