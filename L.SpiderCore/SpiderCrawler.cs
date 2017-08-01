using L.SpiderCore.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace L.SpiderCore
{
    /// <summary>
    /// 爬虫抽象类
    /// </summary>
    public abstract class SpiderCrawler
    {
        /// <summary>
        /// 爬虫完成事件
        /// </summary>
        public EventHandler<OnCompleteEventArgs> OnCompleted;

        /// <summary>
        /// 需要爬取的网址集合
        /// </summary>
        public IList<string> Urls { get; set; }
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
        public async virtual void Start()
        {
            //批量
            for (int i = 0; i < Urls.Count; i++)
            {
                //开启新线程
                await Task.Factory.StartNew(() => {

                    //XmlDocument
                });
            }
        }

    }
}
