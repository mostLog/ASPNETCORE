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
        IServiceProvider ConfigureServices(IServiceCollection services);
    }
}
