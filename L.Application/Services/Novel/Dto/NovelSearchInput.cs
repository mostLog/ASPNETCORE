using L.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Dto
{
    public class NovelSearchInput: PagedInputDto
    {
        /// <summary>
        /// 小说名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否已经爬取
        /// </summary>
        public bool IsCrawlerArticle { get; set; } = false;
    }
}
