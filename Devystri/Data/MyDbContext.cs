using Data.Models;
using Data.Models.Statistics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<IoT> Iots { get; set; }
        public DbSet<WebSites> WebSites { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<OSStats> OSs{ get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Visits> Visits { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
        }
    }
}

