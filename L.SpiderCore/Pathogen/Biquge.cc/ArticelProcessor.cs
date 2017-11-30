using L.Application.Services;
using L.Domain.Entities;
using L.LCore.Email;
using L.LCore.Infrastructure.Dependeny;
using L.SpiderCore.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace L.Pathogen
{
    public class ArticleProcessor : IProcessor
    {
        private INovelService _novelService = ContainerManager.Resolve<INovelService>();
        private ILoggerService _loggerService = ContainerManager.Resolve<ILoggerService>();
        public ArticleProcessor()
        {

        }

        /// <summary>
        /// 数据处理
        /// </summary>
        /// <param name="resultDatas"></param>
        public void DataProcess(IDictionary<string, object> resultDatas)
        {
            string url = resultDatas["requestUrl"] as string;
            try
            {
                string content = resultDatas["article"] as string;
                //获取文章对象
                Article article = resultDatas["extraObj"] as Article;
                if (!string.IsNullOrEmpty(content))
                {
                    article.Content = content;
                }
                article.IsCrawlerContent = true;
                //更新信息
                _novelService.UpdateArticel(article);
                //是否启动邮件发送
                if (article.Novel != null && article.Novel.IsOpenEmail)
                {
                    //发送邮件
                    EmailHelper.SendEmail(article.Title, content, new List<string>() { "2434934089@qq.com" });
                }
            }
            catch (Exception e)
            {
                //记录错误信息
                _loggerService.WriteLog(new Log()
                {
                    DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    LogLevel = (int)LCore.Logger.LogLevel.Error,
                    ClassName = this.GetType().FullName,
                    ActionName = e.TargetSite.Name,
                    Msg = url+"---"+e.Message+"---"+e.StackTrace
                });
            }
           
        }

        /// <summary>
        /// 页面解析
        /// </summary>
        /// <param name="pagePathogen"></param>
        public void PageProcess(PagePathogen pagePathogen)
        {
            try
            {
                //添加请求地址
                pagePathogen.AddResult("requestUrl",pagePathogen.Url);
                var selector = new XPathSelector(pagePathogen.PageSource);
                var node = selector.SelectSingleNode("//*[@id='content']");
                if (node != null)
                {
                    pagePathogen.AddResult("article", node.InnerHtml);
                }
                else
                {
                    //记录爬取日志
                    _loggerService.WriteLog(new Log()
                    {
                        DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Msg = pagePathogen.Url + "---未解析到数据！",
                        ClassName = "",
                        ActionName = "",
                        Duration = 0,
                        LogLevel = (int)LCore.Logger.LogLevel.Warn
                    });
                }
            }
            catch (Exception e)
            {
                //记录错误信息
                _loggerService.WriteLog(new Log()
                {
                    DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    LogLevel = (int)LCore.Logger.LogLevel.Error,
                    ClassName = this.GetType().FullName,
                    ActionName = e.TargetSite.Name,
                    Msg = pagePathogen.Url+"---"+e.Message + "---" + e.StackTrace
                });
            }
        }

       
    }
}
