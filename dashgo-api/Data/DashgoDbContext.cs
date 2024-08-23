using dashgo_api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace dashgo_api.Data
{
    public class DashgoDbContext : DbContext
    {
        public DashgoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions){}

        public DbSet<Property> Properties { get; set; }
    }
}
