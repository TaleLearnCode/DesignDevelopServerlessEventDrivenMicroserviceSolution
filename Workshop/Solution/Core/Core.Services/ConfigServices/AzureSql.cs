// Ignore Spelling: Sql

namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _AzureSql_DataSource = "AzureSql:DataSource";
	private const string _AzureSql_UserId = "AzureSql:UserId";
	private const string _AzureSQL_Password = "AzureSql:Password";

	public string AzureSqlDataSource => GetConfigValue(_AzureSql_DataSource);

	public string AzureSqlUserId => GetConfigValue(_AzureSql_UserId);

	public string AzureSqlPassword => GetConfigValue(_AzureSQL_Password);

}