#nullable disable

namespace BuildingBricks.Notice.Models;

public partial class NoticeContext : DbContext
{

	private ConfigServices _configServices;

	public NoticeContext()
	{
	}

	public NoticeContext(ConfigServices configServices) => _configServices = configServices;

	public NoticeContext(DbContextOptions<NoticeContext> options)
			: base(options)
	{
	}

	public virtual DbSet<Customer> Customers { get; set; }

	public virtual DbSet<NoticeLog> NoticeLogs { get; set; }

	public virtual DbSet<NoticeType> NoticeTypes { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer(_configServices.AzureSqlConnectionString(BuildingBrickSystem.Notice));


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		CreateModel.Customer(modelBuilder);
		CreateModel.NoticeLog(modelBuilder);
		CreateModel.NoticeType(modelBuilder);
		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}