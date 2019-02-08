using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project3_Site_MVC.DataAccess
{
    public partial class admin_order_processContext : DbContext
    {
        public admin_order_processContext()
        {
        }

        public admin_order_processContext(DbContextOptions<admin_order_processContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orderhistory> Orderhistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Orderhistory>(entity =>
            {
                entity.HasIndex(e => e.OrderNumber)
                    .HasName("order_number")
                    .IsUnique();

                entity.Property(e => e.DateOrder).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Products);

                entity.Property(e => e.StoreName);
            });
        }
    }
}
