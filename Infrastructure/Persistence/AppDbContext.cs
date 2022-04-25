using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region Catalogs
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            #region Key config
            modelBuilder.Entity<Brand>()
                .HasKey(b => b.Id)
                .HasName("pk_brand");
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id)
                .HasName("pk_category");
            modelBuilder.Entity<Supplier>()
               .HasKey(s => s.Id)
               .HasName("pk_supplier");
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id)
                .HasName("pk_product");
            modelBuilder.Entity<Invoice>()
                .HasKey(p => p.Id)
                .HasName("pk_invoice");
            modelBuilder.Entity<InvoiceDetail>()
                .HasKey(p => p.Id)
                .HasName("pk_invoicedetail");
            #endregion

            #region Index config
            modelBuilder.Entity<Brand>()
                .HasIndex(b => b.BarandName)
                .IsUnique()
                .HasDatabaseName("ix_brand");
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();
            modelBuilder.Entity<Supplier>()
               .HasIndex(s => s.SuplierName)
               .IsUnique()
               .HasDatabaseName("ix_SuplierName");
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProductName)
                .IsUnique()
                .HasDatabaseName("ix_ProductName");
            #region

            #region Seed Data
            modelBuilder.Entity<Brand>().HasData(
                new Brand { BarandName="Sony", ShortName="SNY" },
                new Brand { BarandName = "Daewo", ShortName = "DW" },
                new Brand { BarandName = "LG Electronics", ShortName = "LG" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { Name= "Laundry", Description="Laundry Machines"},
                new Category { Name = "Electronics", Description = "TV, IoT, ..." },
                new Category { Name = "Gaming", Description = "Consoles, Games, Accesories" },
                new Category { Name = "Kitchen", Description = "Friges, oven, Stove, .." }
            );
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SuplierName="Target", Address="123 Somewhere St., some state, usa." },
                new Supplier { SuplierName = "Walmart", Address = "123 Somewhere St., some state, usa." },
                new Supplier { SuplierName = "Costco", Address = "123 Somewhere St., some state, usa." }
            );
            #endregion
        }
    }
}
