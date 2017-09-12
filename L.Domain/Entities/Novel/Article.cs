using L.Domain.Base;

namespace L.Domain.Entities
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article : AuditEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 是否已爬取文章内容
        /// </summary>
        public bool IsCrawlerContent { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public long Seq { get; set; }

        /// <summary>
        /// 小说
        /// </summary>
        public virtual Novel Novel { get; set; }
    }
}