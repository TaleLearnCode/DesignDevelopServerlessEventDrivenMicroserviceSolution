#nullable disable

namespace BuildingBricks.Inventory.Models;

public partial class InventoryContext : DbContext
{

	private ConfigServices _configServices;

	public InventoryContext() { }

	public InventoryContext(ConfigServices configServices) => _configServices = configServices;

	public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

	public virtual DbSet<InventoryAction> InventoryActions { get; set; }

	public virtual DbSet<InventoryTransaction> InventoryTransactions { get; set; }

	public virtual DbSet<Product> Products { get; set; }

	public virtual DbSet<ProductInventory> ProductInventories { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer(_configServices.AzureSqlConnectionString(BuildingBrickSystem.Inventory));

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		CreateModel.InventoryAction(modelBuilder);
		CreateModel.InventoryTransaction(modelBuilder);
		CreateModel.Product(modelBuilder);
		CreateModel.ProductInventory(modelBuilder);
		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}