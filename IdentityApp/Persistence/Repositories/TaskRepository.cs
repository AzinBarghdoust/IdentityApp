using IdentityApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using IdentityApp.Domain.Repositories;
using IdentityApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly SqlServerContext _context;

        public TaskRepository(SqlServerContext context)
        {
            _context = context;
        }
        public async Task<TaskItem> GetByIdAsync(Guid id)
        => await _context.Tasks.FindAsync(id);

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
            => await _context.Tasks.ToListAsync();

        public async Task AddAsync(TaskItem task)
            => await _context.Tasks.AddAsync(task);

        public Task UpdateAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TaskItem task)
        {
            _context.Tasks.Remove(task);
            return Task.CompletedTask;
        }

    }
}
