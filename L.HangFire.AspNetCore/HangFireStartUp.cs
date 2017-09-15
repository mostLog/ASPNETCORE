using Hangfire;
using L.LCore.Infrastructure.Dependeny;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace L.HangFire
{
    public class HangFireStartUp : IStartUp
    {
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public void ConfigureServices(IServiceCollection services)
        {
            //添加HangFire
            services.AddHangfire(h => h.UseSqlServerStorage("data source=.;initial catalog=CoreTestHangFire;Integrated Security=true"));
        }

        /// <summary>
        /// 配置请求中间件
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }

        /// <summary>
        /// 序号
        /// </summary>
        public int Order
        {
            get;
            set;
        } = 1;
    }
}