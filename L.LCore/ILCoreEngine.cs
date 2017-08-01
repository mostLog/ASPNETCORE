using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace L.LCore
{
    public interface ILCoreEngine
    {
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        IServiceProvider ConfigureServices(IServiceCollection services, IConfiguration configuration);
        /// <summary>
        /// 配置请求组件
        /// </summary>
        /// <param name="app"></param>

        void ConfigureRequestMiddleware(IApplicationBuilder app);
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="services"></param>
        void Initial(IServiceCollection services);
    }
}
