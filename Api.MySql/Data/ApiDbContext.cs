using Api.MySql.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.MySql.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Estado> Estados { get; set; }
    }
}
