using L.SpiderCore.Event;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

namespace L.SpiderCore
{
    public abstract class WebDriverSpiderCrawler : ISpiderCrawler
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
        protected abstract IList<string> Uris { get; }
        /// <summary>
        /// 规则
        /// </summary>
        protected abstract IDictionary<string, string> Rules { get; set; }
        /// <summary>
        /// 获取爬取数据结果
        /// </summary>

        public DataTable Result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        PhantomJSOptions _options;
        /// <summary>
        /// 
        /// </summary>
        PhantomJSDriverService _service;
        /// <summary>
        /// 爬虫完成事件
        /// </summary>
        public EventHandler<OnWebDriverCompleteEventArgs> OnCompleted;
        /// <summary>
        /// 
        /// </summary>
        public WebDriverSpiderCrawler()
        {
            OnCompleted += SpiderCrawler_OnCompleted;
            this._options = new PhantomJSOptions();
            this._service = PhantomJSDriverService.CreateDefaultService(Environment.CurrentDirectory);
            _service.IgnoreSslErrors = true;
            _service.LoadImages = false;
            _service.WebSecurity = false;
            _service.HideCommandPromptWindow = true;
            _service.LocalToRemoteUrlAccess = true;
            this._options.AddAdditionalCapability("phantomjs.page.settings.userAgent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36");
        }
        /// <summary>
        /// 爬取数据完成后执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpiderCrawler_OnCompleted(object sender, OnWebDriverCompleteEventArgs e)
        {
            //退出无头游览器
            e.Driver.Quit();
            //解析html
            HtmlParser(e);
        }
        /// <summary>
        /// html解析方法
        /// </summary>
        public abstract void HtmlParser(OnWebDriverCompleteEventArgs e);
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
                await Task.Factory.StartNew(() =>
                {
                    var driver = new PhantomJSDriver(_service, _options);
                    driver.Navigate().GoToUrl(uri);
                    OnWebDriverCompleteEventArgs completeArgs = new OnWebDriverCompleteEventArgs();
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    completeArgs.Page = driver.PageSource;
                    completeArgs.Driver = driver;
                    stopWatch.Stop();
                    completeArgs.Duration = stopWatch.ElapsedMilliseconds;
                    this.OnCompleted(this, completeArgs);
                    
                });
            }
        }
    }
}
