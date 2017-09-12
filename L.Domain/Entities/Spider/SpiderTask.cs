using L.Domain.Base;
using System;
using System.Collections.Generic;

namespace L.Domain.Entities
{
    public class SpiderTask : AuditEntity
    {
        /// <summary>
        /// 爬虫id 循环任务id
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
        /// 爬取网址
        /// </summary>
        public string Urls { get; set; }

        /// <summary>
        /// 是否开启定时执行
        /// </summary>
        public bool IsRecurrent { get; set; }

        /// <summary>
        /// 定时开始时间
        /// </summary>
        public DateTime? RecurrentDateTime { get; set; }

        /// <summary>
        /// 循环任务cron表达式
        /// </summary>
        public string RecurrentCron { get; set; }

        /// <summary>
        /// 采集时间间隔
        /// </summary>
        public int AcquisitionInterval { get; set; }

        /// <summary>
        /// 爬取规则
        /// </summary>
        public virtual ICollection<CrawlerRule> Rules { get; set; }
    }
}