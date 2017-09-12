namespace L.Domain.Base
{
    /// <summary>
    /// 实体接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}