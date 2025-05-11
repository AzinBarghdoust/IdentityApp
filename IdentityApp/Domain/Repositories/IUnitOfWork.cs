using IdentityApp.Domain.Repositories;
using System.Threading.Tasks;
using System.Threading;

namespace TaskManagement.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ITaskRepository Tasks { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
