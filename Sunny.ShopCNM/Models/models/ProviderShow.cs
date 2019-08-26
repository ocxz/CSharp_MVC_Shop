using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunny.ShopCNM.Models.models
{
    public class ProviderShow
    {
        public int Id { get; set; }
        public string Pid { set; get; }
        public string PName { get; set; }
        public string LinkMan { get; set; }
        public string LinkPhone { get; set; }
        public string Fax { get; set; }
        public string CreateTime { get; set; }
        public string Detail { get; set; }
        public string PAddress { set; get; }

        public ProviderShow()
        {

        }

        public ProviderShow(Provider provider)
        {
            this.Id = provider.Id;
            this.Pid = "PRO-CODE-" + provider.Id;
            this.PName = provider.PName;
            this.LinkMan = provider.LinkMan;
            this.LinkPhone = provider.LinkPhone;
            this.Fax = provider.Fax;
            this.CreateTime = provider.CreateTime == null ? "" : ((DateTime)provider.CreateTime).ToString("yyyy-MM-dd");
            this.Detail = string.IsNullOrWhiteSpace(provider.Detial) ? "暂无" : provider.Detial;
            this.PAddress = provider.Address.Memame + "，" + provider.LinkAddress;
        }


    }
}