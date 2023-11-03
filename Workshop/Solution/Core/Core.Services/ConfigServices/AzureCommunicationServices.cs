namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _AzureCommunicationServices_ConnectionString = "AzureCommunicationServices:ConnectionString";

	public string AzureCommunicationServicesConnectionString => GetConfigValue(_AzureCommunicationServices_ConnectionString);

}