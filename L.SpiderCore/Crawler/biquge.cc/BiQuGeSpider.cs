﻿using L.Application.Services;
using L.Domain.Entities;
using L.LCore.Infrastructure.Dependeny;
using L.SpiderCore.Event;
using L.SpiderCore.Tools;
using System;
using System.Collections.Generic;

namespace L.SpiderCore.Crawler
{
    [Spider("BiQuGe", "biquge.cc全站爬取")]
    public class BiQuGeSpider : SpiderCrawler
    {
        private ILoggerService _loggerService = ContainerManager.Resolve<ILoggerService>();
        private static Object _lock = new Object();

        public override void HtmlParser(OnCompleteEventArgs e)
        {
            try
            {
                lock (_lock)
                {
                    //解析器
                    var selector = new XPathSelector(e.Page);
                    //最热小说
                    var dtHotNovels = selector.SelectNodes("//*[@id='hotcontent']/div/div/div[1]/a");
                    //最近更新
                    var latestNovels = selector.SelectNodes("//*[@id='newscontent']/div[1]/ul/li/span[2]/a");
                    //点击榜
                    var mostClickNovels = selector.SelectNodes("//*[@id='newscontent']/div[2]/ul/li/span[2]/a");
                    IList<string> urls = new List<string>();
                    foreach (var aEle in dtHotNovels)
                    {
                        urls.Add("http://" + e.Host + aEle.GetAttributeValue("href", ""));
                    }
                    foreach (var aEle in latestNovels)
                    {
                        urls.Add("http://" + e.Host + aEle.GetAttributeValue("href", ""));
                    }
                    foreach (var aEle in mostClickNovels)
                    {
                        urls.Add("http://" + e.Host + aEle.GetAttributeValue("href", ""));
                    }
                    var spiderManager = ContainerManager.Resolve<SpiderManager>();
                    //启动小说爬虫
                    spiderManager.RunTask("NovelSpider", new SpiderConfig()
                    {
                        Uris = urls
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
                    ClassName = this.GetType().FullName,
                    ActionName = exception.TargetSite.Name,
                    Msg = e.Uri + "---" + exception.StackTrace
                });
            }
        }
    }
}