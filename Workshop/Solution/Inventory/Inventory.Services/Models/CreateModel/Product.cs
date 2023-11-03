namespace BuildingBricks.Inventory.Models;

internal static partial class CreateModel
{

	internal static void Product(ModelBuilder modelBuilder)
	{

		modelBuilder.Entity<Product>(entity =>
		{

			entity.HasKey(e => e.ProductId).HasName("pkcProduct");

			entity.ToTable("Product", "Product", tb => tb.HasComment("Represents a product in inventory."));

			entity.Property(e => e.ProductId)
				.HasMaxLength(5)
				.IsUnicode(false)
				.IsFixedLength()
				.HasComment("Identifier for the product.");

			entity.Property(e => e.ProductName)
				.IsRequired()
				.HasMaxLength(100)
				.HasComment("Name for the product.");

		});

	}

}