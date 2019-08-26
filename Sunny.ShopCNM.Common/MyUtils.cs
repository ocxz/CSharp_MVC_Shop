using Newtonsoft.Json;
using Sunny.ShopCNM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.ShopCNM.Common
{
    public static class MyUtils
    {
        /// <summary>
        /// 根据生辰，获取年龄
        /// </summary>
        /// <param name="birthdate">生辰</param>
        /// <returns>年龄</returns>
        public static int GetAgeByBirthdate(DateTime birthdate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthdate.Year;
            if (now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day))
            {
                age--;
            }
            return age < 0 ? 0 : age;
        }

        /// <summary>
        /// 将字典类型序列化为json字符串
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="dict">要序列化的字典数据</param>
        /// <returns>json字符串</returns>
        public static string SerializeDictionaryToJsonString<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            if (dict.Count == 0)
                return "";

            string jsonStr = JsonConvert.SerializeObject(dict);
            return jsonStr;
        }

        /// <summary>
        /// JSON序列化
        /// </summary>
        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        /// <summary>
        /// 根据url参数获得url
        /// </summary>
        /// <param name="url">原始url</param>
        /// <param name="urlParams">url参数</param>
        /// <returns>url</returns>
        public static string GetUrl(string url, object urlParams)
        {
            if (urlParams != null)
            {
                url = url + "?";
                foreach (var prop in urlParams.GetType().GetProperties())
                {
                    if (prop.GetValue(urlParams) != null && !string.IsNullOrEmpty(prop.GetValue(urlParams).ToString().Trim()))
                    {
                        url += prop.Name + "=" + prop.GetValue(urlParams).ToString().Trim() + "&";
                    }
                }
                url = url.Substring(0, url.Length - 1);
            }
            return url;
        }

        public static void UpdateNew<T>(T newObj, T oldObj)
        {
            foreach (var prop in oldObj.GetType().GetProperties())
            {
                if (prop.GetValue(newObj) == null)
                {
                    prop.SetValue(newObj, prop.GetValue(oldObj));
                }
            }
        }
    }
}
