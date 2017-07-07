using System;

namespace L.LCore.Domain.Entities
{
    public class Notice
    {
        /// <summary>
        /// 自增id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 公告类型,0=一般公告、1=紧急通知
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 公告内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>
        public string Registrant { get; set; }
        /// <summary>
        /// 有效开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 有效结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 是否停止
        /// </summary>
        public bool IsTop { get; set; }
    }
}
