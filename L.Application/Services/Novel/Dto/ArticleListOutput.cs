namespace L.Application.Dto
{
    /// <summary>
    /// 小说章节列表输出对象
    /// </summary>
    public class ArticleListOutput
    {
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
    }
}