using L.Application.Services;
using L.LCore.Infrastructure.Dependeny;
using System.Collections.Generic;
using System.Linq;

namespace L.Pathogen
{
    public class ArticleDataReaderProcessor : IDataReaderProcessor
    {
        private INovelService _novelService = ContainerManager.Resolve<INovelService>();
        /// <summary>
        /// 读取数据
        /// </summary>
        public IList<InfectionTarget> Reader()
        {
            return _novelService.GetArticles(
                new Application.Dto.ArticleSearchInput()
                {
                    IsCrawlerContent = false,
                    RowCount = 10000
                }).Select(m =>
                {
                    return new InfectionTarget()
                    {
                        Url = m.Url,
                        ExtraObj = m
                    };
                }).ToList();
        }
    }
}
