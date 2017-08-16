using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace L.SpiderCore
{
    public interface ISpiderCrawler
    {
        /// <summary>
        /// 启动爬虫
        /// </summary>
        void Run();
        /// <summary>
        /// 获取爬取数据结果
        /// </summary>
        DataTable Result { get; }
    }
}
