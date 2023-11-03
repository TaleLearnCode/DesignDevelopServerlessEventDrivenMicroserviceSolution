namespace BuildingBricks.Purchase.Models;

internal static partial class CreateModel
{

	internal static void CustomerPurchase(ModelBuilder modelBuilder)
	{

		modelBuilder.Entity<CustomerPurchase>(entity =>
		{

			entity.HasKey(e => e.CustomerPurchaseId).HasName("pkcCustomerPurchase");

			entity.ToTable("CustomerPurchase", "Purchase", tb => tb.HasComment("Represents a purchase by a customer."));

			entity.Property(e => e.CustomerPurchaseId)
				.HasMaxLength(36)
				.IsUnicode(false)
				.IsFixedLength()
				.HasComment("Identifier for the customer purchase.");

			entity.Property(e => e.CompleteDateTime).HasComment("The UTC date and time of when the purchase is completed (shipment received).");

			entity.Property(e => e.CustomerId).HasComment("Identifier for the associated customer.");

			entity.Property(e => e.PurchaseDateTime)
				.HasDefaultValueSql("(getutcdate())")
				.HasComment("The UTC date and time of the purchase.");

			entity.Property(e => e.PurchaseStatusId)
				.HasDefaultValueSql("((1))")
				.HasComment("Identifier for the current purchase status.");

			entity.Property(e => e.ReserveDateTime).HasComment("The UTC date and time of when the product(s) are reserved for the purchase.");

			entity.Property(e => e.ShipDateTime).HasComment("The UTC date and time of when the purchase is shipped.");

			entity.HasOne(d => d.Customer)
				.WithMany(p => p.CustomerPurchases)
				.HasForeignKey(d => d.CustomerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkCustomerPurchase_Customer");

			entity.HasOne(d => d.PurchaseStatus)
				.WithMany(p => p.CustomerPurchases)
				.HasForeignKey(d => d.PurchaseStatusId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkCustomerPurchase_PurchaseStatus");

		});

	}

}