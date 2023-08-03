using BuildingBricks.OM.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingBricks.OM
{

	public partial class OrderManagementContext : DbContext
	{
		public OrderManagementContext()
		{
		}

		public OrderManagementContext(DbContextOptions<OrderManagementContext> options)
				: base(options)
		{
		}

		public virtual DbSet<Customer> Customers { get; set; } = null!;
		public virtual DbSet<CustomerOrder> CustomerOrders { get; set; } = null!;
		public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
		public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
		public virtual DbSet<Product> Products { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("OrderProcessingSystem-OM-DatabaseConnectionString")!);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>(entity =>
			{
				entity.ToTable("Customer", "OrderManagement");

				entity.Property(e => e.City).HasMaxLength(100);

				entity.Property(e => e.CountryCode)
									.HasMaxLength(2)
									.IsUnicode(false)
									.IsFixedLength();

				entity.Property(e => e.CountryDivisionCode)
									.HasMaxLength(2)
									.IsUnicode(false)
									.IsFixedLength();

				entity.Property(e => e.EmailAddress)
									.HasMaxLength(255)
									.IsUnicode(false)
									.HasColumnName("EMailAddress");

				entity.Property(e => e.FirstName).HasMaxLength(100);

				entity.Property(e => e.LastName).HasMaxLength(100);

				entity.Property(e => e.PostalCode)
									.HasMaxLength(20)
									.IsUnicode(false);

				entity.Property(e => e.StreetAddress).HasMaxLength(100);
			});

			modelBuilder.Entity<CustomerOrder>(entity =>
			{
				entity.ToTable("CustomerOrder", "OrderManagement");

				entity.Property(e => e.CustomerOrderId)
									.HasMaxLength(36)
									.IsUnicode(false)
									.IsFixedLength();

				entity.Property(e => e.OrderDateTime).HasDefaultValueSql("(getutcdate())");

				entity.Property(e => e.OrderStatusId).HasDefaultValueSql("((1))");
			});

			modelBuilder.Entity<OrderItem>(entity =>
			{
				entity.ToTable("OrderItem", "OrderManagement");

				entity.Property(e => e.CustomerOrderId)
									.HasMaxLength(36)
									.IsUnicode(false)
									.IsFixedLength();

				entity.Property(e => e.DateTimeAdded).HasDefaultValueSql("(getutcdate())");

				entity.Property(e => e.OrderStatusId).HasDefaultValueSql("((1))");

				entity.HasOne(d => d.CustomerOrder)
									.WithMany(p => p.OrderItems)
									.HasForeignKey(d => d.CustomerOrderId)
									.OnDelete(DeleteBehavior.ClientSetNull)
									.HasConstraintName("fkOrderItem_CustomerOrder");

				entity.HasOne(d => d.OrderStatus)
									.WithMany(p => p.OrderItems)
									.HasForeignKey(d => d.OrderStatusId)
									.OnDelete(DeleteBehavior.ClientSetNull)
									.HasConstraintName("fkOrderItem_OrderStatus");
			});

			modelBuilder.Entity<OrderStatus>(entity =>
			{
				entity.ToTable("OrderStatus", "OrderManagement");

				entity.Property(e => e.OrderStatusId).ValueGeneratedNever();

				entity.Property(e => e.OrderStatusName)
									.HasMaxLength(100)
									.IsUnicode(false);
			});

			modelBuilder.Entity<Product>(entity =>
			{
				entity.ToTable("Product", "OrderManagement");

				entity.Property(e => e.ProductId)
									.HasMaxLength(5)
									.IsUnicode(false)
									.IsFixedLength();

				entity.Property(e => e.Price).HasColumnType("smallmoney");

				entity.Property(e => e.ProductName).HasMaxLength(100);
			});

		}

	}

}