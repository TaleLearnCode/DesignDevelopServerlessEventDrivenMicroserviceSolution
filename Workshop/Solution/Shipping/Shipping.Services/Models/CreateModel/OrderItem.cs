namespace BuildingBricks.Shipping.Models;

internal static partial class CreateModel
{

	internal static void OrderItem(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<OrderItem>(entity =>
		{
			entity.HasKey(e => e.OrderItemId).HasName("pkcOrderItem");

			entity.ToTable("OrderItem", "Purchase");

			entity.Property(e => e.OrderItemId).ValueGeneratedNever();
			entity.Property(e => e.CustomerOrderId)
				.IsRequired()
				.HasMaxLength(36)
				.IsUnicode(false)
				.IsFixedLength();
			entity.Property(e => e.ProductId)
				.IsRequired()
				.HasMaxLength(5)
				.IsUnicode(false)
				.IsFixedLength();

			entity.HasOne(d => d.CustomerOrder).WithMany(p => p.OrderItems)
				.HasForeignKey(d => d.CustomerOrderId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkOrderItem_CustomerOrder");

			entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
				.HasForeignKey(d => d.ProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkOrderItem_Product");
		});
	}

}