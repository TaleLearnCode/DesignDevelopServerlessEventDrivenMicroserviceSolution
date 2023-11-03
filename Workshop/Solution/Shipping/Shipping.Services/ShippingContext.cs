#nullable disable

namespace BuildingBricks.Shipping.Models;

public partial class ShippingContext : DbContext
{

	private readonly ConfigServices _configServices;

	public ShippingContext() { }

	public ShippingContext(ConfigServices configServices) => _configServices = configServices;

	public ShippingContext(DbContextOptions<ShippingContext> options) : base(options) { }

	public virtual DbSet<Customer> Customers { get; set; }

	public virtual DbSet<CustomerPurchase> CustomerPurchases { get; set; }

	public virtual DbSet<OrderItem> OrderItems { get; set; }

	public virtual DbSet<Product> Products { get; set; }

	public virtual DbSet<Shipment> Shipments { get; set; }

	public virtual DbSet<ShipmentStatus> ShipmentStatuses { get; set; }

	public virtual DbSet<ShipmentStatusDetail> ShipmentStatusDetails { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer(_configServices.AzureSqlConnectionString(BuildingBrickSystem.Shipping));

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		CreateModel.Customer(modelBuilder);
		CreateModel.CustomerPurchase(modelBuilder);
		CreateModel.OrderItem(modelBuilder);
		CreateModel.Product(modelBuilder);
		CreateModel.Shipment(modelBuilder);
		CreateModel.ShipmentStatus(modelBuilder);
		CreateModel.ShipmentStatusDetail(modelBuilder);
		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}