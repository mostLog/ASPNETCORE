using L.Application.Services;
using L.Domain.Entities;
using L.EntityFramework.Uow;
using L.LCore.Infrastructure.Dependeny;
using L.SpiderCore.Crawler.Common;
using L.SpiderCore.Event;
using L.SpiderCore.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace L.SpiderCore.Crawler
{
    [Spider("ImageUrlCrawler")]
    public class ImageUrlCrawler : SpiderCrawlerOfData<Img>
    {
        private IImageService _imageService= ContainerManager.Resolve<IImageService>();
        private ILoggerService _loggerService = ContainerManager.Resolve<ILoggerService>();
        private static Object _lock = new Object();

        public override void HtmlParser(OnCompleteEventArgs e)
        {
            try
            {
                //线程锁
                lock (_lock)
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    var img = Current;
                    var selector = new XPathSelector(e.Page);
                    var imgEles = selector.SelectNodes("//*[@id='post']/div[3]/p/img");
                    if (imgEles == null)
                    {
                        imgEles = selector.SelectNodes("//*[@id='post']/div[3]/p/a/img");
                        if (imgEles == null)
                        {
                            imgEles = selector.SelectNodes("//*[@id='post']/div[3]/p/strong/a/img");
                        }
                        if (imgEles == null)
                        {
                            System.Diagnostics.Debug.Write(e.Uri);
                        }
                    }
                    if (imgEles != null)
                    {
                        var unitOfWork = ContainerManager.Resolve<IUnitOfWork>();
                        //开启工作单元
                        unitOfWork.Begin(new UnitOfWorkOptions());
                        foreach (var imgEle in imgEles)
                        {
                            string src = imgEle.GetAttributeValue("src", "");
                            if (!string.IsNullOrEmpty(src))
                            {
                                //保存图片
                                var imageBaseInfo = ImgHelper.GetImageAndSave(src, @"C:\Temp\ApiInImages\");
                                string fileName = Path.GetFileName(src);
                                if (fileName.Contains("!"))
                                {
                                    fileName = fileName.Substring(0, fileName.IndexOf("!"));
                                }
                                _imageService.AddImageInfo(
                                    new ImageInfo()
                                    {
                                        Img = img,
                                        Url = src,
                                        SourceUrl = e.Uri,
                                        Name = fileName,
                                        Width = imageBaseInfo.Width,
                                        Height = imageBaseInfo.Height
                                    }
                                );
                            }
                        }
                        img.IsCrawlerImgInfo = true;
                        _imageService.UpdateImage(img);
                        unitOfWork.Complete();
                    }
                    stopWatch.Stop();
                    //记录爬取日志
                    _loggerService.WriteLog(new Log()
                    {
                        DateTime = DateTime.Now,
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
                    DateTime = DateTime.Now,
                    LogLevel = (int)LCore.Logger.LogLevel.Error,
                    ClassName = this.GetType().Name,
                    ActionName = exception.TargetSite.Name,
                    Msg = e.Uri + "---" + exception.Message
                });
            }
        }

        public override void InitConfig(SpiderConfig config)
        {
            var sourceImgs = _imageService.GetSourceImgs(
                new Application.Dto.ImageSearchInput()
                {
                    RowCount = 2,
                    IsCrawlerImgInfo =false
                }).Result;
            IList<KeyValuePair<string, Img>> l = new List<KeyValuePair<string, Img>>();
            foreach (var img in sourceImgs)
            {
                for (int i = 1; i < 11; i++)
                {
                    if (i==1)
                    {
                        l.Add(new KeyValuePair<string, Img>(img.Url, img));
                    }
                    else
                    {
                        l.Add(new KeyValuePair<string, Img>(img.Url + "/" + i, img));
                    }
                }
            }
            base.Datas = l;
            base.InitConfig(config);
        }
    }
}