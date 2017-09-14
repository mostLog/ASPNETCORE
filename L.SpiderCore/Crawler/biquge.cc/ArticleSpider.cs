using L.Application.Services;
using L.Domain.Entities;
using L.LCore.Email;
using L.LCore.Infrastructure.Dependeny;
using L.SpiderCore.Event;
using L.SpiderCore.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace L.SpiderCore.Crawler
{
    [Spider("ArticleSpider")]
    public class ArticleSpider : SpiderCrawlerOfData<Article>
    {
        private INovelService _novelService= ContainerManager.Resolve<INovelService>();
        private ILoggerService _loggerService= ContainerManager.Resolve<ILoggerService>();
        private static Object _lock = new Object();

        public ArticleSpider()
        {
        }

        public override void HtmlParser(OnCompleteEventArgs e)
        {
            lock (_lock)
            {
                try
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    var article = Current;
                    var selector = new XPathSelector(e.Page);
                    var node = selector.SelectSingleNode("//*[@id='content']");
                    //获取小说内容
                    string content = node.InnerHtml;
                    article.Content = content;
                    article.IsCrawlerContent = true;
                    //更新信息
                    _novelService.UpdateArticel(article);
                    //是否启动邮件发送
                    if (article.Novel != null && article.Novel.IsOpenEmail)
                    {
                        //发送邮件
                        EmailHelper.SendEmail(article.Title, content, new List<string>() { "2434934089@qq.com" });
                    }
                    stopWatch.Stop();
                    //记录爬取日志
                    _loggerService.WriteLog(new Log()
                    {
                        DateTime = DateTime.Now,
                        Msg = e.Uri + "请求消耗:" + e.Duration + "---" + "数据解析消耗:" + stopWatch.ElapsedMilliseconds,
                        ClassName = "",
                        ActionName ="",
                        Duration = e.Duration + stopWatch.ElapsedMilliseconds,
                        LogLevel = (int)LCore.Logger.LogLevel.Info
                    });
                }
                catch (Exception exception)
                {
                    //记录错误信息
                    _loggerService.WriteLog(new Log()
                    {
                        DateTime= DateTime.Now,
                        LogLevel = (int)LCore.Logger.LogLevel.Error,
                        ClassName = this.GetType().Name,
                        ActionName = exception.TargetSite.Name,
                        Msg =e.Uri+"---"+exception.Message
                    });
                }
            }
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="config"></param>
        public override void InitConfig(SpiderConfig config)
        {
            //初始化数据
            Datas = _novelService.GetArticles(
                new Application.Dto.ArticleSearchInput()
                {
                    IsCrawlerContent = false,
                    RowCount = 10
                }).Select(m =>
                {
                    return new KeyValuePair<string, Article>(m.Url, m);
                }).ToList();
            base.InitConfig(config);
        }
    }
}