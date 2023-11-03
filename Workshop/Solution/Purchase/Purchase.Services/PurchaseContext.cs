#nullable disable

namespace BuildingBricks.Purchase.Models;

public partial class PurchaseContext : DbContext
{

	private ConfigServices _configServices;

	public PurchaseContext()
	{
	}

	public PurchaseContext(ConfigServices configServices) => _configServices = configServices;

	public PurchaseContext(DbContextOptions<PurchaseContext> options)
			: base(options)
	{
	}

	public virtual DbSet<Country> Countries { get; set; }

	public virtual DbSet<CountryDivision> CountryDivisions { get; set; }

	public virtual DbSet<Customer> Customers { get; set; }

	public virtual DbSet<CustomerPurchase> CustomerPurchases { get; set; }

	public virtual DbSet<Product> Products { get; set; }

	public virtual DbSet<PurchaseLineItem> PurchaseLineItems { get; set; }

	public virtual DbSet<PurchaseStatus> PurchaseStatuses { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer(_configServices.AzureSqlConnectionString(BuildingBrickSystem.Purchase));

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		CreateModel.Country(modelBuilder);
		CreateModel.CountryDivision(modelBuilder);
		CreateModel.Customer(modelBuilder);
		CreateModel.CustomerPurchase(modelBuilder);
		CreateModel.Product(modelBuilder);
		CreateModel.PurchaseLineItem(modelBuilder);
		CreateModel.PurchaseStatus(modelBuilder);
		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}