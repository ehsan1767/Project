
namespace StudentEvaluation1.Services.Contracts
{
    public interface UnitOfWork
    {
        Task SaveAsync();
        void Save();
    }
}
