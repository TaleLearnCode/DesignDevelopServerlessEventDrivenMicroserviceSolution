using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BuildingBricks.SM.Models;

namespace BuildingBricks.SM
{
    public partial class sqldbShippingManagementContext : DbContext
    {
        public sqldbShippingManagementContext()
        {
        }

        public sqldbShippingManagementContext(DbContextOptions<sqldbShippingManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Shipment> Shipments { get; set; } = null!;
        public virtual DbSet<ShipmentStatus> ShipmentStatuses { get; set; } = null!;
        public virtual DbSet<ShipmentStatusDetail> ShipmentStatusDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=sql-orderprocessingsystem.database.windows.net;Initial Catalog=sqldb-ShippingManagement;Persist Security Info=True;User ID=sqladmin;Password=PA$$word00");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "Shipping");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountryDivisionCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress).HasMaxLength(100);
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("CustomerOrder", "Shipping");

                entity.Property(e => e.CustomerOrderId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem", "Shipping");

                entity.Property(e => e.OrderItemId).ValueGeneratedNever();

                entity.Property(e => e.CustomerOrderId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProductId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkOrderItem_CustomerOrder");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkOrderItem_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Shipping");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProductName).HasMaxLength(100);
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("Shipment", "Shipping");

                entity.Property(e => e.CustomerOrderId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkShipment_CustomerOrder");

                entity.HasOne(d => d.ShipmentStatus)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.ShipmentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkShipment_ShipmentStatus");
            });

            modelBuilder.Entity<ShipmentStatus>(entity =>
            {
                entity.ToTable("ShipmentStatus", "Shipping");

                entity.Property(e => e.ShipmentStatusId).ValueGeneratedNever();

                entity.Property(e => e.ShipmentStatusName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShipmentStatusDetail>(entity =>
            {
                entity.ToTable("ShipmentStatusDetail", "Shipping");

                entity.Property(e => e.StatusDateTime).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.ShipmentStatusDetails)
                    .HasForeignKey(d => d.ShipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkShipmentStatusDetail_Shipment");

                entity.HasOne(d => d.ShipmentStatus)
                    .WithMany(p => p.ShipmentStatusDetails)
                    .HasForeignKey(d => d.ShipmentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkShipmentStatusDetails_ShipmentStatus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
