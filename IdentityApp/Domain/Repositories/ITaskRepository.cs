using IdentityApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace IdentityApp.Domain.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskItem> GetByIdAsync(Guid id);
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(TaskItem task);
    }
}
