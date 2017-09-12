using L.Domain.Entities;
using System;
using System.Collections.Generic;

namespace L.Application.Dto
{
    public class NovelEditDto
    {
        public int? Id { get; set; }

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
        /// 文章集合
        /// </summary>
        public ICollection<Article> Articles { get; set; }
    }
}