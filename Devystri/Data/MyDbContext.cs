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
        public DbSet<UserGroup> Users { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<IoT> Iots { get; set; }
        public DbSet<WebSites> WebSites { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<OSStats> OSs{ get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            // Map entities to tables  
            modelBuilder.Entity<UserGroup>().ToTable("UserGroups");
            modelBuilder.Entity<Application>().ToTable("Applications");
            modelBuilder.Entity<IoT>().ToTable("Iot");
            modelBuilder.Entity<WebSites>().ToTable("WebSites");
            modelBuilder.Entity<Section>().ToTable("Sections");
            modelBuilder.Entity<Newsletter>().ToTable("Newsletters");
            modelBuilder.Entity<OSStats>().ToTable("OSStats");
            modelBuilder.Entity<Visits>().ToTable("Visits");

            // Configure Primary Keys  
            modelBuilder.Entity<UserGroup>().HasKey(ug => ug.Id).HasName("PK_User");
            modelBuilder.Entity<Application>().HasKey(ug => ug.Id).HasName("PK_Applications");
            modelBuilder.Entity<IoT>().HasKey(ug => ug.Id).HasName("PK_IoTs");
            modelBuilder.Entity<WebSites>().HasKey(ug => ug.Id).HasName("PK_WebSites");
            modelBuilder.Entity<Section>().HasKey(ug => ug.Id).HasName("PK_Sections");
            modelBuilder.Entity<Newsletter>().HasKey(ug => ug.Id).HasName("PK_Newsletters");
            modelBuilder.Entity<OSStats>().HasKey(ug => ug.Id).HasName("PK_Newsletters");
            modelBuilder.Entity<Visits>().HasKey(ug => ug.Id).HasName("PK_Visits");

            // Configure indexes  
            modelBuilder.Entity<UserGroup>().HasIndex(p => p.Email).IsUnique().HasDatabaseName("Idx_Email");
            modelBuilder.Entity<Application>().HasIndex(p => p.Name).IsUnique().HasDatabaseName("Idx_Name");
            modelBuilder.Entity<WebSites>().HasIndex(p => p.Name).IsUnique().HasDatabaseName("Idx_Name");
            modelBuilder.Entity<IoT>().HasIndex(p => p.Name).IsUnique().HasDatabaseName("Idx_Name");
            modelBuilder.Entity<Section>().HasIndex(p => p.ProjectId).IsUnique().HasDatabaseName("Idx_ProjectId");
            modelBuilder.Entity<Newsletter>().HasIndex(p => p.Id).IsUnique().HasDatabaseName("Idx_ProjectId");
            modelBuilder.Entity<OSStats>().HasIndex(p => p.Id).IsUnique().HasDatabaseName("Idx_StatId");
            modelBuilder.Entity<Visits>().HasIndex(p => p.Id).IsUnique().HasDatabaseName("Idx_StatId");

            // Configure columns users
            modelBuilder.Entity<UserGroup>().Property(ug => ug.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<UserGroup>().Property(ug => ug.Email).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<UserGroup>().Property(ug => ug.Password).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<UserGroup>().Property(ug => ug.CreationDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<UserGroup>().Property(ug => ug.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

            // Configure columns Applications
            modelBuilder.Entity<Application>().Property(ug => ug.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<Application>().Property(ug => ug.Name).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Application>().Property(ug => ug.Description).HasColumnType("nvarchar(500)").IsRequired();
            modelBuilder.Entity<Application>().Property(ug => ug.IsOnAppStore).HasColumnType("int(1)").IsRequired();
            modelBuilder.Entity<Application>().Property(ug => ug.IsOnPlayStore).HasColumnType("int(1)").IsRequired();
            modelBuilder.Entity<Application>().Property(ug => ug.AppLogoName).HasColumnType("nvarchar(200)").IsRequired();
            modelBuilder.Entity<Application>().Property(ug => ug.PresentationRessource).HasColumnType("nvarchar(200)").IsRequired();
            modelBuilder.Entity<Application>().Property(ug => ug.Stat).HasColumnType("int").IsRequired();

            //Configure columns WebSites
            modelBuilder.Entity<WebSites>().Property(ug => ug.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<WebSites>().Property(ug => ug.Name).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<WebSites>().Property(ug => ug.Description).HasColumnType("nvarchar(500)").IsRequired();
            modelBuilder.Entity<WebSites>().Property(ug => ug.AppLogoName).HasColumnType("nvarchar(200)").IsRequired();
            modelBuilder.Entity<WebSites>().Property(ug => ug.PresentationRessource).HasColumnType("nvarchar(200)").IsRequired();
            modelBuilder.Entity<WebSites>().Property(ug => ug.Link).HasColumnType("nvarchar(250)").IsRequired();
            modelBuilder.Entity<WebSites>().Property(ug => ug.Stat).HasColumnType("int").IsRequired();

            //Configure columns Iots
            modelBuilder.Entity<IoT>().Property(ug => ug.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<IoT>().Property(ug => ug.Name).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<IoT>().Property(ug => ug.Description).HasColumnType("nvarchar(500)").IsRequired();
            modelBuilder.Entity<IoT>().Property(ug => ug.Price).HasColumnType("float").IsRequired();
            modelBuilder.Entity<IoT>().Property(ug => ug.PresentationRessource).HasColumnType("nvarchar(200)").IsRequired();
            modelBuilder.Entity<IoT>().Property(ug => ug.Stat).HasColumnType("int").IsRequired();

            //Configure columns Sections
            modelBuilder.Entity<Section>().Property(ug => ug.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<Section>().Property(ug => ug.Description).HasColumnType("nvarchar(500)").IsRequired();
            modelBuilder.Entity<Section>().Property(ug => ug.Title).HasColumnType("nvarchar(200)").IsRequired();
            modelBuilder.Entity<Section>().Property(ug => ug.ProjectId).HasColumnType("int").IsRequired();

            //Configure columns Newsletter
            modelBuilder.Entity<Newsletter>().Property(ug => ug.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<Newsletter>().Property(ug => ug.Email).HasColumnType("nvarchar(300)").IsRequired();
            modelBuilder.Entity<Newsletter>().Property(ug => ug.Date).HasColumnType("datetime").IsRequired();

            //Configure columns Os
            modelBuilder.Entity<OSStats>().Property(ug => ug.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<OSStats>().Property(ug => ug.OsName).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<OSStats>().Property(ug => ug.Counts).HasColumnType("int").IsRequired();
            modelBuilder.Entity<OSStats>().Property(ug => ug.OsId).HasColumnType("int").IsRequired();

            //Configure columns Visits
            modelBuilder.Entity<Visits>().Property(ug => ug.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<Visits>().Property(ug => ug.Count).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Visits>().Property(ug => ug.Date).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<Visits>().Property(ug => ug.Page).HasColumnType("int").IsRequired();
        }
    }
}

