using System;
using System.Collections.Generic;
using System.Text;
using L.SpiderCore.Event;
using L.SpiderCore.Tools;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Net;
using System.Linq;

namespace L.SpiderCore.Test
{
    /// <summary>
    /// chinajoy 图片爬取
    /// </summary>
    public class ChinaJoyImageUrlSpider : WebDriverSpiderCrawler
    {
        protected override string Id => "ChinaJoyImageUrlSpider";

        protected override string Name => "chinajoy图片";

        protected override IList<string> Uris => new List<string>() {
            "http://news.17173.com/chinajoy/2017/"
        };

        protected override IDictionary<string, string> Rules { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ChinaJoyImageUrlSpider()
        {
            
        }
        /// <summary>
        /// html解析
        /// </summary>
        /// <param name="e"></param>
        public override void HtmlParser(OnWebDriverCompleteEventArgs e)
        {
            var ruls = GetAList(e.Page);
            var urls = GenerateUrls(ruls);
            var imageSpider=new ChinaJoyImageSpider(urls);
            imageSpider.Run();
        }
        private IList<string> GetImageList(string page)
        {
            IList<string> imageList = new List<string>();
            var selector = new XPathSelector(page);
            var photoList = selector.SelectNodes("//*[@id='pn_sg']/div[2]/div/div/div/div/div/div/div/ul[@class='photo-list']");
            foreach (var ul in photoList)
            {
                var childrens = ul.ChildNodes;
                foreach (var li in childrens)
                {
                    var images = li.SelectNodes("//*/li/a/div/img");
                    foreach (var image in images)
                    {
                        imageList.Add(image.GetAttributeValue("src", ""));
                    }
                }
            }
            return imageList;
        }
        private IList<string> GetAList(string page)
        {
            IList<string> u = new List<string>();
            var selector = new XPathSelector(page);
            var aList = selector.SelectNodes("//*[@id='pn_sg']/div[2]/div/div/div/div/div/div/div/ul/li/a");
            foreach (var a in aList)
            {
                string url=a.GetAttributeValue("href","");
                if (string.IsNullOrEmpty(url))
                {
                    continue;
                }
                url=url.Replace("http://", "");
                string[] urlP=url.Split("/");
                string ymd = urlP[urlP.Length - 2];
                string date = urlP[urlP.Length - 1];
                date = date.Substring(0, date.IndexOf("_"));
                Console.WriteLine(ymd + "/" + date);
                u.Add(ymd+"/"+date);
            }
            
            return u.Distinct().ToList();
        }
        private IList<string> GenerateUrls(IList<string> rules)
        {
            IList<string> urls = new List<string>();
            foreach (var rule in rules)
            {
                for (int i = 0; i < 11; i++)
                {
                    urls.Add(string.Format("http://news.17173.com/content/{0}_{1}.shtml", rule, i));
                }
            }
            return urls;
        }
      
    }
}
