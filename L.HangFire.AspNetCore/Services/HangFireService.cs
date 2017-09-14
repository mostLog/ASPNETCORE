using Hangfire;
using System;
using System.Linq.Expressions;

namespace L.HangFire.AspNetCore.Services
{
    public class HangFireService : IHangFireService
    {
        /// <summary>
        /// 添加延迟任务
        /// </summary>
        public string AddDelaySchedule<T>(Expression<Action<T>> action, TimeSpan span)
        {
            var jobId = BackgroundJob.Schedule(action, span);
            return jobId;
        }

        /// <summary>
        /// 添加或者更新定时任务
        /// </summary>
        public void AddRecurrentSchedule<T>(Expression<Action<T>> action, string cron)
        {
            RecurringJob.AddOrUpdate(action, cron, TimeZoneInfo.Local);
        }

        /// <summary>
        /// 添加或者更新定时任务
        /// </summary>
        public void AddRecurrentSchedule<T>(string recurrentJobId, Expression<Action<T>> action, string cron)
        {
            RecurringJob.AddOrUpdate(recurrentJobId, action, cron, TimeZoneInfo.Local);
        }

        /// <summary>
        /// 删除定时任务
        /// </summary>
        /// <param name="recurrentJobId">定时任务id</param>
        public void DeleteRecurrentSchedule(string recurrentJobId)
        {
            RecurringJob.RemoveIfExists(recurrentJobId);
        }

        /// <summary>
        /// 添加入栈
        /// </summary>
        public string AddEnqueue<T>(Expression<Action<T>> action)
        {
            
            var jobId = BackgroundJob.Enqueue(action);
            return jobId;
        }
        /// <summary>
        /// 
        /// </summary>
        public void AddEnqueue(Expression<Action> action)
        {
            BackgroundJob.Enqueue(action);
        }
    }
}