﻿using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Services.Dto
{
    public class SpiderTaskEditDto
    {
        public int? Id { get; set; }
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
        /// 是否开启定时执行
        /// </summary>
        public bool? IsOpenTime { get; set; }
        /// <summary>
        /// 定时开始时间
        /// </summary>
        public DateTime? OpenTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        
    }
}