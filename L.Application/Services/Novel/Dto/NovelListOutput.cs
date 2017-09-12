namespace L.Application.Dto
{
    /// <summary>
    /// 小说信息输出dto
    /// </summary>
    public class NovelListOutput
    {
        public int Id { get; set; }

        /// <summary>
        /// 小说名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 最新章节
        /// </summary>
        public string NewChapter { get; set; }

        /// <summary>
        /// 当前章节数量
        /// </summary>
        public string ChapterNum { get; set; }

        /// <summary>
        /// 是否开启邮件推送
        /// </summary>
        public bool IsOpenEmail { get; set; }
    }
}