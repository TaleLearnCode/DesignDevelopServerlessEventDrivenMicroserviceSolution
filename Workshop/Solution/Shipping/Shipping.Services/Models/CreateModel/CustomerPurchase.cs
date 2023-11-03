namespace BuildingBricks.Shipping.Models;

internal static partial class CreateModel
{

	internal static void CustomerPurchase(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CustomerPurchase>(entity =>
		{
			entity.HasKey(e => e.CustomerPurchaseId).HasName("pkcCustomerPurchase");

			entity.ToTable("CustomerPurchase", "Purchase");

			entity.Property(e => e.CustomerPurchaseId)
				.HasMaxLength(36)
				.IsUnicode(false)
				.IsFixedLength();
		});
	}

}