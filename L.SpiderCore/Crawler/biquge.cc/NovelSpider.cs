using L.Application.Dto;
using L.Application.Services;
using L.Domain.Entities;
using L.LCore.Infrastructure.Dependeny;
using L.SpiderCore.Event;
using L.SpiderCore.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace L.SpiderCore.Crawler
{
    [Spider("NovelSpider")]
    public class NovelSpider : SpiderCrawler
    {
        /// <summary>
        /// 日志服务
        /// </summary>
        private ILoggerService _loggerService = ContainerManager.Resolve<ILoggerService>();

        /// <summary>
        /// 小说服务
        /// </summary>
        private INovelService _novelService = ContainerManager.Resolve<INovelService>();

        private static Object _lock = new Object();

        /// <summary>
        ///
        /// </summary>
        public NovelSpider()
        {
        }

        /// <summary>
        /// html解析
        /// </summary>
        /// <param name="e"></param>
        public override void HtmlParser(OnCompleteEventArgs e)
        {
            try
            {
                lock (_lock)
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    var selector = new XPathSelector(e.Page);
                    //小说
                    Novel novel = new Novel();
                    //文章信息
                    novel.Articles = new List<Article>();

                    #region 小说信息

                    var nameEle = selector.SelectSingleNode("//*[@id='info']/h1");
                    if (nameEle != null)
                    {
                        novel.Name = nameEle.InnerText;
                    }
                    var authorEle = selector.SelectSingleNode("//*[@id='info']/p[1]");
                    if (authorEle != null)
                    {
                        string pStr = authorEle.InnerText;
                        novel.Author = pStr.Split('：')[1];
                    }

                    #endregion 小说信息

                    var oldNovel = _novelService.GetSingleNovel(new NovelSearchInput() { Name = novel.Name });
                    if (oldNovel == null)
                    {
                        GetArticles(selector, novel, e.Uri, "//*[@id='list']/dl/dd/a");
                        if (novel.Articles.Count > 0)
                        {
                            //设为已爬取
                            novel.IsCrawlerArticle = true;
                        }
                        //添加小说
                        _novelService.AddNovel(novel);
                    }
                    else
                    {
                        var laestArticle = _novelService.GetLaestArticle();
                        oldNovel.Articles = new List<Article>();
                        //获取最新章节
                        GetArticles(selector, oldNovel, e.Uri, "//*[@id='list']/dl/dd/a[number(translate(@href,'.html',''))>" + laestArticle.Seq + "]");
                        //更新新章节
                        _novelService.AddArticles(oldNovel.Articles.ToList());
                    }
                    stopWatch.Stop();
                    //记录爬取日志
                    _loggerService.WriteLog(new Log()
                    {
                        DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Msg = e.Uri + "请求消耗:" + e.Duration + "---" + "数据解析消耗:" + stopWatch.ElapsedMilliseconds,
                        ClassName = "",
                        ActionName = "",
                        Duration = e.Duration + stopWatch.ElapsedMilliseconds,
                        LogLevel = (int)LCore.Logger.LogLevel.Info
                    });
                }
            }
            catch (Exception exception)
            {
                //记录错误信息
                _loggerService.WriteLog(new Log()
                {
                    DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    LogLevel = (int)LCore.Logger.LogLevel.Error,
                    ClassName = this.GetType().Name,
                    ActionName = exception.TargetSite.Name,
                    Msg = e.Uri + "---" + exception.Message
                });
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="novel"></param>
        /// <param name="uri"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        private void GetArticles(XPathSelector selector, Novel novel, string uri, string xpath)
        {
            var aEles = selector.SelectNodes(xpath);
            if (aEles != null)
            {
                foreach (var ele in aEles)
                {
                    string articleUri = uri + ele.GetAttributeValue("href", "");
                    string[] s = articleUri.Split('/');
                    string uN = s[s.Length - 1];
                    long htmlFileName = long.Parse(uN.Substring(0, uN.IndexOf('.')));
                    string articleTitle = ele.InnerText;
                    var article = new Article()
                    {
                        Title = articleTitle,
                        Url = articleUri,
                        Novel = novel,
                        Seq = htmlFileName
                    };
                    //回调
                    Config.CallBack?.Invoke(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "--文章标题：" + articleTitle + " 文章地址：" + articleUri);
                    novel.Articles.Add(article);
                }
            }
        }
    }
}