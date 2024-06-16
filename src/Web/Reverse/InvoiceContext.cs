using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Facturador.Web.Models;

namespace Facturador.Web.Reverse;

public partial class InvoiceContext : IdentityDbContext<User>
{
    public InvoiceContext()
    {
    }

    public InvoiceContext(DbContextOptions<InvoiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    public virtual DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Invoice");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.ToTable("Invoice");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Subtotal).HasColumnType("decimal(4, 0)");
            entity.Property(e => e.Total).HasColumnType("decimal(4, 0)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Customer");
        });

        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.ToTable("InvoiceItem");

            entity.Property(e => e.ItemCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemDescription)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.LineTotal).HasColumnType("decimal(4, 0)");
            entity.Property(e => e.TaxDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TaxTotal).HasColumnType("decimal(4, 0)");
            entity.Property(e => e.UnitPrice)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceItem_Invoice");

            entity.HasOne(d => d.UnitOfMeasurementNavigation).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.UnitOfMeasurement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceItem_UnitOfMeasurement");
        });

        modelBuilder.Entity<UnitOfMeasurement>(entity =>
        {
            entity.ToTable("UnitOfMeasurement");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        // Define composite primary key for IdentityUserLogin<string>
        modelBuilder.Entity<IdentityUserLogin<string>>(b =>
        {
            b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        });

        // Similarly, define keys for other Identity-related entities if necessary
        modelBuilder.Entity<IdentityUserRole<string>>(b =>
        {
            b.HasKey(r => new { r.UserId, r.RoleId });
        });

        modelBuilder.Entity<IdentityUserToken<string>>(b =>
        {
            b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
