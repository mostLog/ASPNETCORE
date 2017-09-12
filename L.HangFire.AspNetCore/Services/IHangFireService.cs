using System;
using System.Linq.Expressions;

namespace L.HangFire.AspNetCore.Services
{
    /// <summary>
    /// HangFire服务接口
    /// </summary>
    public interface IHangFireService
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="span"></param>
        /// <returns></returns>
        string AddDelaySchedule<T>(Expression<Action<T>> action, TimeSpan span);

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="cron"></param>
        void AddRecurrentSchedule<T>(Expression<Action<T>> action, string cron);

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="recurrentJobId"></param>
        /// <param name="action"></param>
        /// <param name="cron"></param>
        void AddRecurrentSchedule<T>(string recurrentJobId, Expression<Action<T>> action, string cron);

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        string AddEnqueue<T>(Expression<Action<T>> action);

        void DeleteRecurrentSchedule(string recurrentJobId);
    }
}