namespace L.EntityFramework.Uow
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        public virtual void Begin(UnitOfWorkOptions options)
        {
            
        }

        public virtual void Complete()
        {
           
        }
    }
}
