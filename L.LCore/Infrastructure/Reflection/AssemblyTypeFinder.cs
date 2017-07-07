using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace L.LCore.Infrastructure.Reflection
{
    public class AssemblyTypeFinder: ITypeFinder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<Type> FindTypeList<T>()
        {
            List<Type> typeList = new List<Type>();
            Type type = typeof(T);
            var assemblys=GetAssemblys();
            foreach (var assembly in assemblys)
            {
                typeList.AddRange(assembly
                    .GetTypes()
                    .Where(c => c.GetTypeInfo().GetInterfaces().Any(p => p.GetType() == typeof(T)))
                    .ToList());
            }

            return typeList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IList<Assembly> GetAssemblys()
        {
            return new List<Assembly>() {


            };
        }
    }
}
