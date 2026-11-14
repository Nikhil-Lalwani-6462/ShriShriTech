using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShriShriTech.Models;

namespace ShriShriTech.Data;

public partial class ShriShriTechContext : DbContext
{
    public ShriShriTechContext()
    {
    }

    public ShriShriTechContext(DbContextOptions<ShriShriTechContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryBrand> CategoryBrands { get; set; }

    public virtual DbSet<ClientAdmin> ClientAdmins { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SaleBill> SaleBills { get; set; }

    public virtual DbSet<SaleItem> SaleItems { get; set; }

    public virtual DbSet<TechUser> TechUsers { get; set; }

    public virtual DbSet<UserBrand> UserBrands { get; set; }

    public virtual DbSet<UserCategory> UserCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-13KNVUE\\SQLEXPRESS;Database=SHRISHRITECH;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Bid);

            entity.ToTable("Brand");

            entity.Property(e => e.Bid).HasColumnName("BId");
            entity.Property(e => e.Bname).HasColumnName("BName");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__Category__6A1C8AFABDF1CF43");

            entity.ToTable("Category");

            entity.Property(e => e.CreatedAt).HasColumnName("CreatedAT");
        });

        modelBuilder.Entity<CategoryBrand>(entity =>
        {
            entity.HasKey(e => e.Cbid).HasName("PK__Category__A990345B2181AD3B");

            entity.ToTable("Category_Brand");

            entity.Property(e => e.Cbid).HasColumnName("CBId");
            entity.Property(e => e.Bid).HasColumnName("BId");
            entity.Property(e => e.CreatedAt).HasColumnName("CreatedAT");

            entity.HasOne(d => d.BidNavigation).WithMany(p => p.CategoryBrands)
                .HasForeignKey(d => d.Bid)
                .HasConstraintName("FK__Category_Br__BId__440B1D61");

            entity.HasOne(d => d.Cat).WithMany(p => p.CategoryBrands)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK__Category___CatId__4316F928");
        });

        modelBuilder.Entity<ClientAdmin>(entity =>
        {
            entity.ToTable("Client_Admin");

            entity.Property(e => e.ContactNo).HasColumnName("Contact_No");
            entity.Property(e => e.GstNo).HasColumnName("Gst_No");
            entity.Property(e => e.StoreName).HasColumnName("Store_Name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__Product__C5775540EA2964EB");

            entity.ToTable("Product");

            entity.HasIndex(e => e.Model, "UQ__Product__FB104C1368996722").IsUnique();

            entity.Property(e => e.Pid).HasColumnName("PId");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.CatId).HasColumnName("CatID");
            entity.Property(e => e.Isdisplay).HasColumnName("ISDisplay");
            entity.Property(e => e.Model).HasMaxLength(225);
            entity.Property(e => e.Nlc).HasColumnName("NLC");
            entity.Property(e => e.Ton).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Tool).HasMaxLength(225);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.WarehouseQty).HasColumnName("WarehouseQTY");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Product__BrandID__5629CD9C");

            entity.HasOne(d => d.Cat).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK__Product__CatID__5535A963");

            entity.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Product__UserID__5441852A");
        });

        modelBuilder.Entity<SaleBill>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sale_Bil__1EE3C3FF3FBFB65C");

            entity.ToTable("Sale_Bill");

            entity.Property(e => e.CompanyGst)
                .HasMaxLength(1)
                .HasColumnName("CompanyGST");
            entity.Property(e => e.CompanyName).HasMaxLength(1);
            entity.Property(e => e.CustomerCity).HasMaxLength(255);
            entity.Property(e => e.CustomerDistrict).HasMaxLength(255);
            entity.Property(e => e.CustomerEmail).HasMaxLength(255);
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.CustomerState).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.SaleBills)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sale_Bill__UserI__59063A47");
        });

        modelBuilder.Entity<SaleItem>(entity =>
        {
            entity.HasKey(e => e.Sliid).HasName("PK__Sale_Ite__3E5995EA2EC665E9");

            entity.ToTable("Sale_Item");

            entity.Property(e => e.Sliid).HasColumnName("SLIId");
            entity.Property(e => e.FromLocation)
                .HasMaxLength(255)
                .HasColumnName("from_location");
            entity.Property(e => e.Pid).HasColumnName("PId");
            entity.Property(e => e.ReturnedAt)
                .HasMaxLength(255)
                .HasColumnName("Returned_At");
            entity.Property(e => e.ReturnedReason)
                .HasMaxLength(255)
                .HasColumnName("Returned_Reason");
            entity.Property(e => e.SaleStatus).HasMaxLength(255);
            entity.Property(e => e.SerialNo)
                .HasMaxLength(255)
                .HasColumnName("Serial_No");

            entity.HasOne(d => d.PidNavigation).WithMany(p => p.SaleItems)
                .HasForeignKey(d => d.Pid)
                .HasConstraintName("FK__Sale_Item__PId__5DCAEF64");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleItems)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__Sale_Item__SaleI__5CD6CB2B");
        });

        modelBuilder.Entity<TechUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Tech_Use__1788CC4C713075C8");

            entity.ToTable("Tech_User");

            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.CreatedAt).HasColumnName("CreatedAT");
            entity.Property(e => e.District).HasMaxLength(255);
            entity.Property(e => e.State).HasMaxLength(255);
            entity.Property(e => e.StoreAddress)
                .HasMaxLength(255)
                .HasColumnName("Store_Address");

            entity.HasOne(d => d.Client).WithMany(p => p.TechUsers)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Tech_User__Clien__3B75D760");
        });

        modelBuilder.Entity<UserBrand>(entity =>
        {
            entity.HasKey(e => e.Ubid).HasName("PK__User_Bra__B12070EB8015F883");

            entity.ToTable("User_Brand");

            entity.Property(e => e.Ubid).HasColumnName("UBID");
            entity.Property(e => e.Bid).HasColumnName("BId");

            entity.HasOne(d => d.BidNavigation).WithMany(p => p.UserBrands)
                .HasForeignKey(d => d.Bid)
                .HasConstraintName("FK__User_Brand__BId__4D94879B");

            entity.HasOne(d => d.User).WithMany(p => p.UserBrands)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__User_Bran__UserI__4CA06362");
        });

        modelBuilder.Entity<UserCategory>(entity =>
        {
            entity.HasKey(e => e.Ucid).HasName("PK__User_Cat__B66583E29068654A");

            entity.ToTable("User_Category");

            entity.Property(e => e.Ucid).HasColumnName("UCId");

            entity.HasOne(d => d.Cat).WithMany(p => p.UserCategories)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK__User_Cate__CatId__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
