using System.Net;

namespace L.LCore.Http
{
    /// <summary>
    /// 代理帮助类
    /// </summary>
    public class ProxyHelper
    {
        /// <summary>
        /// 测试代理是否可用
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool PingProxy(string ip,int port)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.baidu.com");
                request.UserAgent = RequestConfig.UserAgent;
                //设置代理
                request.Proxy = CreteProxy(ip, port);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 创建代理
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static IWebProxy CreteProxy(string ip, int port)
        {
            IWebProxy proxy= new WebProxy(ip, port);
            return proxy;
        }
    }
}
