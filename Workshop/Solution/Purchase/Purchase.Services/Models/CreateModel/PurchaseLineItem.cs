namespace BuildingBricks.Purchase.Models;

internal static partial class CreateModel
{

	internal static void PurchaseLineItem(ModelBuilder modelBuilder)
	{

		modelBuilder.Entity<PurchaseLineItem>(entity =>
		{

			entity.HasKey(e => e.PurchaseLineItemId).HasName("pkcPurchaseLineItem");

			entity
				.ToTable("PurchaseLineItem", "Purchase", tb => tb.HasComment("Represents a line item within a purchase."))
				.ToTable(tb => tb.IsTemporal(ttb =>
				{
					ttb.UseHistoryTable("PurchaseLineItemHistory", "Purchase");
					ttb
						.HasPeriodStart("ValidFrom")
						.HasColumnName("ValidFrom");
					ttb
						.HasPeriodEnd("ValidTo")
						.HasColumnName("ValidTo");
				}));

			entity.Property(e => e.PurchaseLineItemId).HasComment("Identifier for the purchase line item.");

			entity.Property(e => e.CustomerPurchaseId)
				.IsRequired()
				.HasMaxLength(36)
				.IsUnicode(false)
				.IsFixedLength()
				.HasComment("Identifier for the associated customer purchase.");

			entity.Property(e => e.DateTimeAdded).HasDefaultValueSql("(getutcdate())");

			entity.Property(e => e.ProductId)
				.IsRequired()
				.HasMaxLength(5)
				.IsUnicode(false)
				.IsFixedLength()
				.HasComment("Identifier for the associated product.");

			entity.Property(e => e.ProductPrice)
				.HasComment("The purchase price of the product.")
				.HasColumnType("smallmoney");

			entity.Property(e => e.PurchaseStatusId)
				.HasDefaultValueSql("((1))")
				.HasComment("Identifier of the current status for the line item.");

			entity.Property(e => e.Quantity).HasComment("The quantity of product being purchased.");

			entity.HasOne(d => d.CustomerPurchase)
				.WithMany(p => p.PurchaseLineItems)
				.HasForeignKey(d => d.CustomerPurchaseId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkPurchaseLineItem_CustomerPurchase");

			entity.HasOne(d => d.Product)
				.WithMany(p => p.PurchaseLineItems)
				.HasForeignKey(d => d.ProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkPurchaseLineItem_Product");

			entity.HasOne(d => d.PurchaseStatus)
				.WithMany(p => p.PurchaseLineItems)
				.HasForeignKey(d => d.PurchaseStatusId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkPurchaseLineItem_PurchaseStatus");

		});

	}

}