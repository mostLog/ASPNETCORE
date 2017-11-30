using L.Application.Dto;
using L.Domain.Entities;
using L.EntityFramework;
using L.LCore.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L.Application.Services
{
    public class NovelService : AppService, INovelService
    {
        //公共仓储
        private readonly IBaseRepository<Novel> _novelRepository;

        private readonly IBaseRepository<Article> _articleRepository;

        public NovelService(
            IBaseRepository<Novel> novelRepository,
            IBaseRepository<Article> articleRepository)
        {
            _novelRepository = novelRepository;
            _articleRepository = articleRepository;
        }

        public async void AddNovel(Novel input)
        {
            await _novelRepository.InsertAsync(input);
        }

        /// <summary>
        /// 更新小说信息
        /// </summary>
        public async void UpdateNovel(Novel input)
        {
            var novel = await _novelRepository.GetEntityByIdAsync(input.Id);
            novel.IsOpenEmail = input.IsOpenEmail;
            //更新小说
            await _novelRepository.UpdateAsync(novel);
        }

        /// <summary>
        /// 返回小说信息
        /// </summary>
        /// <returns></returns>
        public async Task<PagedListResult<NovelListOutput>> GetNovelPagedList(NovelSearchInput input)
        {
            var query = _novelRepository.Table;
            var tmplist = query
                .AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(input.Name), m => m.Name.Contains(input.Name))
                .OrderByDescending(m => m.CreateDateTime);
            var list = await tmplist
                .PageBy(input.PageIndex, input.PageSize)
                .ToListAsync();
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Novel, NovelListOutput>());
            //总数
            int count = tmplist.Count();
            return new PagedListResult<NovelListOutput>()
            {
                Data = AutoMapper.Mapper.Map<IList<NovelListOutput>>(list),
                Count = count,
                Code = 0
            };
        }

        /// <summary>
        /// 获取小说
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Novel GetSingleNovel(NovelSearchInput input)
        {
            var query = _novelRepository.Table;
            return query.WhereIf(!string.IsNullOrEmpty(input.Name), m => m.Name.Contains(input.Name)).FirstOrDefault();
        }

        /// <summary>
        /// 获取小说列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public IList<Novel> GetNovels(NovelSearchInput input)
        {
            var query = _novelRepository.Table;
            return query
                .Where(m => m.IsCrawlerArticle == input.IsCrawlerArticle)
                .WhereIf(!string.IsNullOrEmpty(input.Name), m => m.Name.Contains(input.Name))
                .ToList();
        }

        /// <summary>
        /// 获取小说列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IList<ArticleListOutput>> GetArticlesByNovelId(BaseDto input)
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Article, ArticleListOutput>());
            if (input.Id.HasValue)
            {
                //获取小说
                var novel = await _novelRepository.Table
                    .Include(c => c.Articles)
                    .FirstOrDefaultAsync(c => c.Id == input.Id.Value);
                if (novel != null)
                {
                    var articles = novel.Articles.OrderByDescending(m => m.Seq);
                    return AutoMapper.Mapper.Map<IList<ArticleListOutput>>(articles);
                }
            }
            return new List<ArticleListOutput>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Article GetArticleById(int id)
        {
            return _articleRepository.GetEntityById(id);
        }

        /// <summary>
        /// 获取所有未爬取章节内容的文章
        /// </summary>
        /// <returns></returns>
        public IList<Article> GetArticles(ArticleSearchInput input)
        {
            return _articleRepository.Table
                .Where(m => m.IsCrawlerContent == input.IsCrawlerContent)
                .WhereIf(input.Seq != null && input.Seq.Value != 0, m => m.Seq == input.Seq.Value)
                .Include(m => m.Novel)
                .Take(input.RowCount)
                .ToList();
        }

        /// <summary>
        /// 获取数据库最新小说
        /// </summary>
        /// <returns></returns>
        public Article GetLaestArticle()
        {
            return _articleRepository.Table
                .AsNoTracking()
                .OrderByDescending(m => m.Seq)
                .FirstOrDefault();
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="article"></param>
        public void AddArticles(IList<Article> articles)
        {
            foreach (var article in articles)
            {
                _articleRepository.Insert(article);
            }
        }

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="article"></param>
        public void UpdateArticel(Article article)
        {

            _articleRepository.Update(article);
        }
    }
}