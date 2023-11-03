namespace BuildingBricks.Inventory.Models;

internal static partial class CreateModel
{

	internal static void ProductInventory(ModelBuilder modelBuilder)
	{

		modelBuilder.Entity<ProductInventory>(entity =>
		{

			entity.HasNoKey().ToView("vwProductInventory", "Inventory");

			entity.Property(e => e.ProductId)
				.IsRequired()
				.HasMaxLength(5)
				.IsUnicode(false)
				.IsFixedLength();

			entity.Property(e => e.ProductName)
				.IsRequired()
				.HasMaxLength(100);

		});

	}

}