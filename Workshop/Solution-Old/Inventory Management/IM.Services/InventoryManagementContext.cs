using BuildingBricks.IM.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingBricks.IM
{
	public partial class InventoryManagementContext : DbContext
	{
		public InventoryManagementContext() { }

		public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options) : base(options) { }

		public virtual DbSet<Product> Products { get; set; } = null!;
		public virtual DbSet<ProductInventory> ProductInventories { get; set; } = null!;
		public virtual DbSet<ProductInventoryAction> ProductInventoryActions { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("OrderProcessingSystem-IM-DatabaseConnectionString")!);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>(entity =>
			{
				entity.ToTable("Product", "Inventory");

				entity.Property(e => e.ProductId)
									.HasMaxLength(5)
									.IsUnicode(false)
									.IsFixedLength();

				entity.Property(e => e.ProductName).HasMaxLength(100);
			});

			modelBuilder.Entity<ProductInventory>(entity =>
			{
				entity.ToTable("ProductInventory", "Inventory");

				entity.Property(e => e.ActionDateTime).HasDefaultValueSql("(getutcdate())");

				entity.Property(e => e.OrderNumber)
									.HasMaxLength(100)
									.IsUnicode(false);

				entity.Property(e => e.ProductId)
									.HasMaxLength(5)
									.IsUnicode(false)
									.IsFixedLength();

				entity.HasOne(d => d.Product)
									.WithMany(p => p.ProductInventories)
									.HasForeignKey(d => d.ProductId)
									.OnDelete(DeleteBehavior.ClientSetNull)
									.HasConstraintName("fkProductInventory_Product");

				entity.HasOne(d => d.ProductInventoryAction)
									.WithMany(p => p.ProductInventories)
									.HasForeignKey(d => d.ProductInventoryActionId)
									.OnDelete(DeleteBehavior.ClientSetNull)
									.HasConstraintName("fkProductInventory_ProductInventoryAction");
			});

			modelBuilder.Entity<ProductInventoryAction>(entity =>
			{
				entity.ToTable("ProductInventoryAction", "Inventory");

				entity.Property(e => e.ProductInventoryActionId).ValueGeneratedNever();

				entity.Property(e => e.ProductInventoryActionName).HasMaxLength(100);
			});

		}

	}

}