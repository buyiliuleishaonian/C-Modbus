using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ConfigLib
{
    public class JsonHelper
    {
        /// <summary>
        /// 使用Newtonsoft.json.dll对象序列化成Json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string EntityToJson<T>(T t)
        {
            try
            {
                return JsonConvert.SerializeObject(t, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 使用Newtonsoft.json.dll 将Json字符串反序列化成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToEntity<T>(string json)
        {
            try
            {
                return (T)JsonConvert.DeserializeObject(json, typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }

    }
}
