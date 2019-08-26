using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.Mvc.ShopCNM.EFDAL
{
    public class DbContextFactory
    {
        // 一次请求共用一个实例
        public static DbContext GetCurrentDbContext<T>() where T : class, new()
        {
            DbContext db = CallContext.GetData("dbContext") as DbContext;
            if (db == null)
            {
                db = new T() as DbContext;
                CallContext.SetData("dbContext", db);
            }
            return db;
        }
    }
}
