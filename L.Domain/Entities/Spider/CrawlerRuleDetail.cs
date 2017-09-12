using L.Domain.Base;

namespace L.Domain.Entities
{
    /// <summary>
    /// 规则明细
    /// </summary>
    public class CrawlerRuleDetail : AuditEntity
    {
        /// <summary>
        /// /表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 数据库表列明
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 字段列规则
        /// </summary>

        public string ColumnRule { get; set; }
        /// <summary>
        /// 规则实体
        /// </summary>

        public virtual CrawlerRule CrawlerRule { get; set; }
    }
}