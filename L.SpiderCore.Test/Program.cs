using System;

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

            string uri = "http://www.apic.in/anime/page/{1~100}";
            int sIndex = uri.IndexOf('{');
            int eIndex = uri.LastIndexOf('}');
            //
            string urlStartPart = uri.Substring(0, sIndex);
            var s = uri.Substring(sIndex + 1, eIndex - sIndex - 1);
            Console.WriteLine(urlStartPart);
            Console.ReadKey();
        }
    }
}