namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _CosmosKey = "Cosmos:Key";
	private const string _CosmosUri = "Cosmos:Uri";

	public string CosmosKey => GetConfigValue(_CosmosKey);

	public string CosmosUri => GetConfigValue(_CosmosUri);

}