using Microsoft.EntityFrameworkCore;
using CarmelOrders.Core.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CarmelOrders.Data.Context
{
    public class CarmelDbContext : DbContext
    {
        public CarmelDbContext(DbContextOptions<CarmelDbContext> options)
            : base(options)
        {
        }

        public DbSet<הזמנה> הזמנות { get; set; }
        public DbSet<Customer> לקוחות { get; set; }
        public DbSet<Formula> נוסחאות { get; set; }
        public DbSet<Stock> מלאי { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<הזמנה>(entity =>
            {
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

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.מזהה_לקוח);
                entity.Property(e => e.שם_חברה).IsRequired().HasMaxLength(100);
                entity.Property(e => e.איש_קשר).HasMaxLength(100);
                entity.Property(e => e.טלפון).HasMaxLength(20);
                entity.Property(e => e.כתובת).HasMaxLength(200);
                entity.Property(e => e.אימייל).HasMaxLength(100);
                entity.Property(e => e.הערות).HasMaxLength(500);
            });

            modelBuilder.Entity<Formula>(entity =>
            {
                entity.HasKey(e => e.מזהה_נוסחה);
                entity.Property(e => e.קוד_גוון).IsRequired().HasMaxLength(50);
                entity.Property(e => e.שם_גוון).HasMaxLength(100);
                entity.Property(e => e.נוסחה).IsRequired();
                entity.Property(e => e.הערות).HasMaxLength(500);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.מזהה_מלאי);
                entity.Property(e => e.קוד_גוון).IsRequired().HasMaxLength(50);
                entity.Property(e => e.כמות_במלאי).HasPrecision(10, 2);
                entity.Property(e => e.כמות_מינימום).HasPrecision(10, 2);
                entity.Property(e => e.הערות).HasMaxLength(500);
            });
        }
    }
}