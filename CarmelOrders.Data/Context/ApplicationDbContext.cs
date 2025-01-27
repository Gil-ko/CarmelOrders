using Microsoft.EntityFrameworkCore;
using CarmelOrders.Core.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CarmelOrders.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<הזמנה> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Formula> Formulas { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<הזמנה>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(e => e.מספר_הזמנה);
                entity.Property(e => e.מספר_הזמנה).ValueGeneratedOnAdd();
                entity.Property(e => e.שם_חברה).IsRequired().HasMaxLength(100);
                entity.Property(e => e.מוצר).IsRequired().HasMaxLength(100);
                entity.Property(e => e.כמות).HasPrecision(10, 2);
                entity.Property(e => e.גוון).HasMaxLength(50);
                entity.Property(e => e.הערות).HasMaxLength(500);
                entity.Property(e => e.מספר_תעודת_משלוח).HasMaxLength(50);
                entity.Property(e => e.תאריך_הזמנה).HasDefaultValueSql("GETDATE()");
            });

            // הגדרות נוספות למודלים האחרים יבואו כאן
        }
    }
}