using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.ServiceBus;
using System.Text;

namespace BuildingBricks.Core;

public abstract class ServicesBase
{

	protected readonly ConfigServices _configServices;

	protected ServicesBase(ConfigServices configServices) => _configServices = configServices;

	protected static async Task SendMessageToEventHubAsync(
		string connectionString,
		string message)
	{
		await using EventHubProducerClient producerClient = new(connectionString);
		await SendMessageToEventHubAsync(message, producerClient);
	}

	protected static async Task SendMessageToEventHubAsync(
		string connectionString,
		string eventHubName,
		string message)
	{
		await using EventHubProducerClient producerClient = new(connectionString, eventHubName);
		await SendMessageToEventHubAsync(message, producerClient);
	}

	private static async Task SendMessageToEventHubAsync(string message, EventHubProducerClient producerClient)
	{
		EventDataBatch eventDataBatch = await producerClient.CreateBatchAsync();
		if (!eventDataBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(message))))
			throw new Exception("Could not add event to batch");

		try
		{
			await producerClient.SendAsync(eventDataBatch);
		}
		finally
		{
			await producerClient.CloseAsync();
		}
	}

	protected static ServiceBusClient GetServiceBusClient(string connectionString) => new(connectionString);

	protected static async Task SendSessionMessageToServiceBusAsync(
		string connectionString,
		string queueName,
		string sessionId,
		string message)
	{

		await using ServiceBusClient client = GetServiceBusClient(connectionString);
		ServiceBusSender sender = client.CreateSender(queueName);

		ServiceBusMessage serviceBusMessage = new(Encoding.UTF8.GetBytes(message))
		{
			SessionId = sessionId
		};

		await sender.SendMessageAsync(serviceBusMessage);

	}

	protected async Task SendSessionMessageBatchToServiceBusAsync(
		string connectionString,
		string queueName,
		string sessionId,
		List<string> messages)
	{

		ServiceBusClientOptions serviceBusClientOptions = new()
		{
			TransportType = ServiceBusTransportType.AmqpWebSockets
		};

		await using ServiceBusClient serviceBusClient = new(connectionString, serviceBusClientOptions);
		await using ServiceBusSender serviceBusSender = serviceBusClient.CreateSender(queueName);

		using ServiceBusMessageBatch messageBatch = await serviceBusSender.CreateMessageBatchAsync();
		foreach (string message in messages)
			if (!messageBatch.TryAddMessage(new ServiceBusMessage(message) { SessionId = sessionId }))
				throw new Exception("Could not add message to batch");

		await serviceBusSender.SendMessagesAsync(messageBatch);

	}

}