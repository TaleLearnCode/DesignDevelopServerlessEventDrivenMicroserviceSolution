// Ignore Spelling: Sql

namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _Core_AzureSqlCatalog = "Core:AzureSql:Catalog";

	public string CoreAzureSqlCatalog => GetConfigValue(_Core_AzureSqlCatalog);

}