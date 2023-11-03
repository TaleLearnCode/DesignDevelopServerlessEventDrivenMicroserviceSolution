namespace BuildingBricks.Shipping.Models;

internal static partial class CreateModel
{

	internal static void ShipmentStatusDetail(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ShipmentStatusDetail>(entity =>
		{
			entity.HasKey(e => e.ShipmentStatusDetailId).HasName("pkcShipmentStatusDetail");

			entity.ToTable("ShipmentStatusDetail", "Shipping", tb => tb.HasComment("Represents the status for a shipment."));

			entity.Property(e => e.ShipmentStatusDetailId).HasComment("Identifier for the shipment status detail record.");
			entity.Property(e => e.ShipmentId).HasComment("Identifier for the associated shipment record.");
			entity.Property(e => e.ShipmentStatusId).HasComment("Identifier for the associated shipment status.");
			entity.Property(e => e.StatusDateTime)
				.HasDefaultValueSql("(getutcdate())")
				.HasComment("The UTC date/time of the shipment status.");

			entity.HasOne(d => d.Shipment).WithMany(p => p.ShipmentStatusDetails)
				.HasForeignKey(d => d.ShipmentId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkShipmentStatusDetail_Shipment");

			entity.HasOne(d => d.ShipmentStatus).WithMany(p => p.ShipmentStatusDetails)
				.HasForeignKey(d => d.ShipmentStatusId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkShipmentStatusDetails_ShipmentStatus");
		});
	}

}