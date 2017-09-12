namespace L.Application.Dto
{
    public class NovelSearchInput : PagedInputDto
    {
        /// <summary>
        ///
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 小说名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否已经爬取
        /// </summary>
        public bool IsCrawlerArticle { get; set; } = false;

        /// <summary>
        /// 是否开启邮件推送
        /// </summary>
        public bool IsOpenEmail { get; set; }
    }
}