namespace L.Domain.Base
{
    /// <summary>
    /// int类型主键
    /// </summary>
    public class BaseEntity<T> : IEntity<T>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public T Id
        {
            get;
            set;
        }
    }
}