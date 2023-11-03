namespace BuildingBricks.Purchase.Models;

internal static partial class CreateModel
{

	internal static void Customer(ModelBuilder modelBuilder)
	{

		modelBuilder.Entity<Customer>(entity =>
		{

			entity.HasKey(e => e.CustomerId).HasName("pkcCustomer");

			entity.ToTable("Customer", "Purchase", tb => tb.HasComment("Represents a customer making purchases."));

			entity.Property(e => e.CustomerId).HasComment("Identifier for the customer.");

			entity.Property(e => e.City)
				.IsRequired()
				.HasMaxLength(100)
				.HasComment("The city for the customer shipping address.");

			entity.Property(e => e.CountryCode)
				.IsRequired()
				.HasMaxLength(2)
				.IsUnicode(false)
				.IsFixedLength()
				.HasComment("Code for the country for the customer shipping address.");

			entity.Property(e => e.CountryDivisionCode)
				.HasMaxLength(3)
				.IsUnicode(false)
				.IsFixedLength()
				.HasComment("Code for the country division for the customer shipping address.");

			entity.Property(e => e.EmailAddress)
				.IsRequired()
				.HasMaxLength(255)
				.IsUnicode(false)
				.HasComment("Email address for the customer");

			entity.Property(e => e.FirstName)
				.IsRequired()
				.HasMaxLength(100)
				.HasComment("The first name of the customer.");

			entity.Property(e => e.LastName)
				.IsRequired()
				.HasMaxLength(100)
				.HasComment("The last name of the customer.");

			entity.Property(e => e.PostalCode)
				.HasMaxLength(20)
				.IsUnicode(false)
				.HasComment("Postal code for the customer shipping address.");

			entity.Property(e => e.StreetAddress)
				.IsRequired()
				.HasMaxLength(100)
				.HasComment("The street address for the customer.");

			entity.HasOne(d => d.Country)
				.WithMany(p => p.Customers)
				.HasForeignKey(d => d.CountryCode)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkCustomer_Country");

			entity.HasOne(d => d.CountryDivision)
				.WithMany(p => p.Customers)
				.HasForeignKey(d => new { d.CountryCode, d.CountryDivisionCode })
				.HasConstraintName("fkCustomer_CountryDivision");

		});

	}

}