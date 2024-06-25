using System;
using System.Collections.Generic;
using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BulkyBook.DataAccess;

public partial class BulkyBookWebDbContext : DbContext
{
    public BulkyBookWebDbContext()
    {
    }

    public BulkyBookWebDbContext(DbContextOptions<BulkyBookWebDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CoverType> CoverType { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NPHQIK2\\SQLEXPRESS;Database=BulkyBookWeb_db;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Category>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC078095313A");

        //    entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
        //    entity.Property(e => e.Name)
        //        .HasMaxLength(200)
        //        .IsUnicode(false);
        //});

        //modelBuilder.Entity<CoverType>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PK__CoverTyp__3214EC071EC4A638");

        //    entity.ToTable("CoverType");

        //    entity.Property(e => e.Name)
        //        .HasMaxLength(500)
        //        .IsUnicode(false);
        //});

        //modelBuilder.Entity<Product>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PK__Product__3214EC077DC5BD70");

        //    entity.ToTable("Product");

        //    entity.Property(e => e.Author)
        //        .HasMaxLength(500)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Description)
        //        .HasMaxLength(1000)
        //        .IsUnicode(false);
        //    entity.Property(e => e.ImageUrl)
        //        .HasMaxLength(1000)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Isbn)
        //        .HasMaxLength(500)
        //        .IsUnicode(false)
        //        .HasColumnName("ISBN");
        //    entity.Property(e => e.ListPrice).HasColumnType("decimal(18, 0)");
        //    entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        //    entity.Property(e => e.Price100).HasColumnType("decimal(18, 0)");
        //    entity.Property(e => e.Price50).HasColumnType("decimal(18, 0)");
        //    entity.Property(e => e.Title)
        //        .HasMaxLength(500)
        //        .IsUnicode(false);

        //    entity.HasOne(d => d.Category).WithMany(p => p.Products)
        //        .HasForeignKey(d => d.CategoryId)
        //        .HasConstraintName("FK__Product__Categor__02FC7413");

        //    entity.HasOne(d => d.CoverType).WithMany(p => p.Products)
        //        .HasForeignKey(d => d.CoverTypeId)
        //        .HasConstraintName("FK__Product__CoverTy__03F0984C");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
