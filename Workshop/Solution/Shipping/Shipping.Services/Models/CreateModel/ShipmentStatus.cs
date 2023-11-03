namespace BuildingBricks.Shipping.Models;

internal static partial class CreateModel
{

	internal static void ShipmentStatus(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ShipmentStatus>(entity =>
		{
			entity.HasKey(e => e.ShipmentStatusId).HasName("pkcShipmentStatus");

			entity.ToTable("ShipmentStatus", "Shipping", tb => tb.HasComment("Represents the status for a shipment."));

			entity.Property(e => e.ShipmentStatusId)
				.ValueGeneratedNever()
				.HasComment("Identifier for the shipment status record.");
			entity.Property(e => e.ShipmentStatusName)
				.IsRequired()
				.HasMaxLength(100)
				.IsUnicode(false)
				.HasComment("Name of the shipment status.");
		});
	}

}