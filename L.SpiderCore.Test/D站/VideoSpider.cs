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
using L.SpiderCore.Crawler;

namespace L.SpiderCore.Test
{
    /// <summary>
    /// 口水三国第二季视频爬取
    /// </summary>
    public class VideoSpider : WebDriverSpiderCrawler
    {
        public override string Id => "VideoSpider";

        public override string Name => "口水三国视频爬取";


        public override IDictionary<string, string> Rules { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override IList<string> Uris {
            get;
            set;
        }

        public VideoSpider()
        {
           
        }
        /// <summary>
        /// html解析
        /// </summary>
        /// <param name="e"></param>
        public override void HtmlParser(OnWebDriverCompleteEventArgs e)
        {
            var selector = new XPathSelector(e.Page);
            var node=selector.SelectSingleNode("//*[@id='ckplayer_a1']");

            string flashvars=node.GetAttributeValue("flashvars","");
        }
        
    }
}
