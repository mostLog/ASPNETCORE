using L.Application.Dto;
using L.Application.Services;
using L.Domain.Entities;
using L.SpiderCore.Event;
using L.SpiderCore.Tools;
using System;
using System.Linq;
using System.Collections.Generic;
using L.LCore.Infrastructure.Dependeny;
using L.EntityFramework.Uow;

namespace L.SpiderCore.Crawler
{
    [Spider("NovelSpider")]
    public class NovelSpider : SpiderCrawler
    {

        /// <summary>
        /// 
        /// </summary>
        public NovelSpider()
        {

        }
        /// <summary>
        /// html解析
        /// </summary>
        /// <param name="e"></param>
        public override void HtmlParser(OnCompleteEventArgs e)
        {
            //获取服务
            var appService = ContainerManager.Resolve<INovelService>();
            var selector = new XPathSelector(e.Page);
            //小说
            Novel novel = new Novel();
            //文章信息
            novel.Articles = new List<Article>();           
            #region 小说信息
            var nameEle = selector.SelectSingleNode("//*[@id='info']/h1");
            if (nameEle != null)
            {
                novel.Name = nameEle.InnerText;
            }
            var authorEle = selector.SelectSingleNode("//*[@id='info']/p[1]");
            if (authorEle != null)
            {
                string pStr = authorEle.InnerText;
                novel.Author = pStr.Split('：')[1];
            }
            #endregion
            var oldNovel = appService.GetSingleNovel(new NovelSearchInput() { Name= novel.Name });
            if (oldNovel==null)
            {
                #region 文章标题与链接地址
                GetArticles(selector,novel,e.Uri, "//*[@id='list']/dl/dd/a");
                #endregion
                if (novel.Articles.Count>0)
                {
                    //设为已爬取
                    novel.IsCrawlerArticle = true;
                }
                //添加小说
                appService.AddNovel(novel);
            }
            else
            {
                var unitOfWork=ContainerManager.Resolve<IUnitOfWork>();
                unitOfWork.Begin(new UnitOfWorkOptions());
                var laestArticle=appService.GetLaestArticle();
                oldNovel.Articles = new List<Article>();
                //获取最新章节
                GetArticles(selector,oldNovel,e.Uri, "//*[@id='list']/dl/dd/a[number(translate(@href,'.html',''))>"+ laestArticle.Seq+ "]");
                foreach (var article in oldNovel.Articles)
                {
                    var ats=appService.GetArticles(new ArticleSearchInput() { Seq = article.Seq });
                    if (ats.Count==0)
                    {
                        appService.AddArticle(article);
                    }
                }
                unitOfWork.Complete();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="novel"></param>
        /// <param name="uri"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        private void GetArticles(XPathSelector selector,Novel novel,string uri,string xpath)
        {
            var aEles = selector.SelectNodes(xpath);
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
                //回调
                Config.CallBack?.Invoke(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "--文章标题：" + articleTitle + " 文章地址：" + articleUri);
                novel.Articles.Add(article);
            }
        }
    }
}
