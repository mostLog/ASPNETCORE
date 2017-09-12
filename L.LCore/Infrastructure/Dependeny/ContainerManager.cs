using Autofac;
using Autofac.Core.Lifetime;
using System;

namespace L.LCore.Infrastructure.Dependeny
{
    public static class ContainerManager
    {
        private static IContainer _container;

        public static IContainer Container { get => _container; }

        public static void SetContainer(IContainer container)
        {
            _container = container;
        }

        public static T Resolve<T>(string key = "", ILifetimeScope scope = null) where T : class
        {
            if (scope == null)
            {
                scope = Scope();
            }
            if (string.IsNullOrEmpty(key))
            {
                return scope.Resolve<T>();
            }
            return scope.ResolveKeyed<T>(key);
        }

        public static ILifetimeScope Scope()
        {
            try
            {
                return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
            catch (Exception)
            {
                return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
        }
    }
}