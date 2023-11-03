namespace BuildingBricks.Purchase.Models;

internal static partial class CreateModel
{

	internal static void Country(ModelBuilder modelBuilder)
	{

		modelBuilder.Entity<Country>(entity =>
		{

			entity.HasKey(e => e.CountryCode).HasName("pkcCountry");

			entity.ToTable("Country", "Core", tb => tb.HasComment("Lookup table representing the countries as defined by the ISO 3166-1 standard."));

			entity.Property(e => e.CountryCode)
				.HasMaxLength(2)
				.IsUnicode(false)
				.IsFixedLength()
				.HasComment("Identifier of the country using the ISO 3166-1 Alpha-2 code.");

			entity.Property(e => e.CountryName)
				.IsRequired()
				.HasMaxLength(100)
				.IsUnicode(false)
				.HasComment("Name of the country using the ISO 3166-1 Country Name.");

			entity.Property(e => e.DivisionName)
				.HasMaxLength(100)
					.IsUnicode(false)
					.HasComment("The primary name of the country's divisions.");

			entity.Property(e => e.HasDivisions).HasComment("Flag indicating whether the country has divisions (states, provinces, etc.)");

			entity.Property(e => e.IsActive).HasComment("Flag indicating whether the country record is active.");

		});

	}

}