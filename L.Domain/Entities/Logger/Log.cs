﻿using L.Domain.Base;
using System;

namespace L.Domain.Entities
{
    /// <summary>
    /// 日志表
    /// </summary>
    public class Log : BaseEntity<int>
    {
        /// <summary>
        /// 记录时间
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 方法名称
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 消耗时间
        /// </summary>
        public long? Duration { get; set; }

        /// <summary>
        /// 日志等级
        /// </summary>
        public int LogLevel { get; set; }
    }
}