using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.Mvc.ShopCNM.IBLL
{
    public interface IBaseService<T> where T : class, new()
    {
        #region 查询

        /// <summary>
        /// 条件查询，传入参数为泛型T返回值为Bool类型的Lambda表达式
        /// </summary>
        /// <param name="whereLambda">参数为泛型T返回值为Bool类型的Lambda表达式</param>
        /// <returns>条件查询出来的泛型T的对象数据</returns>
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

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
        IQueryable<T> GetPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc = true);

        #endregion

        #region cud 增删改
        /// <summary>
        /// 返回UserInfo，在插入成功后，若UserInfo有自增字段(如Id)数据库会自动将UserInfo填充返回
        /// </summary>
        /// <param name="userInfo">要插入的userInfo</param>
        /// <returns>填充好的userInfo</returns>
        T Add(T entity);

        // 改
        bool Update(T entity);

        bool Delete(T entity);

        #endregion
    }
}
