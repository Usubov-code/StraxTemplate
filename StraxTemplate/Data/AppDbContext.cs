using Microsoft.EntityFrameworkCore;
using StraxTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraxTemplate.Data
{
    public class AppDbContext:DbContext
    {
        

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DesingType> DesingTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users{ get; set; }


    }
}
