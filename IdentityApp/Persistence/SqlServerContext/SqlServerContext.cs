using IdentityApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Persistence.SqlServerContext
{
    public class SqlServerContext : IdentityDbContext<User>
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) 
        {
            
        }
    }
}
