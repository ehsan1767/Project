using StudentEvaluation1.Services.Contracts;

namespace StudentEvaluation1.Persistanse.EF
{
    public class EFUnitOfWork : UnitOfWork
    {
        private readonly EFDataContext dbContext;

        public EFUnitOfWork(EFDataContext context)
        {
            dbContext = context;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
             await dbContext.SaveChangesAsync();
        }
    }
}
