using L.Application.Services;
using System;


namespace L.SpiderCore.Event
{
    /// <summary>
    /// 当爬虫执行完参数传递
    /// </summary>
    public class OnCompleteEventArgs : EventArgs
    {
        /// <summary>
        /// 爬取地址
        /// </summary>
        public string Uri { get; set; }
        /// <summary>
        /// 页面html
        /// </summary>
        public string Page { get; set; }
        /// <summary>
        /// 花费时间
        /// </summary>
        public long Duration { get; set; }

        public OnCompleteEventArgs()
        {

        }
        public OnCompleteEventArgs(string uri,string page,long duration)
        {
            Uri = uri;
            Page = page;
            Duration = duration;
        }
    }
}
