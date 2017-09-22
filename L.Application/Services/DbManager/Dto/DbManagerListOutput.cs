namespace L.Application.Dto
{
    /// <summary>
    /// 数据库信息
    /// </summary>
    public class DbManagerListOutput
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 表记录数
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// 表空间
        /// </summary>
        public string Reserved { get; set; }
    }
}