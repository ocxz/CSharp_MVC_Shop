using Sunny.Mvc.ShopCNM.EFDAL;
using Sunny.Mvc.ShopCNM.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.Mvc.ShopCNM.DalFactory
{
    public static class StaticDalFactory
    {

        public static IUserInfoDal GetUserInfoDal()
        {
            return new UserInfoDal();
        }
    }
}
