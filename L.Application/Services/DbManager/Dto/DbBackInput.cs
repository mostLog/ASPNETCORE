using System;

namespace L.Application.Dto
{
    public class DbBackInput
    {
        /// <summary>
        /// 备份日期
        /// </summary>
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DbName { get; set; }
    }
}