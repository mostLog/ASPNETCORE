using L.SpiderCore.Event;
using L.SpiderCore.Tools;
using System;
using System.Collections.Generic;

namespace L.SpiderCore.Test
{
    public class NovelSpider : SpiderCrawler
    {
        /// <summary>
        /// 爬虫标识
        /// </summary>
        protected override string Id => "NovelSpider";
        /// <summary>
        /// 爬虫名称
        /// </summary>
        protected override string Name => "小说爬虫";
       
        protected override IDictionary<string, string> Rules { get; set; }
        protected override IList<string> Uris
        {
            get
            {
                return new List<string>() {
                    "http://www.biquge.cc/html/9/9378/"
                };
            } set => throw new NotImplementedException(); }

        /// <summary>
        /// html解析
        /// </summary>
        /// <param name="e"></param>
        public override void HtmlParser(OnCompleteEventArgs e)
        {
            var selector =new XPathSelector(e.Page);
            var aEles = selector.SelectNodes("//*[@id='list']/dl/dd/a");
            //var hrefs = selector.SelectNodes("//*[@id='list']/dl/dd/a/@href");
            foreach (var ele in aEles)
            {
                string articleUri=e.Uri + ele.GetAttributeValue("href", "");
                string articleTitle = ele.InnerText;
                Console.WriteLine("文章标题："+articleTitle+" 文章地址："+articleUri);
            }

            Console.WriteLine("Duration:"+e.Duration);
        }
    }
}
