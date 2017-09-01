using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;

namespace L.HangFire.AspNetCore.Services
{
    public class HangFireService:IHangFireService
    {
        /// <summary>
        /// 添加延迟任务
        /// </summary>
        public void AddDelaySchedule()
        {

        }
        /// <summary>
        /// 添加定时任务
        /// </summary>
        public void AddLoopSchedule()
        {

        }
        /// <summary>
        /// 添加入栈
        /// </summary>
        public void AddEnqueue()
        {
            //BackgroundJob.Enqueue();
        }
    }
}
