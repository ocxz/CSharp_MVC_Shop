using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunny.ShopCNM.Models.models
{
    public class BillShow
    {
        public int Id { get; set; }
        public string Bid { get; set; }
        public string BName { get; set; }
        public string ProductUnit { get; set; }
        public string ProviderName { get; set; }
        public string ProductCount { get; set; }
        public decimal TotalMoney { get; set; }
        public string IsPaid { get; set; }
        public string CreateTime { get; set; }
        public string LinkMan { get; set; }

        public BillShow()
        {

        }
        public BillShow(Bill bill)
        {
            this.Id = bill.Id;
            this.Bid = "BILL-CODE-"+bill.Id;
            this.BName = bill.BName;
            this.ProductUnit = bill.ProductUnit;
            this.ProductCount = bill.ProductCount == null ? "未详" : bill.ProductCount.ToString();
            this.TotalMoney = bill.TotalMoney;
            this.IsPaid = bill.IsPaid ? "已支付" : "未支付";
            this.CreateTime = bill.CreateTime == null ? "无" : ((DateTime)bill.CreateTime).ToString("yyyy-MM-dd");
            this.LinkMan = bill.UserInfo.UName;
            this.ProviderName = bill.Provider.PName;
        }
    }
}