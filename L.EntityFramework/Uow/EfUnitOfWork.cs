using Microsoft.EntityFrameworkCore.Storage;

namespace L.EntityFramework.Uow
{
    public class EFUnitOfWork: UnitOfWorkBase
    {
        private readonly IDbContext _db;

        public EFUnitOfWork(IDbContext db)
        {
            _db = db;
        }
        public override void Begin(UnitOfWorkOptions options)
        {
            if (options.IsTransactional)
            {
                CurrentTransaction = _db.CreateTransaction();
            }
        }
        public override void Complete()
        {
            _db.SaveChanges();
            if (CurrentTransaction!=null)
            {
                try
                {
                    CurrentTransaction.Commit();
                }
                catch (System.Exception)
                {

                    CurrentTransaction.Rollback();
                }finally
                {
                    CurrentTransaction.Dispose();
                }
            }
        }
        public IDbContextTransaction CurrentTransaction { get; set; }
    }
}
