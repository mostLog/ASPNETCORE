using L.Application.Services;
using L.Domain.Entities;
using L.LCore.Infrastructure.Dependeny;
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
        private IImageService _imageService = ContainerManager.Resolve<IImageService>();
        private ILoggerService _loggerService = ContainerManager.Resolve<ILoggerService>();
        private static Object _lock = new Object();

        public override void HtmlParser(OnCompleteEventArgs e)
        {
            //线程锁
            lock (_lock)
            {
                try
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
                            Debug.Write(e.Uri);
                        }
                    }
                    if (imgEles != null)
                    {
                        IList<ImageInfo> imageInfos = new List<ImageInfo>();
                        foreach (var imgEle in imgEles)
                        {
                            string src = imgEle.GetAttributeValue("src", "");
                            if (!string.IsNullOrEmpty(src))
                            {
                                //路径
                                //string savePath = @"C:\Temp\ApiInImages\"+DateTime.Now.ToString("yyyy-MM-dd")+@"\";
                                //if (!Directory.Exists(savePath))
                                //{
                                //    Directory.CreateDirectory(savePath);
                                //}
                                ////保存图片
                                //var imageBaseInfo = ImgHelper.GetImageAndSave(src, savePath);
                                string fileName = Path.GetFileName(src);
                                if (fileName.Contains("!"))
                                {
                                    fileName = fileName.Substring(0, fileName.IndexOf("!"));
                                }
                                imageInfos.Add(
                                    new ImageInfo()
                                    {
                                        Img = img,
                                        Url = src,
                                        SourceUrl = e.Uri,
                                        Name = fileName
                                    }
                                );
                            }
                        }
                        img.IsCrawlerImgInfo = true;
                        _imageService.AddImageInfos(imageInfos, img);
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
        }

        public override void InitConfig(SpiderConfig config)
        {
            var sourceImgs = _imageService.GetSourceImgs(
                new Application.Dto.ImageSearchInput()
                {
                    RowCount = 2,
                    IsCrawlerImgInfo = false
                }).Result;
            IList<KeyValuePair<string, Img>> l = new List<KeyValuePair<string, Img>>();
            foreach (var img in sourceImgs)
            {
                for (int i = 1; i < 11; i++)
                {
                    if (i == 1)
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