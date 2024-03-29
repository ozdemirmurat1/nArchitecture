﻿using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;  // SqlServer dan geliyor
using System.Reflection;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }

        public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;

            /*Database.EnsureCreated() bir Entity Framework Core yöntemidir. Bu yöntem, var olan bir veritabanı yoksa bir veritabanı oluşturur. Veritabanı modelini kullanan bir DbContext sınıfında çağrıldığında, Entity Framework Core otomatik olarak veritabanının var olup olmadığını kontrol eder ve var olmadığında veritabanını oluşturur.  */

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<Brand>(a =>
            //{
            //    a.ToTable("Brands").HasKey(k => k.Id);
            //    a.Property(p => p.Id).HasColumnName("Id");
            //    a.Property(p => p.Name).HasColumnName("Name");
            //    a.HasMany(p => p.Models);
            //});

            //modelBuilder.Entity<Model>(a =>
            //{
            //    a.ToTable("Models").HasKey(k => k.Id);
            //    a.Property(p => p.Id).HasColumnName("Id");
            //    a.Property(p => p.BrandId).HasColumnName("BrandId");
            //    a.Property(p=>p.Name).HasColumnName("Name");
            //    a.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
            //    a.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
            //    a.HasOne(p => p.Brand);
            //});


            //Brand[] brandEntitySeeds = { new(1, "BMW"), new(2, "Mercedes") };
            //modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);

            //Model[] modelEntitySeeds = { new(1, 1, "Series 4", 1500, ""), new(2, 1, "Series 3", 1200, ""), new(3,2, "A180", 1000, "") };
            //modelBuilder.Entity<Model>().HasData(modelEntitySeeds);

           
        }
    }
}
