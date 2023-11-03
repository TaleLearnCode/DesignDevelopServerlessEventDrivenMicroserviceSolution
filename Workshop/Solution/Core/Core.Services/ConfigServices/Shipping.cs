// Ignore Spelling: Sql

namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _Shipping_AzureSqlCatalog = "Shipping:AzureSql:Catalog";

	public string ShippingAzureSqlCatalog => GetConfigValue(_Shipping_AzureSqlCatalog);

}