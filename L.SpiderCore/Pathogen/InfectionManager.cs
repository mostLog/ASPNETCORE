using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace L.Pathogen
{
    /// <summary>
    /// 感染管理
    /// </summary>
    public class InfectionManager
    {
        public static HttpWebRequest CreateRequest(InfectionConfig config)
        {
            var request = (HttpWebRequest)WebRequest.Create(config.Url);
            request.Headers.Add(HttpRequestHeader.Accept, config.Accept);
            request.Headers.Add(HttpRequestHeader.UserAgent, config.UserAgent);
            request.Headers.Add(HttpRequestHeader.ContentType, config.ContentType);
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, config.AcceptEncoding);
            request.AllowWriteStreamBuffering = config.AllowWriteStreamBuffering;
            request.AllowAutoRedirect = config.AllowAutoRedirect;
            request.Timeout = config.Timeout;
            request.KeepAlive = config.KeepAlive;                       
            request.Method = config.Method;
            return request;
        }
        public static PagePathogen GetResponse(HttpWebRequest request)
        {
            var pagePathogen = new PagePathogen();
            pagePathogen.Url = request.Address.AbsoluteUri;
            pagePathogen.Host = request.Address.Host;
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
                                pagePathogen.PageSource = reader.ReadToEnd();
                            }
                        }
                    }
                    else
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                pagePathogen.PageSource = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
           catch (Exception)
            {
                return pagePathogen;
            }
            return pagePathogen;
        }
    }
    /// <summary>
    /// 感染配置
    /// </summary>
    public class InfectionConfig
    {
        //地址
        public string Url { get; set; }
        //用户代理
        public string UserAgent { get; set; } = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";
        public string Accept { get; set; } = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
        public string ContentType { get; set; } = "application/x-www-form-urlencoded";
        public string AcceptEncoding { get; set; } = "gzip,deflate";
        //是否允许自动跳转
        public bool AllowAutoRedirect { get; set; } = false;
        //是否允许使用缓冲
        public bool AllowWriteStreamBuffering { get; set; } = false;
        /// <summary>
        /// 超时时间
        /// </summary>
        public int Timeout { get; set; } = 5000;
        //是否启用长连接
        public bool KeepAlive { get; set; } = true;
        /// <summary>
        /// 请求方式
        /// </summary>
        public string Method { get; set; } = "GET";
    }
}
