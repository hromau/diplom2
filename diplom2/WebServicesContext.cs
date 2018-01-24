using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diplom2
{
    public class WebServicesContext:DbContext
    {
        public DbSet<Events> Events { get; set; }
        public DbSet<TableOfStatements> TableOfStatements { get; set; }
        public DbSet<UserTables> UserTables { get; set; }
        public DbSet<TimeTables> TimeTables { get; set; }

        public WebServicesContext(DbContextOptions<WebServicesContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LIGHTNINGS;Initial Catalog=WebServices.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

    }
}
