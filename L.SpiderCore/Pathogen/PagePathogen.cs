using System;
using System.Collections.Generic;
using System.Text;

namespace L.Pathogen
{
    /// <summary>
    /// 
    /// </summary>
    public class PagePathogen
    {
        /// <summary>
        /// 页面代码
        /// </summary>
        public string PageSource { get; set; }
        /// <summary>
        /// 爬取地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 花费时间
        /// </summary>
        public long Duration { get; set; }

        /// <summary>
        /// 域名
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IDictionary<string, object> ResultList { get; } = new Dictionary<string,object>();

        /// <summary>
        /// 添加页面解析结果
        /// </summary>
        public void AddResult(string key,object value)
        {
            ResultList.Add(key,value);
        }
    }
}
