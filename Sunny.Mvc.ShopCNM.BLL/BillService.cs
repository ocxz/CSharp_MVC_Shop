using Sunny.Mvc.ShopCNM.IBLL;
using Sunny.Mvc.ShopCNM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.Mvc.ShopCNM.BLL
{
    public class BillService : BaseService<Bill>, IBillService
    {
        public override void SetCurrentDal()
        {
            this.CurrentDal = DbSession.BillDal;
        }
    }
}
