using Sunny.Mvc.ShopCNM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunny.Mvc.ShopCNM.UI.Models.Util
{
    public static class Utils
    {
        private static DataModelContainer dbContext = new DataModelContainer();

        public static IQueryable<Bill> GetBills(string bNameLike, object proId, object isPaid)
        {
            DataModelContainer dbContext = new DataModelContainer();
            IQueryable<Bill> bills = dbContext.Bill;
            int pid;
            bool ispaid;
            if (bNameLike != null)
            {
                bills = bills.Where(b => b.BName.Contains(bNameLike));
            }

            if (int.TryParse(proId.ToString(),out pid))
            {
                bills = bills.Where(b => b.ProviderId == pid);
            }

            if (bool.TryParse(isPaid.ToString(), out ispaid))
            {
                bills = bills.Where(b => b.IsPaid == ispaid);
            }

            return bills;
        }
    }
}