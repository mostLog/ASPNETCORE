using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using System.Runtime.Loader;

namespace L.LCore.Infrastructure.Reflection
{
    public class AssemblyTypeFinder : ITypeFinder
    {
        /// <summary>
        /// 获取所有实现T类型的类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<Type> FindTypesByInterface<T>()
        {
            List<Type> typeList = new List<Type>();
            Type type = typeof(T);
            var assemblys = GetAssemblys();
            foreach (var assembly in assemblys)
            {
                typeList.AddRange(assembly
                    .GetTypes()
                    .Where(c => c.GetTypeInfo().GetInterfaces().Contains(typeof(T))||(c.GetTypeInfo().BaseType!=null&&c.GetTypeInfo().BaseType==typeof(T)))
                    .ToList());
            }

            return typeList;
        }
        /// <summary>
        /// 获取所有程序集
        /// </summary>
        /// <returns></returns>
        public IList<Assembly> GetAssemblys()
        {

            var list = new List<Assembly>();
            var deps = DependencyContext.Default;
            var libs = deps.CompileLibraries.Where(lib => !lib.Serviceable && lib.Type != "package");//排除所有的系统程序集、Nuget下载包
            foreach (var lib in libs)
            {
                try
                {
                    var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                    list.Add(assembly);
                }
                catch (Exception)
                {
                    
                }
            }
            return list;
        }
    }
}
