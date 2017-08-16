using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace L.SpiderCore.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var spider = new NovelSpider();
            //spider.Run();
            var spider = new ChinaJoyImageUrlSpider();
            spider.Run();
            Console.ReadKey();
        }
    }
}
