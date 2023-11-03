namespace BuildingBricks.Inventory.Models;

internal static partial class CreateModel
{

	internal static void InventoryAction(ModelBuilder modelBuilder)
	{

		modelBuilder.Entity<InventoryAction>(entity =>
		{

			entity.HasKey(e => e.InventoryActionId).HasName("pkcInventoryAction");

			entity.ToTable("InventoryAction", "Inventory", tb => tb.HasComment("Represents a type of action taken on the inventory of a product."));

			entity.Property(e => e.InventoryActionId)
				.ValueGeneratedNever()
				.HasComment("Identifier for the inventory action.");

			entity.Property(e => e.InventoryActionName)
				.HasMaxLength(100)
				.HasComment("Name for the inventory action.");

		});

	}

}