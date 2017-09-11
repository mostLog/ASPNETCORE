using L.Domain.Base;
using System.Collections.Generic;

namespace L.Domain.Entities
{
    public class NovelType: AuditEntity
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 小说
        /// </summary>
        public ICollection<Novel> Novels { get; set; }
    }
}
