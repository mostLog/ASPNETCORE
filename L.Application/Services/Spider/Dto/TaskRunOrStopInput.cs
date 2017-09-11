using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Dto
{
    public class TaskRunOrStopInput
    {
        /// <summary>
        /// 是否开启循环任务
        /// </summary>
        public bool IsRecurrent { get; set; }
        /// <summary>
        /// 爬虫id
        /// </summary>
        public string SpiderId { get; set; }
        /// <summary>
        /// 定时任务cron表达式
        /// </summary>
        public string RecurrentCron { get; set; }
        /// <summary>
        /// 爬取地址
        /// </summary>
        public IList<string> Uris { get; set; }
    }
}
