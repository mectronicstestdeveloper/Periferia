using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PeriferiaData.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookCategory> BookCategory { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=systest-dev-wm.database.windows.net;Initial Catalog=PeriferiaDB;User ID=ServerAdmin;Password=s1s4dmin.;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book", "Book");

                entity.Property(e => e.BookId)
                    .HasColumnName("BookID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.BookPrice).HasColumnType("money");

                entity.Property(e => e.BookReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.EditorialId).HasColumnName("EditorialID");

                entity.HasOne(d => d.Editorial)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.EditorialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Editorial");
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.ToTable("BookCategory", "Book");

                entity.Property(e => e.BookCategoryId)
                    .HasColumnName("BookCategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookCategory)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookCategory_Book");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BookCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookCategory_Category");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "DataMaster");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.ToTable("Editorial", "DataMaster");

                entity.Property(e => e.EditorialId)
                    .HasColumnName("EditorialID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EditorialName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
