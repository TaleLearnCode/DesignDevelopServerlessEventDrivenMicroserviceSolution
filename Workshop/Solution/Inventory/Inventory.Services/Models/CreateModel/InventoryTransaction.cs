namespace BuildingBricks.Inventory.Models;

internal static partial class CreateModel
{

	internal static void InventoryTransaction(ModelBuilder modelBuilder)
	{

		modelBuilder.Entity<InventoryTransaction>(entity =>
		{
			entity.HasKey(e => e.InventoryId).HasName("pkcInventory");

			entity.ToTable("InventoryTransaction", "Inventory", tb => tb.HasComment("Represents the inventory status of a product."));

			entity.Property(e => e.InventoryId).HasComment("Identifier for the product inventory transaction.");

			entity.Property(e => e.ActionDateTime)
				.HasDefaultValueSql("(getutcdate())")
				.HasComment("The date and time of the product inventory transaction.");

			entity.Property(e => e.InventoryActionId).HasComment("Identifier for the associated product inventory action.");

			entity.Property(e => e.InventoryCredit).HasComment("The number of items to credit the product inventory by.");

			entity.Property(e => e.InventoryDebit).HasComment("The number of items to debit the product inventory by.");

			entity.Property(e => e.InventoryReserve).HasComment("The number of items to put on product inventory hold.");

			entity.Property(e => e.OrderNumber)
				.HasMaxLength(100)
				.IsUnicode(false)
				.HasComment("Identifier for any associated product.");

			entity.Property(e => e.ProductId)
				.IsRequired()
				.HasMaxLength(5)
				.IsUnicode(false)
				.IsFixedLength()
				.HasComment("Identifier for the product.");

			entity.HasOne(d => d.InventoryAction)
				.WithMany(p => p.InventoryTransactions)
				.HasForeignKey(d => d.InventoryActionId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkInventory_InventoryAction");

			entity.HasOne(d => d.Product)
				.WithMany(p => p.InventoryTransactions)
				.HasForeignKey(d => d.ProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkInventory_Product");

		});

	}

}