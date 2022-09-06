using CustomerCartMS.Database.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCartMS.Database
{
    public class CustomerCartDbContext : DbContext
    {
        public CustomerCartDbContext(DbContextOptions<CustomerCartDbContext> options)
            :base(options)
        {              
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCartItem> CustomerCartItems { get; set; }
    }
}
