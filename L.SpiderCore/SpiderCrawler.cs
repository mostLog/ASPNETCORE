using L.SpiderCore.Event;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace L.SpiderCore
{
    /// <summary>
    /// 爬虫抽象类
    /// </summary>
    public abstract class SpiderCrawler : ISpiderCrawler
    {
        /// <summary>
        /// 爬虫标识
        /// </summary>
        protected abstract string Id { get; }
        /// <summary>
        /// 爬虫名称
        /// </summary>
        protected abstract string Name { get; }
        /// <summary>
        /// 需要爬取的uri地址集合
        /// </summary>
        protected abstract IList<string> Uris { get; set; }
        /// <summary>
        /// 规则
        /// </summary>
        protected abstract IDictionary<string, string> Rules{ get; set; }
        /// <summary>
        /// 获取爬取数据结果
        /// </summary>

        public DataTable Result { get; set; }
        /// <summary>
        /// 爬虫完成事件
        /// </summary>
        public EventHandler<OnCompleteEventArgs> OnCompleted;
        /// <summary>
        /// 
        /// </summary>
        public SpiderCrawler()
        {
            OnCompleted += SpiderCrawler_OnCompleted;
        }
        /// <summary>
        /// 爬取数据完成后执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpiderCrawler_OnCompleted(object sender, OnCompleteEventArgs e)
        {
            //解析html
            HtmlParser(e);
        }
        /// <summary>
        /// html解析方法
        /// </summary>
        public abstract void HtmlParser(OnCompleteEventArgs e);
        /// <summary>
        /// 启动爬取
        /// </summary>
        public async virtual void Run()
        {
            //批量
            for (int i = 0; i < Uris.Count; i++)
            {
                string uri = Uris[i];
                //开启新线程
                await Task.Factory.StartNew(async () => {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    var http = new HttpClient();
                    var request=(HttpWebRequest)HttpWebRequest.Create(uri);
                    #region 请求参数
                    request.Headers.Add(HttpRequestHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                    //设置User-Agent，伪装成Google Chrome浏览器
                    request.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36");
                    request.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    //定义gzip压缩页面支持
                    request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                    request.AllowWriteStreamBuffering = false;//禁止缓冲加快载入速度
                    request.AllowAutoRedirect = false;//禁止自动跳转
                    request.Timeout = 5000;//定义请求超时时间为5秒
                    //启用长连接
                    request.KeepAlive = true;
                    //定义请求方式为GET              
                    request.Method = "GET"; 
                    #endregion
                    var completeArgs = new OnCompleteEventArgs() {
                        Uri=uri
                    };
                    using (var response=(HttpWebResponse)request.GetResponse())
                    {
                        //判断如果已压缩 解压
                        if (response.ContentEncoding.ToLower().Contains("gzip"))
                        {
                            using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {
                                    completeArgs.Page =await reader.ReadToEndAsync();
                                }
                            }
                        }else
                        {
                            using (var stream = response.GetResponseStream())
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {
                                    completeArgs.Page = await reader.ReadToEndAsync();
                                }
                            }
                        }
                    }
                    stopWatch.Stop();
                    completeArgs.Duration = stopWatch.ElapsedMilliseconds;
                    this.OnCompleted(this, completeArgs);
                });
            }
        }

    }
}
