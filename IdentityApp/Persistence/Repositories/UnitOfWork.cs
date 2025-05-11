using IdentityApp.Domain.Repositories;
using IdentityApp.Persistence.Contexts;
using System.Threading.Tasks;
using System.Threading;
using TaskManagement.Domain.Repositories;

namespace TaskManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _context;

        public ITaskRepository Tasks { get; }

        public UnitOfWork(SqlServerContext context, ITaskRepository taskRepository)
        {
            _context = context;
            Tasks = taskRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
