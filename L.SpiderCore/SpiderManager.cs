using L.Application.Services;
using L.LCore.Infrastructure.Dependeny;
using L.LCore.Infrastructure.Reflection;
using L.SpiderCore.Crawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace L.SpiderCore
{
    /// <summary>
    /// 统一管理Spider
    /// </summary>
    public class SpiderManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SpiderManager()
        {
            Init();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            //判断当前使用的数据库中是否存在爬虫表

        }
        /// <summary>
        /// 获取所有爬虫信息
        /// </summary>
        public IList<Type> GetCrawlers()
        {
            var att = typeof(SpiderAttribute);
            var typeFinder = new AssemblyTypeFinder();
            var crawlers=typeFinder.FindTypesByInterface<ISpiderCrawler>();
            return crawlers.Where(c => c.GetCustomAttribute(att) != null).ToList();
        }

        /// <summary>
        /// 通过id获取爬虫
        /// </summary>
        /// <param name="crawlerId"></param>
        /// <returns></returns>
        public Type GetSpiderCrawler(string crawlerId)
        {
            var att = typeof(SpiderAttribute);
            var list=GetCrawlers();
            return list.FirstOrDefault(c=>((SpiderAttribute)c.GetTypeInfo().GetCustomAttribute(att)).Id==crawlerId);
        }
        /// <summary>
        /// 启动爬虫
        /// </summary>
        /// <param name="crawlerId">爬虫id</param>
        /// <param name="appService">数据服务对象</param>
        /// <param name="callback">回调函数</param>
        public void RunTask(string crawlerId, SpiderConfig config)
        {
            var crawler = GetSpiderCrawler(crawlerId);
            var spiderCrawler=(ISpiderCrawler)Activator.CreateInstance(crawler);
            spiderCrawler.InitConfig(config);
            spiderCrawler.Run();
        }
        /// <summary>
        /// 创建爬虫表
        /// </summary>
        private void CreateSpiderTaskTable()
        {

        }

    }
}
