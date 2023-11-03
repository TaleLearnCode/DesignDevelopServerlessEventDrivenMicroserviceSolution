namespace BuildingBricks.Notice.Models;

internal static partial class CreateModel
{

	internal static void NoticeType(ModelBuilder modelBuilder)
	{

		modelBuilder.Entity<NoticeType>(entity =>
		{

			entity.HasKey(e => e.NoticeTypeId).HasName("pkcNoticeType");

			entity.ToTable("NoticeType", "Notice", tb => tb.HasComment("Represents the types of notices sent to customers."));

			entity.Property(e => e.NoticeTypeId)
				.ValueGeneratedNever()
				.HasComment("Identifier for the notice type.");

			entity.Property(e => e.NoticeTypeName)
				.IsRequired()
				.HasMaxLength(100)
				.IsUnicode(false)
				.HasComment("Name of the notice type.");

		});

	}

}