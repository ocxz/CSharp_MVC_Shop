using Sunny.Mvc.ShopCNM.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.Mvc.ShopCNM.DalFactory
{
    public static class DalFactory
    {
        // 从配置文件中获得DAL的程序集名  如：EFDAL
        private static string assemblyName = ConfigurationManager.AppSettings["assemblyName"];
        //private static string assemblyName = "Sunny.OA.EFDAL";

        // 根据程序集名，获得程序集  如：获取EFDAL的程序集
        private static Assembly ass = Assembly.Load(assemblyName);

        public static IUserInfoDal GetUserInfoDal()
        {
            // 获取程序集所有的公共类的类型
            foreach (Type userInfoType in ass.GetExportedTypes())
            {
                // 如果类型继承了IUserInfoDal 就根据改类型调用默认构造器生成DAL对象返回
                if (typeof(IUserInfoDal).IsAssignableFrom(userInfoType))
                {
                    return ass.CreateInstance(userInfoType.FullName) as IUserInfoDal;
                }
            }
            return null;
        }

        public static T GetDal<T>() where T : class
        {
            // 获取程序集所有的公共类的类型
            foreach (Type dalType in ass.GetExportedTypes())
            {
                // 如果类型继承了T 就根据改类型调用默认构造器生成DAL对象返回
                if (typeof(T).IsAssignableFrom(dalType))
                {
                    return ass.CreateInstance(dalType.FullName) as T;
                }
            }
            return null;
        }
    }
}
