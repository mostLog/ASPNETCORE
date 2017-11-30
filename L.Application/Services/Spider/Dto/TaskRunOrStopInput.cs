using System.Collections.Generic;

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

    }
}