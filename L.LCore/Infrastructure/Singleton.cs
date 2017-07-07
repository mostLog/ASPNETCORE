using System;
using System.Collections.Generic;
using System.Text;

namespace L.LCore.Infrastructure
{
    /// <summary>
    /// 单例对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T>
    {
        private Singleton()
        {

        }
        public static T Instance { get; set; }
    }
}
