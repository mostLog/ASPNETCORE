using L.Domain.Base;
using System.Collections.Generic;

namespace L.Domain.Entities
{
    /// <summary>
    /// 爬取规则
    /// </summary>
    public class CrawlerRule : AuditEntity
    {
        /// <summary>
        /// 规则名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 规则类型
        /// </summary>
        public int RuleType { get; set; }

        /// <summary>
        /// 规则内容
        /// </summary>
        public string RuleContent { get; set; }

        /// <summary>
        /// 爬虫
        /// </summary>
        public virtual ICollection<SpiderTask> Tasks { get; set; }
    }
}