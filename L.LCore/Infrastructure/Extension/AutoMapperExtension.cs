using AutoMapper;

namespace L.LCore.Infrastructure.Extension
{
    /// <summary>
    /// 实体间映射扩展
    /// </summary>
    public static class AutoMapperExtension
    {
        public static T MapTo<T>(this object obj)
        {
            if (obj == null) return default(T);
            Mapper.Initialize(cfg => cfg.CreateMap(obj.GetType(), typeof(T)));
            return Mapper.Map<T>(obj);
        }
    }
}