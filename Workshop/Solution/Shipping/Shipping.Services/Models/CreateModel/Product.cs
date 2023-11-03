namespace BuildingBricks.Shipping.Models;

internal static partial class CreateModel
{

	internal static void Product(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Product>(entity =>
		{
			entity.HasKey(e => e.ProductId).HasName("pkcProduct");

			entity.ToTable("Product", "Product");

			entity.Property(e => e.ProductId)
				.HasMaxLength(5)
				.IsUnicode(false)
				.IsFixedLength();
			entity.Property(e => e.ProductName)
				.IsRequired()
				.HasMaxLength(100);
		});
	}

}