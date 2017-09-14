namespace L.Application.Dto
{
    public class ImageSearchInput: PagedInputDto
    {
        /// <summary>
        /// 每次获取的记录数量
        /// </summary>
        public int RowCount { get; set; } = 5;
        /// <summary>
        /// 是否已抓取
        /// </summary>
        public bool? IsCrawlerImgInfo { get; set; }
    }
}