using L.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace L.EntityFramework.Extension
{
    public static class ModelBuilderExtenions
    {
        private static IEnumerable<Type> GetMappingTypes(this Assembly assembly, Type mappingInterface)
        {
            return assembly
                .GetTypes()
                .Where(x =>
                    !x.GetTypeInfo().IsAbstract &&
                    x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));
        }
        /// <summary>
        /// 从程序集动态加载实体配置文件
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="assembly"></param>

        public static void AddEntityConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var mappingTypes = assembly.GetMappingTypes(typeof(IEntityMappingConfiguration<>));

            foreach (var config in mappingTypes.Select(Activator.CreateInstance).Cast<IEntityMappingConfiguration>())
                config.Configuration(modelBuilder);
        }

        
    }
}
