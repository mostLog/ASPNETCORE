using L.SpiderCore.Crawler;
using L.SpiderCore.Event;
using L.SpiderCore.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace L.SpiderCore.Test
{
    /// <summary>
    /// 口水三国第二季视频地址爬取
    /// </summary>
    public class VideoUrlSpider : SpiderCrawler
    {
        public override string Id => "VideoUrlSpider";

        public override string Name => "口水三国视频爬取";


        public override IDictionary<string, string> Rules { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override IList<string> Uris {
            get {
                return new List<string>() {
                    "http://www.dilidili.wang/anime/kssg2/"
                };
            }
            set => throw new NotImplementedException();
        }

        public VideoUrlSpider()
        {
            
        }
        /// <summary>
        /// html解析
        /// </summary>
        /// <param name="e"></param>
        public override void HtmlParser(OnCompleteEventArgs e)
        {
            var hrefList = GethrefList(e.Page);
            if (hrefList.Count>0)
            {
                var spider = new VideoSpider() {
                    Uris=new List<string>() { hrefList[0]}
                };
                spider.Run();
            }
        }
        private IList<string> GethrefList(string page)
        {
            IList<string> u = new List<string>();
            var selector = new XPathSelector(page);
            var aList = selector.SelectNodes("//*[@class='time_con']/div/div/div/ul/li[@class='fj_li']/a");
            foreach (var a in aList)
            {
                string url = a.GetAttributeValue("href", "");
                if (string.IsNullOrEmpty(url))
                {
                    continue;
                }
                Console.WriteLine(url);
                u.Add(url);
            }
            return u.Distinct().ToList();
        }
    }
}
