using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunny.Mvc.ShopCNM.Model;

namespace Sunny.Mvc.ShopCNM.IDAL
{
    public interface IDbSession
    {
        IUserInfoDal UserInfoDal { get; }
        IAdminInfoDal AdminInfoDal { get; }
        IProviderDal ProviderDal { get; }
        IBillDal BillDal { get; }
        IAddressDal AddressDal { get; }

        // 拿到当前上下文，然后进行保存工作，把所有修改整体提交 数据库提交的权力提升到了业务逻辑层
        int SaveChanges<T>() where T : class, new();
    }
}
