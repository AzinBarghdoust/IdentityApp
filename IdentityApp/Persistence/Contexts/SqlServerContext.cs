using IdentityApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Persistence.Contexts
{
    public class SqlServerContext : IdentityDbContext<User>
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) 
        {
            
        }
        public DbSet<TaskItem> Tasks { get; set; }

    }
}
