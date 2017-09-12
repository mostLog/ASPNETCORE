using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace L.LCore.Infrastructure.Dependeny
{
    /// <summary>
    ///
    /// </summary>
    public interface IStartUp
    {
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        void ConfigureServices(IServiceCollection services);

        /// <summary>
        /// 配置请求管道
        /// </summary>
        /// <param name="app"></param>
        void Configure(IApplicationBuilder app);

        /// <summary>
        /// 序号
        /// </summary>
        int Order { get; set; }
    }
}