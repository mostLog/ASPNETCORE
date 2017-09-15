using L.SpiderCore.Crawler.Common;
using System;
using System.IO;

namespace L.SpiderCore.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var spider = new NovelSpider();
            //spider.Run();
            //var spider = new VideoUrlSpider();
            //spider.Run();
            //var spider = new VideoUrlSpider();
            //spider.Run();
            //var spider = new SpiderManager();
            //IList<Domain.Entities.SpiderTask> tasks=spider.GetCrawlers();
            //foreach (var task in tasks)
            //{
            //    Console.WriteLine(task.Name);
            //}
            //
            string s = "http://img.gov.com.de/2017/07/apic.in_2017-07-03_14-53-42.jpg!origin";

            Console.WriteLine(Path.GetExtension(s));
            Console.WriteLine(Path.GetFileName(s));
            ImgHelper.GetImageAndSave("http://img.gov.com.de/2017/07/apic.in_2017-07-03_14-53-42.jpg!origin", @"C:\Temp\ApiInImages\");

            Console.ReadKey();
        }
    }
}