using System;
using System.Xml;


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
        public string Url { get; set; }
        public OnCompleteEventArgs()
        {
            
        }
    }
}
