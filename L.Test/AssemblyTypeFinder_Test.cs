using L.LCore.Infrastructure.Dependeny;
using L.LCore.Infrastructure.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace L.Test
{
    [TestClass]
    public class AssemblyTypeFinder_Test
    {
        [TestMethod]
        public void GetAssemblys()
        {
            var a = new AssemblyTypeFinder();
            var assemblys=a.GetAssemblys();
            
        }
        [TestMethod]
        public void FindTypeList()
        {

            var a = new AssemblyTypeFinder();
            List<Type> typeList = new List<Type>();

            var assemblys = a.GetAssemblys();
            foreach (var assembly in assemblys)
            {
                var types = assembly.GetTypes();
       
                typeList.AddRange(assembly
                    .GetTypes()
                    .Where(c => c.GetTypeInfo().GetInterfaces().Any(p => p== typeof(IDependencyRegistrar)))
                    .ToList());
            }
            
        }
    }
}
