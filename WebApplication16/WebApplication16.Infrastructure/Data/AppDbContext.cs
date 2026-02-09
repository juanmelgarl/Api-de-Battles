using Microsoft.EntityFrameworkCore;
using WebApplication16.Domain.Entities;

namespace WebApplication16.Infrastructure.Data
{
    public class AppDbContext :   DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
       public DbSet<Battle> Battles { get; set; }   

    }
}
