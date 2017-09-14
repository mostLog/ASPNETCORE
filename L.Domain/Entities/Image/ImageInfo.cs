using L.Domain.Base;

namespace L.Domain.Entities
{
    public class ImageInfo : AuditEntity
    {
        /// <summary>
        /// 图片名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 图片分辨率宽
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 图片分辨率高
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 图片源地址字符串
        /// </summary>
        public string SourceUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Img Img { get; set; }

        
    }
}