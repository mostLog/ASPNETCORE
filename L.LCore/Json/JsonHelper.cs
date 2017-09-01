using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace L.LCore.Json
{
    public class JsonHelper
    {
        /// <summary>
        /// 序列号为json字符串
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToJson(object val)
        {
            if (val==null)
            {
                throw new ArgumentException(nameof(val));
            }
            return JsonConvert.SerializeObject(val);
        }
        /// <summary>
        /// 反序列号为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        public static T ToObject<T>(string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                throw new ArgumentException(nameof(val));
            }
            return JsonConvert.DeserializeObject<T>(val);
        }
    }
}
