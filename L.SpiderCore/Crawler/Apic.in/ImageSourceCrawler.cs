using L.Application.Services;
using L.Domain.Entities;
using L.EntityFramework.Uow;
using L.LCore.Infrastructure.Dependeny;
using L.SpiderCore.Event;
using L.SpiderCore.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace L.SpiderCore.Crawler
{
    [Spider("ApiInImageUrlCrawler")]
    public class ImageSourceCrawler : SpiderCrawler
    {
        private IImageService _imageService = ContainerManager.Resolve<IImageService>();
        private ILoggerService _loggerService = ContainerManager.Resolve<ILoggerService>();
        private static Object _lock = new Object();

        public override void HtmlParser(OnCompleteEventArgs e)
        {
            try
            {
                lock (_lock)
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    IList<Img> imgs = new List<Img>();
                    //初始化解析器
                    var selector = new XPathSelector(e.Page);
                    var aEles = selector.SelectNodes("//*[@id='main']/div/div[1]/a");
                    foreach (var aEle in aEles)
                    {
                        string url = aEle.GetAttributeValue("href", "");
                        imgs.Add(new Img()
                        {
                            Url = url
                        });
                    }
                    _imageService.AddImages(imgs);
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

        public override void InitConfig(SpiderConfig config)
        {
            IList<string> uris = new List<string>();
            //解析url地址
            foreach (var uri in config.Uris)
            {
                if (!string.IsNullOrEmpty(uri))
                {
                    //获取索引
                    int sIndex = uri.IndexOf('{');
                    int eIndex = uri.LastIndexOf('}');
                    var s = uri.Substring(sIndex + 1, eIndex - sIndex - 1);
                    string[] sAnde = s.Split('~');
                    int sValue = Convert.ToInt32(sAnde[0]);
                    int eValue = Convert.ToInt32(sAnde[1]);
                    string urlStartPart = uri.Substring(0, sIndex);
                    for (int i = sValue; i <= eValue; i++)
                    {
                        uris.Add(urlStartPart + i);
                    }
                }
            }
            //
            config.Uris = uris;
            base.InitConfig(config);
        }
    }
}