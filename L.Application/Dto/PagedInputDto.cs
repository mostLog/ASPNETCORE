namespace L.Application.Dto
{
    /// <summary>
    /// 分页公共InputDto
    /// 
    /// 小白-2017-6-12
    /// </summary>
    public class PagedInputDto
    {
        /// <summary>
        /// 页面当前索引
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 页面显示数量
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}
