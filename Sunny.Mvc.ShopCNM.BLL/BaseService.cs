using Sunny.Mvc.ShopCNM.DalFactory;
using Sunny.Mvc.ShopCNM.IDAL;
using Sunny.Mvc.ShopCNM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.Mvc.ShopCNM.BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IBaseDal<T> CurrentDal { set; get; }
        public IDbSession DbSession
        {
            get
            {
                return DalFactory.DbSessionFactory.GetCurrentDbSession();
            }
        }

        public abstract void SetCurrentDal();

        public BaseService()
        {
            SetCurrentDal();
        }

        #region 查询

        /// <summary>
        /// 条件查询，传入参数为泛型T返回值为Bool类型的Lambda表达式
        /// </summary>
        /// <param name="whereLambda">参数为泛型T返回值为Bool类型的Lambda表达式</param>
        /// <returns>条件查询出来的泛型T的对象数据</returns>
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.GetEntities(whereLambda);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">分页查询，排序的类型</typeparam>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="total">out 页总数</param>
        /// <param name="whereLambda">筛选的lambda表达式 参数是T类型 返回值是bool类型</param>
        /// <param name="orderByLambda">排序的lambda表达式 参数是T类型 返回值是函数泛型</param>
        /// <param name="isAsc">是否升序排序，默认为true</param>
        /// <returns>查询结果</returns>
        public IQueryable<T> GetPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc = true)
        {
            return CurrentDal.GetPageEntities<S>(pageIndex, pageSize, out total, whereLambda, orderByLambda, isAsc);
        }

        #endregion

        #region cud 增删改
        /// <summary>
        /// 返回UserInfo，在插入成功后，若UserInfo有自增字段(如Id)数据库会自动将UserInfo填充返回
        /// </summary>
        /// <param name="userInfo">要插入的userInfo</param>
        /// <returns>填充好的userInfo</returns>
        public T Add(T entity)
        {
            CurrentDal.Add(entity);
            DbSession.SaveChanges<DataModelContainer>();
            return entity;
        }

        // 改
        public bool Update(T entity)
        {
            CurrentDal.Update(entity);
            DbSession.SaveChanges<DataModelContainer>();
            return true;
        }

        public bool Delete(T entity)
        {
            CurrentDal.Delete(entity);
            DbSession.SaveChanges<DataModelContainer>();
            return true;
        }

        #endregion
    }
}
