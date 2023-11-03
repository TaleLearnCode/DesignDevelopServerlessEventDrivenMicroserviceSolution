namespace BuildingBricks.Shipping.Models;

internal static partial class CreateModel
{

	internal static void Customer(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Customer>(entity =>
		{
			entity.HasKey(e => e.CustomerId).HasName("pkcCustomer");

			entity.ToTable("Customer", "Purchase");

			entity.Property(e => e.CustomerId).ValueGeneratedNever();
			entity.Property(e => e.City)
				.IsRequired()
				.HasMaxLength(100);
			entity.Property(e => e.CountryCode)
				.IsRequired()
				.HasMaxLength(2)
				.IsUnicode(false)
				.IsFixedLength();
			entity.Property(e => e.CountryDivisionCode)
				.HasMaxLength(3)
				.IsUnicode(false)
				.IsFixedLength();
			entity.Property(e => e.FirstName)
				.IsRequired()
				.HasMaxLength(100);
			entity.Property(e => e.LastName)
				.IsRequired()
				.HasMaxLength(100);
			entity.Property(e => e.PostalCode)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.StreetAddress)
				.IsRequired()
				.HasMaxLength(100);
		});

	}

}