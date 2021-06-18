using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSHogwartz.Repository.Models;

namespace WSHogwartz.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Application> Applications { get; set; }
    }
}
