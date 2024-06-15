using Microsoft.EntityFrameworkCore;
using Stock.Management.Api.Database.Entities;

namespace Stock.Management.Api.Database
{
    public partial class DbStockContext : DbContext
    {

        public DbStockContext(DbContextOptions<DbStockContext> options) : base(options)
        {
        }
        public virtual DbSet<Admin> Admins { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Customerinvestment> Customerinvestments { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Adminid).HasName("admin_pkey");

                entity.ToTable("admin");

                entity.Property(e => e.Adminid).HasColumnName("adminid");
                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User).WithMany(p => p.Admins)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("admin_userid_fkey");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Customerid).HasName("customer_pkey");

                entity.ToTable("customer");

                entity.Property(e => e.Customerid).HasColumnName("customerid");
                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User).WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_userid_fkey");
            });

            modelBuilder.Entity<Customerinvestment>(entity =>
            {
                entity.HasKey(e => e.Investmentid).HasName("customerinvestment_pkey");

                entity.ToTable("customerinvestment");

                entity.Property(e => e.Investmentid).HasColumnName("investmentid");
                entity.Property(e => e.Amount)
                    .HasPrecision(18, 2)
                    .HasColumnName("amount");
                entity.Property(e => e.investmentValue)
                .HasPrecision(18, 2)
                .HasColumnName("investmentvalue");
                entity.Property(e => e.Customerid).HasColumnName("customerid");
                entity.Property(e => e.Productid).HasColumnName("productid");
                entity.Property(e => e.Purchasedate).HasColumnName("purchasedate");

                entity.HasOne(d => d.Customer).WithMany(p => p.Customerinvestments)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customerinvestment_customerid_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.Customerinvestments)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customerinvestment_productid_fkey");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Productid).HasName("product_pkey");

                entity.ToTable("product");

                entity.Property(e => e.Productid).HasColumnName("productid");
                entity.Property(e => e.Maturitydate).HasColumnName("maturitydate");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
                entity.Property(e => e.Price)
                    .HasPrecision(18, 2)
                    .HasColumnName("price");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Userid).HasName("users_pkey");

                entity.ToTable("users");

                entity.HasIndex(e => e.Cpf, "users_cpf_key").IsUnique();

                entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

                entity.Property(e => e.Userid).HasColumnName("userid");
                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");
                entity.Property(e => e.Dateofbirth).HasColumnName("dateofbirth");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
