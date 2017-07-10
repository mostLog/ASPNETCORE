namespace L.EntityFramework.Uow
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 工作单元开始
        /// </summary>
        void Begin(UnitOfWorkOptions options);
        /// <summary>
        /// 工作单元结束
        /// </summary>
        void Complete();
    }
}
