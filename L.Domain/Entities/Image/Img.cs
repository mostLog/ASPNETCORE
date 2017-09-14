using L.Domain.Base;
using System.Collections.Generic;

namespace L.Domain.Entities
{
    public class Img : AuditEntity
    {
        /// <summary>
        /// 图片所在页面地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        public string Introduce { get; set; }

        /// <summary>
        /// 是否已经抓取图片信息
        /// </summary>
        public bool IsCrawlerImgInfo { get; set; }
        /// <summary>
        /// 开始索引
        /// </summary>
        public int PageStartIndex { get; set; } = 1;
        /// <summary>
        /// 结束索引
        /// </summary>
        public int PageEndIndex { get; set; } = 1;
        /// <summary>
        /// 图片信息
        /// </summary>
        public virtual ICollection<ImageInfo> ImageInfos { get; set; }
    }
}