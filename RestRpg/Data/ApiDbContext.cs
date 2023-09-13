using Microsoft.EntityFrameworkCore;
using RestRpg.Models;

namespace RestRpg.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
    }
}
