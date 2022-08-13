using Microsoft.EntityFrameworkCore;
using ShoppingApi.Database.DataModel;

namespace ShoppingApi.Database
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options)
            :base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }
    }
}
