// Ignore Spelling: Sql

namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _Notice_AzureSqlCatalog = "Notice:AzureSql:Catalog";
	private const string _Notice_SenderAddress = "Notice:SenderAddress";

	public string NoticeAzureSqlCatalog => GetConfigValue(_Notice_AzureSqlCatalog);

	public string NoticeSenderAddress => GetConfigValue(_Notice_SenderAddress);

}