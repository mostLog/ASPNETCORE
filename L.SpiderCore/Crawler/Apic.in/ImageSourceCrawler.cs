using L.Application.Services;
using L.Domain.Entities;
using L.EntityFramework.Uow;
using L.LCore.Infrastructure.Dependeny;
using L.SpiderCore.Event;
using L.SpiderCore.Tools;
using System;
using System.Collections.Generic;

namespace L.SpiderCore.Crawler
{
    [Spider("ApiInImageUrlCrawler")]
    public class ImageSourceCrawler : SpiderCrawler
    {
        public override void HtmlParser(OnCompleteEventArgs e)
        {
            //获取服务
            var appService = ContainerManager.Resolve<IImageService>();
            //初始化解析器
            var selector = new XPathSelector(e.Page);
            var aEles = selector.SelectNodes("//*[@id='main']/div/div[1]/a");
            //开启工作单元
            var unitOfWork = ContainerManager.Resolve<IUnitOfWork>();
            unitOfWork.Begin(new UnitOfWorkOptions());
            foreach (var aEle in aEles)
            {
                string url = aEle.GetAttributeValue("href", "");
                appService.AddImage(new Img()
                {
                    Url = url
                });
            }
            unitOfWork.Complete();
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