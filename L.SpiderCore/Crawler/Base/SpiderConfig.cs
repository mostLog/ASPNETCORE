using L.Application.Services;
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
        /// 消息通知形式
        /// </summary>
        public Action<string> CallBack { get; set; }
        /// <summary>
        /// 数据服务提供对象
        /// </summary>
        public IAppService AppService { get; set; }
        /// <summary>
        /// 额外信息
        /// </summary>
        public object ExtraObject { get; set; }
    }
}
