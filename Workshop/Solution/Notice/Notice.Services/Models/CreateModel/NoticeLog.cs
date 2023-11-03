using Microsoft.EntityFrameworkCore;

namespace BuildingBricks.Notice.Models;

internal static partial class CreateModel
{

	internal static void NoticeLog(ModelBuilder modelBuilder)
	{

		modelBuilder.Entity<NoticeLog>(entity =>
		{
			entity.HasKey(e => e.NoticeLogId).HasName("pkcNoticeLog");

			entity.ToTable("NoticeLog", "Notice", tb => tb.HasComment("Represents the log of notices sent to customers."));

			entity.Property(e => e.NoticeLogId)
				.IsRequired()
				.HasMaxLength(100)
				.HasComment("Identifier for the notice log.");

			entity.Property(e => e.CustomerId).HasComment("Identifier for the associated customer.");

			entity.Property(e => e.NoticeBody)
				.IsRequired()
				.HasMaxLength(2000)
				.HasComment("The body of the notice message.");

			entity.Property(e => e.NoticeTypeId).HasComment("Identifier for the associated notice type.");

			entity.Property(e => e.SentDateTime)
				.HasDefaultValueSql("(getutcdate())")
				.HasComment("The UTC date and time the notice was sent.");

			entity.HasOne(d => d.Customer)
				.WithMany(p => p.NoticeLogs)
				.HasForeignKey(d => d.CustomerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkNotificationLog_Customer");

			entity.HasOne(d => d.NoticeType).WithMany(p => p.NoticeLogs)
				.HasForeignKey(d => d.NoticeTypeId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("fkNotificationLog_NotificationType");

		});

	}

}