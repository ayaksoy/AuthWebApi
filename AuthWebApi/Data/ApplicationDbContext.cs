using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}