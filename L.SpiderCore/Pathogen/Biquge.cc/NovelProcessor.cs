using L.Application.Dto;
using L.Application.Services;
using L.Domain.Entities;
using L.LCore.Infrastructure.Dependeny;
using L.SpiderCore.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace L.Pathogen
{
    public class NovelProcessor : IProcessor
    {
        /// <summary>
        /// 日志服务
        /// </summary>
        private ILoggerService _loggerService = ContainerManager.Resolve<ILoggerService>();

        /// <summary>
        /// 小说服务
        /// </summary>
        private INovelService _novelService = ContainerManager.Resolve<INovelService>();

        public void DataProcess(IDictionary<string, object> resultDatas)
        {
            var novel = resultDatas["novel"] as Novel;
            //判断数据库是否存在novel
            var tmpNovel = _novelService.GetSingleNovel(new NovelSearchInput() { Name = novel.Name });
            if (tmpNovel == null)
            {
                if (novel.Articles.Count > 0)
                {
                    //设为已爬取
                    novel.IsCrawlerArticle = true;
                }
                //添加小说
                _novelService.AddNovel(novel);
            }
            else
            {
                var laestArticle = _novelService.GetLaestArticle();
                //获取最新章节
                var articles=tmpNovel.Articles.Where(c => c.Seq >laestArticle.Seq).ToList();
                //更新新章节
                _novelService.AddArticles(articles);
            }
        }

        public void PageProcess(PagePathogen pagePathogen)
        {
            var selector = new XPathSelector(pagePathogen.PageSource);
            //小说
            Novel novel = new Novel();
            //文章信息
            novel.Articles = new List<Article>();
            var nameEle = selector.SelectSingleNode("//*[@id='info']/h1");
            if (nameEle != null)
            {
                //小说名称
                novel.Name = nameEle.InnerText;
            }
            var authorEle = selector.SelectSingleNode("//*[@id='info']/p[1]");
            if (authorEle != null)
            {
                string pStr = authorEle.InnerText;
                //作者
                novel.Author = pStr.Split('：')[1];
            }
            //获取对应文章信息
            GetArticles(selector, novel, pagePathogen.Url, "//*[@id='list']/dl/dd/a");
            //传递抓取数据信息
            pagePathogen.AddResult("novel",novel);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="novel"></param>
        /// <param name="uri"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        private void GetArticles(XPathSelector selector, Novel novel, string uri, string xpath)
        {
            var aEles = selector.SelectNodes(xpath);
            if (aEles != null)
            {
                foreach (var ele in aEles)
                {
                    string articleUri = uri + ele.GetAttributeValue("href", "");
                    string[] s = articleUri.Split('/');
                    string uN = s[s.Length - 1];
                    long htmlFileName = long.Parse(uN.Substring(0, uN.IndexOf('.')));
                    string articleTitle = ele.InnerText;
                    var article = new Article()
                    {
                        Title = articleTitle,
                        Url = articleUri,
                        Novel = novel,
                        Seq = htmlFileName
                    };
                    novel.Articles.Add(article);
                }
            }
        }
    }
}
