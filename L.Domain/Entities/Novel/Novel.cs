using L.Domain.Base;
using System;
using System.Collections.Generic;

namespace L.Domain.Entities
{
    /// <summary>
    /// 小说
    /// </summary>
    public class Novel: AuditEntity
    {
        /// <summary>
        /// 小说名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }
        /// <summary>
        /// 是否已经爬取文章
        /// </summary>
        public bool IsCrawlerArticle { get; set; }
        /// <summary>
        /// 文章集合
        /// </summary>
        public virtual ICollection<Article> Articles { get; set; }
    }
}
