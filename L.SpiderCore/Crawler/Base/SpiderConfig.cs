using System;
using System.Collections.Generic;

namespace L.SpiderCore.Crawler
{
    /// <summary>
    /// 爬虫配置对象
    /// </summary>
    public class SpiderConfig
    {
        /// <summary>
        /// 需要爬取的uri地址集合
        /// </summary>
        public IList<string> Uris { get; set; }

        /// <summary>
        /// 消息通知形式回掉
        /// </summary>
        public Action<string> CallBack { get; set; }

        /// <summary>
        /// 数据处理回掉
        /// </summary>
        public Action<ICrawlerResult> DataHandleCallBack { get; set; }
    }
}