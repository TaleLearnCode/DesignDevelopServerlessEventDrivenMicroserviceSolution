using BuildingBlocks.Core.Constants;

namespace BuildingBricks.OM.Constants;

internal static class OrderManagementEnvironmentVariables
{
	internal const string OrderPlacedQueueConnectionString = $"{EnvironmentVariables.Base}-OM-ServiceBusConnectionString";
	internal const string EventHubConnectionString = $"{EnvironmentVariables.Base}-OM-EventHubConnectionString";
}