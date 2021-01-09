using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace webApi_doanchuyennganh.Models
{
    public partial class doanchuyennganhContext : DbContext
    {
        public doanchuyennganhContext()
        {
        }

        public doanchuyennganhContext(DbContextOptions<doanchuyennganhContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<TypeProduct> TypeProducts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NRF3BB7\\SQLEXPRESS;Database=doanchuyennganh;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("bills");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateOrder)
                    .HasColumnType("date")
                    .HasColumnName("date_order");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.Payment)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("payment");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bills_customer");
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.ToTable("bill_detail");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdBill).HasColumnName("id_bill");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.HasOne(d => d.IdBillNavigation)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.IdBill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bill_detail_bills");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bill_detail_products");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Note)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.New)
                    .HasColumnName("new")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PromotionPrice).HasColumnName("promotion_price");

                entity.Property(e => e.Unit)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("unit");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdType)
                    .HasConstraintName("FK_products_type_products");
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.ToTable("slide");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.Property(e => e.Show).HasColumnName("show");
            });

            modelBuilder.Entity<TypeProduct>(entity =>
            {
                entity.ToTable("type_products");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Quyenhan).HasColumnName("quyenhan");

                entity.Property(e => e.RememberToken)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("remember_token");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
