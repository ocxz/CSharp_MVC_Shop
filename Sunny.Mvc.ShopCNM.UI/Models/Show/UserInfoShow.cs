using Sunny.Mvc.ShopCNM.Common;
using Sunny.Mvc.ShopCNM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunny.Mvc.ShopCNM.UI.Models.Show
{
    public class UserInfoShow
    {
        public int Id { set; get; }
        public string Uid { set; get; }
        public string UName { get; set; }
        public string UGender { get; set; }
        public int UAge { get; set; }
        public string UPhone { get; set; }
        public string UCategory { get; set; }
        public string UAddress { set; get; }

        public UserInfoShow()
        {

        }

        public UserInfoShow(UserInfo userInfo)
        {
            this.Id = userInfo.Id;
            this.Uid = "USER-CODE-" + userInfo.Id;
            this.UName = userInfo.UName;
            this.UGender = (bool)userInfo.UGender ? "男" : "女";
            this.UAge = userInfo.UBirthday == null ? 0 : MyUtils.GetAgeByBirthdate((DateTime)userInfo.UBirthday); ;
            this.UPhone = userInfo.UPhone;
            this.UCategory = userInfo.UCategory == 1 ? "管理员" : userInfo.UCategory == 2 ? "经理" : "普通用户";
            this.UAddress = userInfo.Address.Memame + "，" + userInfo.AddressDetial;
        }
    }
}