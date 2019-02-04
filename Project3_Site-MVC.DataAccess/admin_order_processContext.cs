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

        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<Orderhistory> Orderhistory { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'admin_order_process.password_resets'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.Property(e => e.Migration).IsUnicode(false);
            });

            modelBuilder.Entity<Orderhistory>(entity =>
            {
                entity.HasIndex(e => e.OrderNumber)
                    .HasName("order_number")
                    .IsUnique();

                entity.Property(e => e.DateOrder).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Products).IsUnicode(false);

                entity.Property(e => e.StoreName).IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("users_email_unique")
                    .IsUnique();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.RememberToken).IsUnicode(false);
            });
        }
    }
}
