#nullable disable

namespace BuildingBricks.Core;

public partial class CoreContext : DbContext
{

	private ConfigServices _configServices;

	public CoreContext() { }

	public CoreContext(ConfigServices configServices) => _configServices = configServices;

	public CoreContext(DbContextOptions<CoreContext> options) : base(options) { }

	public virtual DbSet<Country> Countries { get; set; }

	public virtual DbSet<CountryDivision> CountryDivisions { get; set; }

	public virtual DbSet<WorldRegion> WorldRegions { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlServer(_configServices.AzureSqlConnectionString(Enumerations.BuildingBrickSystem.Core));

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		CreateModel.Country(modelBuilder);
		CreateModel.CountryDivision(modelBuilder);
		CreateModel.WorldRegion(modelBuilder);
		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}