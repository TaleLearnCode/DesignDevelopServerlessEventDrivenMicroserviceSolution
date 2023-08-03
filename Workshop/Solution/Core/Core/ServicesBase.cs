using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.ServiceBus;
using BuildingBlocks.Core.Exceptions;
using System.Text;

namespace BuildingBlocks.Core;

public abstract class ServicesBase
{

	protected static async Task SendMessageToEventHubAsync(
		string connectionStringEnvironmentVariableName,
		string eventHubName,
		string message)
	{

		await using EventHubProducerClient producerClient = new(Environment.GetEnvironmentVariable(connectionStringEnvironmentVariableName), eventHubName);

		using EventDataBatch eventDataBatch = await producerClient.CreateBatchAsync();
		if (!eventDataBatch.TryAdd(new Azure.Messaging.EventHubs.EventData(Encoding.UTF8.GetBytes(message))))
			throw new BatchSizeTooLargeException();

		try
		{
			await producerClient.SendAsync(eventDataBatch);
		}
		finally
		{
			await producerClient.CloseAsync();
		}
	}

	protected static ServiceBusClient GetServiceBusClient(string connectionStringEnvironmentVariableName)
		=> new(Environment.GetEnvironmentVariable(connectionStringEnvironmentVariableName)!);

	protected static async Task SendSessionMessageToServiceBusAsync(
		ServiceBusClient serviceBusClient,
		string queueName,
		string message,
		string sessionId)
	{
		ServiceBusSender serviceBusSender = serviceBusClient.CreateSender(queueName);
		ServiceBusMessage serviceBusMessage = new(Encoding.UTF8.GetBytes(message))
		{
			SessionId = sessionId
		};
		await serviceBusSender.SendMessageAsync(serviceBusMessage);
	}

}