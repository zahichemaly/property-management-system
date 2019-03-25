using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagementAPI.Entities
{
    public class DbInfoContext : DbContext
    {
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Apartment> Apartments { get; set; }

        public DbInfoContext(DbContextOptions<DbInfoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
