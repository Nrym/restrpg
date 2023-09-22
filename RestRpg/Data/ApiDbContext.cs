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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Amount = 3,
                    Name = "Small Mana potion",
                    Price = 20
                }, new Item
                {
                    Id = 2,
                    Amount = 3,
                    Name = "Small Life potion",
                    Price = 20
                }, new Item
                {
                    Id = 3,
                    Amount = 3,
                    Name = "Light Mana potion",
                    Price = 55
                }
                );
        }
    }
}
