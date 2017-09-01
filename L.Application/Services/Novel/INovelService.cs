using L.Application.Dto;
using L.Domain.Entities;
using L.EntityFramework.Uow;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace L.Application.Services
{
    [UnitOfWork(isTransactional:true)]
    public interface INovelService:IAppService
    {
        [NoUnitOfWork]
        Task<PagedListResult<NovelListOutput>> GetNovelPagedList(NovelSearchInput input);
        /// <summary>
        /// 获取小说
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [NoUnitOfWork]
        Novel GetSingleNovel(NovelSearchInput input);
        /// <summary>
        /// 获取小说集合
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [NoUnitOfWork]
        IList<Novel> GetNovels(NovelSearchInput input);
        /// <summary>
        /// 添加小说
        /// </summary>
        /// <param name="input"></param>
        void AddNovel(Novel input);
        /// <summary>
        /// 获取小说章节列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [NoUnitOfWork]
        Task<IList<ArticleListOutput>> GetArticlesByNovelId(BaseDto input);
        /// <summary>
        /// 获取通过id获取章节
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [NoUnitOfWork]
        Article GetArticleById(int id);
        /// <summary>
        /// 获取所有未爬取章节内容的文章
        /// </summary>
        /// <returns></returns>
        [NoUnitOfWork]
        IList<Article> GetArticles(ArticleSearchInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="article"></param>
        void AddArticle(Article article);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="article"></param>
        void UpdateArticel(Article article);
    }
}
