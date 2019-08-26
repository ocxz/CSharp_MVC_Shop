using Sunny.Mvc.ShopCNM.EFDAL;
using Sunny.Mvc.ShopCNM.IDAL;
using Sunny.Mvc.ShopCNM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.Mvc.ShopCNM.DalFactory
{
    public class DbSession : IDbSession
    {
        //public HashSet<IBaseDal<>> DalSet{set;get;}

        public IUserInfoDal UserInfoDal
        {
            get
            {
                return DalFactory.GetDal<UserInfoDal>();
            }
        }
        public IAdminInfoDal AdminInfoDal
        {
            get
            {
                return DalFactory.GetDal<AdminInfoDal>();
            }
        }

        public IProviderDal ProviderDal
        {
            get
            {
                return DalFactory.GetDal<IProviderDal>();
            }
        }

        public IBillDal BillDal
        {
            get
            {
                return DalFactory.GetDal<IBillDal>();
            }
        }

        public IAddressDal AddressDal
        {
            get
            {
                return DalFactory.GetDal<IAddressDal>();
            }
        }



        // 拿到当前上下文，然后进行保存工作，把所有修改整体提交 数据库提交的权力提升到了业务逻辑层
        public int SaveChanges<T>() where T : class, new()
        {
            return DbContextFactory.GetCurrentDbContext<T>().SaveChanges();
        }

    }
}
