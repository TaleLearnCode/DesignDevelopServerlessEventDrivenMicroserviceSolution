namespace BuildingBricks.Notice.Models;

internal static partial class CreateModel
{

	internal static void Customer(ModelBuilder modelBuilder)
	{

		modelBuilder.Entity<Customer>(entity =>
		{
			entity.HasKey(e => e.CustomerId).HasName("pkcCustomer");

			entity.ToTable("Customer", "Purchase", tb => tb.HasComment("Represents a customer receiving notifications."));

			entity.Property(e => e.CustomerId)
				.ValueGeneratedNever()
				.HasComment("Identifier for the customer.");

			entity.Property(e => e.EmailAddress)
				.IsRequired()
				.HasMaxLength(255)
				.IsUnicode(false)
				.HasComment("The email address where the customer will receive notifications.");

		});

	}

}