using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class CafeContext : DbContext
{
    public CafeContext()
    {
    }

    public CafeContext(DbContextOptions<CafeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CafeShop> CafeShops { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Selling> Sellings { get; set; }

    public virtual DbSet<SellingDetail> SellingDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CafeShop>(entity =>
        {
            entity.HasKey(e => e.CafeId).HasName("PK__CafeShop__DD4C137D3B9792E3");

            entity.Property(e => e.CafeId).HasColumnName("CafeID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Address_");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B894C231A1");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Number)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeesId).HasName("PK__Employee__7D09079354A4F9C8");

            entity.Property(e => e.EmployeesId).HasColumnName("EmployeesID");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Idcafe).HasColumnName("IDCafe");
            entity.Property(e => e.Idposition).HasColumnName("IDPosition");
            entity.Property(e => e.Iduser).HasColumnName("IDUser");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);

        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__60BB9A59AB57A528");

            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.Position1)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("Position");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED8483CC4E");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Count).HasColumnName("Count_");
            entity.Property(e => e.IdproductType).HasColumnName("IDProductType");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypeId).HasName("PK__ProductT__A1312F4E0DC7023C");

            entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");
            entity.Property(e => e.ProductType1)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("ProductType");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sales__1EE3C41F806220A7");

            entity.Property(e => e.SaleId).HasColumnName("SaleID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
        });

        modelBuilder.Entity<Selling>(entity =>
        {
            entity.HasKey(e => e.SellingId).HasName("PK__Sellings__4706782F3D0649B5");

            entity.Property(e => e.SellingId).HasColumnName("SellingID");
            entity.Property(e => e.IdcoffeeShop).HasColumnName("IDCoffeeShop");
            entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");
            entity.Property(e => e.Idsale).HasColumnName("IDSale");
            entity.Property(e => e.SaleDate).HasColumnType("date");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

           

            entity.HasOne(d => d.IdsaleNavigation).WithMany(p => p.Sellings)
                .HasForeignKey(d => d.Idsale)
                .HasConstraintName("FK__Sellings__IDSale__628FA481");
        });

        modelBuilder.Entity<SellingDetail>(entity =>
        {
            entity.HasKey(e => e.SellingDetailId).HasName("PK__SellingD__E694FF873A297985");

            entity.Property(e => e.SellingDetailId).HasColumnName("SellingDetailID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Count).HasColumnName("Count_");
            entity.Property(e => e.Idproduct).HasColumnName("IDProduct");
            entity.Property(e => e.Idselling).HasColumnName("IDSelling");

           

            entity.HasOne(d => d.IdsellingNavigation).WithMany(p => p.SellingDetails)
                .HasForeignKey(d => d.Idselling)
                .HasConstraintName("FK__SellingDe__IDSel__656C112C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC70D2E35B");

            entity.HasIndex(e => e.Login, "UQ__Users__D00D060E2D03892B").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Idrole).HasColumnName("IDRole");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Login_");
            entity.Property(e => e.Password)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("Password_");

            entity.HasOne(d => d.IdroleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Idrole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__IDRole__4E88ABD4");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__UserRole__8AFACE3A5FF6A05C");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Role)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
