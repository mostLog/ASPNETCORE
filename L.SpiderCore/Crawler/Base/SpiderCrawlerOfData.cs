using L.SpiderCore.Event;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace L.SpiderCore.Crawler
{
    /// <summary>
    /// 数据型爬虫
    /// </summary>
    public abstract class SpiderCrawlerOfData<T> : SpiderCrawler
    {
        /// <summary>
        /// 数据集合
        /// </summary>
        public IList<KeyValuePair<string, T>> Datas { get; set; }

        /// <summary>
        /// 当前操作数据对象
        /// </summary>
        public T Current { get; set; }

        /// <summary>
        ///
        /// </summary>
        public async override void Run()
        {
            if (Datas != null && Datas.Count > 0)
            {
                foreach (KeyValuePair<string, T> item in Datas)
                {
                    var uri = item.Key;
                    Current = item.Value;
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    var request = (HttpWebRequest)HttpWebRequest.Create(uri);

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

                    #endregion 请求参数

                    var completeArgs = new OnCompleteEventArgs()
                    {
                        Uri = uri
                    };
                    try
                    {
                        using (var response = (HttpWebResponse)request.GetResponse())
                        {
                            //判断如果已压缩 解压
                            if (response.ContentEncoding != null && response.ContentEncoding.ToLower().Contains("gzip"))
                            {
                                using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                                {
                                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                    {
                                        completeArgs.Page = await reader.ReadToEndAsync();
                                    }
                                }
                            }
                            else
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
                    }
                    catch (System.Exception)
                    {
                        return;
                    }
                    stopWatch.Stop();
                    completeArgs.Duration = stopWatch.ElapsedMilliseconds;
                    //通知
                    Config.CallBack?.Invoke("请求Url:" + uri + "成功！" + " " + "花费时间：" + completeArgs.Duration);
                    this.OnCompleted(this, completeArgs);
                }
            }
        }
    }
}