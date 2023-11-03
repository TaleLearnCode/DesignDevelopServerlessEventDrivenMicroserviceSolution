namespace BuildingBricks.Shipping.Models;

internal static partial class CreateModel
{
	internal static void Shipment(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Shipment>(entity =>
		{
			entity.HasKey(e => e.ShipmentId).HasName("pkcShipment");

			entity
				.ToTable("Shipment", "Shipping", tb => tb.HasComment("Represents a shipment of product to a customer."))
				.ToTable(tb => tb.IsTemporal(ttb =>
				{
					ttb.UseHistoryTable("ShipmentHistory", "Shipping");
					ttb
						.HasPeriodStart("ValidFrom")
						.HasColumnName("ValidFrom");
					ttb
						.HasPeriodEnd("ValidTo")
						.HasColumnName("ValidTo");
				}));

			entity.Property(e => e.ShipmentId).HasComment("Identifier for the shipment.");
			entity.Property(e => e.CustomerPurchaseId)
				.IsRequired()
				.HasMaxLength(36)
				.IsUnicode(false)
				.IsFixedLength()
				.HasComment("Identifier for the associated customer purchase.");
			entity.Property(e => e.ShipmentStatusId).HasComment("Identifier for the associated shipment status.");

			entity.HasOne(d => d.CustomerPurchase).WithMany(p => p.Shipments)
				.HasForeignKey(d => d.CustomerPurchaseId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkShipment_CustomerPurchase");

			entity.HasOne(d => d.ShipmentStatus).WithMany(p => p.Shipments)
				.HasForeignKey(d => d.ShipmentStatusId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkShipment_ShipmentStatus");
		});
	}

}