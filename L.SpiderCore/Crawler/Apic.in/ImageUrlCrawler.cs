using L.Application.Services;
using L.Domain.Entities;
using L.EntityFramework.Uow;
using L.LCore.Infrastructure.Dependeny;
using L.SpiderCore.Event;
using L.SpiderCore.Tools;
using System.Collections.Generic;
using System.Linq;

namespace L.SpiderCore.Crawler
{
    [Spider("ImageUrlCrawler")]
    public class ImageUrlCrawler : SpiderCrawlerOfData<Img>
    {
        private IImageService _imageService;

        public override void HtmlParser(OnCompleteEventArgs e)
        {
            var img = Current;
            var selector = new XPathSelector(e.Page);
            var imgEles = selector.SelectNodes("//*[@id='post']/div[3]/p/img");
            var unitOfWork = ContainerManager.Resolve<IUnitOfWork>();
            //开启工作单元
            unitOfWork.Begin(new UnitOfWorkOptions());
            foreach (var imgEle in imgEles)
            {
                string src = imgEle.GetAttributeValue("src", "");
                if (!string.IsNullOrEmpty(src))
                {
                    _imageService.AddImageInfo(
                        new ImageInfo()
                        {
                            Img = img,
                            Url = src
                        }
                        );
                }
            }
            unitOfWork.Complete();
        }

        public override void InitConfig(SpiderConfig config)
        {
            //数据服务
            _imageService = ContainerManager.Resolve<IImageService>();
            var sourceImgs = _imageService.GetSourceImgs(new Application.Dto.ImageSearchInput() { RowCount = 10 }).Result;
            base.Datas = sourceImgs.Select(m =>
            {
                return new KeyValuePair<string, Img>(m.Url, m);
            }).ToList();
            base.InitConfig(config);
        }
    }
}