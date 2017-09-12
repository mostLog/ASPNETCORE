using System;

namespace L.Application.Dto
{
    public class TaskEditDto
    {
        public int? Id { get; set; }

        /// <summary>
        /// 爬虫id
        /// </summary>
        public string SpiderId { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 任务描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 爬取模式
        /// </summary>
        public int CrawlerType { get; set; }

        /// <summary>
        /// 网址集合
        /// </summary>
        public string Urls { get; set; }

        /// <summary>
        /// 是否开启定时执行
        /// </summary>
        public bool IsRecurrent { get; set; }

        /// <summary>
        /// 定时时间
        /// </summary>
        public DateTime? RecurrentDateTime { get; set; }

        /// <summary>
        /// Cron表达式
        /// </summary>
        public string RecurrentCron { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}