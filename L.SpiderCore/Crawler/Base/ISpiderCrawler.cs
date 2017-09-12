namespace L.SpiderCore.Crawler
{
    public interface ISpiderCrawler
    {
        /// <summary>
        /// 初始化爬虫信息
        /// </summary>
        void InitConfig(SpiderConfig config);

        /// <summary>
        /// 启动爬虫
        /// </summary>
        void Run();
    }
}