using BuildingBricks.NM.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingBricks.NM
{
	public partial class NotificationManagementContext : DbContext
	{
		public NotificationManagementContext()
		{
		}

		public NotificationManagementContext(DbContextOptions<NotificationManagementContext> options)
				: base(options)
		{
		}

		public virtual DbSet<Customer> Customers { get; set; } = null!;
		public virtual DbSet<NotificationLog> NotificationLogs { get; set; } = null!;
		public virtual DbSet<NotificationType> NotificationTypes { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("OrderProcessingSystem-NM-DatabaseConnectionString")!);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>(entity =>
			{
				entity.ToTable("Customer", "NotificationManagement");

				entity.Property(e => e.CustomerId).ValueGeneratedNever();

				entity.Property(e => e.EmailAddress)
									.HasMaxLength(255)
									.IsUnicode(false);
			});

			modelBuilder.Entity<NotificationLog>(entity =>
			{
				entity.ToTable("NotificationLog", "NotificationManagement");

				entity.Property(e => e.SentDateTime).HasDefaultValueSql("(getutcdate())");

				entity.HasOne(d => d.Customer)
									.WithMany(p => p.NotificationLogs)
									.HasForeignKey(d => d.CustomerId)
									.OnDelete(DeleteBehavior.ClientSetNull)
									.HasConstraintName("fkNotificationLog_Customer");

				entity.HasOne(d => d.NotificationType)
									.WithMany(p => p.NotificationLogs)
									.HasForeignKey(d => d.NotificationTypeId)
									.OnDelete(DeleteBehavior.ClientSetNull)
									.HasConstraintName("fkNotificationLog_NotificationType");
			});

			modelBuilder.Entity<NotificationType>(entity =>
			{
				entity.ToTable("NotificationType", "NotificationManagement");

				entity.Property(e => e.NotificationTypeId).ValueGeneratedNever();

				entity.Property(e => e.NotificationTypeName)
									.HasMaxLength(100)
									.IsUnicode(false);
			});

		}

	}

}