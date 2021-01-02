﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Data.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AppLogoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("IsOnAppStore")
                        .HasColumnType("int(1)");

                    b.Property<int>("IsOnPlayStore")
                        .HasColumnType("int(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PresentationRessource")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Stat")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Applications");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("Idx_Name");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Data.Models.IoT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PresentationRessource")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Stat")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_IoTs");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("Idx_Name");

                    b.ToTable("Iot");
                });

            modelBuilder.Entity("Data.Models.Newsletter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id")
                        .HasName("PK_Newsletters");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("Idx_ProjectId");

                    b.ToTable("Newsletters");
                });

            modelBuilder.Entity("Data.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id")
                        .HasName("PK_Sections");

                    b.HasIndex("ProjectId")
                        .IsUnique()
                        .HasDatabaseName("Idx_ProjectId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Data.Models.Statistics.OSStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Counts")
                        .HasColumnType("int");

                    b.Property<int>("OsId")
                        .HasColumnType("int");

                    b.Property<string>("OsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_Newsletters");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("Idx_StatId");

                    b.ToTable("OSStats");
                });

            modelBuilder.Entity("Data.Models.Statistics.Visits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("Page")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Visits");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("Idx_StatId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("Data.Models.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_User");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("Idx_Email");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("Data.Models.WebSites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AppLogoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PresentationRessource")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Stat")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_WebSites");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("Idx_Name");

                    b.ToTable("WebSites");
                });
#pragma warning restore 612, 618
        }
    }
}
