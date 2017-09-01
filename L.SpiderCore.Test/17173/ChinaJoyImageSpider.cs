using L.SpiderCore.Crawler;
using L.SpiderCore.Event;
using L.SpiderCore.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;

namespace L.SpiderCore.Test
{
    /// <summary>
    /// chinajoy 图片爬取
    /// </summary>
    public class ChinaJoyImageSpider : SpiderCrawler
    {
        public override string Id => "ChinaJoyImageSpider";

        public override string Name => "chinajoy图片爬取";

        
        public override IDictionary<string, string> Rules { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// 
        /// </summary>
        public override IList<string> Uris {get; set; }

        public ChinaJoyImageSpider()
        {
            
        }
        /// <summary>
        /// html解析
        /// </summary>
        /// <param name="e"></param>
        public override void HtmlParser(OnCompleteEventArgs e)
        {
            var selector = new XPathSelector(e.Page);
            var imageNode=selector.SelectSingleNode("//*[@id='mod_article']/p[1]/a/img");
            string imgUrl = imageNode.GetAttributeValue("src","");
            GetImageAndSave(imgUrl);

        }
        private void GetImageAndSave(string imgUri)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(imgUri);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.90 Safari/537.36";
            request.KeepAlive = true;
            request.Accept = "image/webp,image/apng,image/*,*/*;q=0.8";
            Console.WriteLine("获取图片地址：" + imgUri);
            using (var response = request.GetResponse())
            {
                var stream = response.GetResponseStream();
                if (stream.Length!=0)
                {
                    using (var image = Image.FromStream(stream))
                    {
                        string saveUri = @"C:\Users\Administrator\Pictures\chinajoy\" + Path.GetFileName(imgUri);
                        try
                        {
                            image.Save(saveUri);
                            Console.WriteLine("图片保存成功！");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("图片保存失败！" + e.Message);
                        }
                    }
                }
            }
        }
    }
}
