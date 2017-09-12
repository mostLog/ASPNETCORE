using L.Application.Services;
using L.Domain.Entities;
using L.LCore.Email;
using L.LCore.Infrastructure.Dependeny;
using L.SpiderCore.Event;
using L.SpiderCore.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace L.SpiderCore.Crawler
{
    [Spider("ArticleSpider")]
    public class ArticleSpider : SpiderCrawlerOfData<Article>
    {
        private INovelService _novelService;

        public ArticleSpider()
        {
        }

        public override void HtmlParser(OnCompleteEventArgs e)
        {
            var article = Current;
            var selector = new XPathSelector(e.Page);
            var node = selector.SelectSingleNode("//*[@id='content']");
            //获取小说内容
            string content = node.InnerHtml;
            article.Content = content;
            article.IsCrawlerContent = true;
            //更新信息
            _novelService.UpdateArticel(article);
            Config.CallBack?.Invoke(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "--" + article.Title + "--获取文章成功！");
            //是否启动邮件发送
            if (article.Novel != null && article.Novel.IsOpenEmail)
            {
                //发送邮件
                EmailHelper.SendEmail(article.Title, content, new List<string>() { "2434934089@qq.com" });
            }
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="config"></param>
        public override void InitConfig(SpiderConfig config)
        {
            _novelService = ContainerManager.Resolve<INovelService>();
            //初始化数据
            Datas = _novelService.GetArticles(
                new Application.Dto.ArticleSearchInput()
                {
                    IsCrawlerContent = false,
                    RowCount = 10
                }).Select(m =>
                {
                    return new KeyValuePair<string, Article>(m.Url, m);
                }).ToList();
            base.InitConfig(config);
        }
    }
}