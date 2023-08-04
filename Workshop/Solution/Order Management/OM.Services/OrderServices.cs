using Azure.Messaging.ServiceBus;
using BuildingBlocks.Core;
using BuildingBlocks.Core.Constants;
using BuildingBlocks.Core.EventMessage;
using BuildingBricks.OM.Constants;
using BuildingBricks.OM.Extensions;
using BuildingBricks.OM.Models;
using BuildingBricks.OM.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace BuildingBricks.OM;

public class OrderServices : ServicesBase
{

	private readonly IConfiguration _configuration;

	public OrderServices(IConfiguration configuration) => _configuration = configuration;

	public async Task<string> PlaceOrderAsync(PlaceOrderRequest placeOrderRequest)
	{
		string orderId = Guid.NewGuid().ToString();

		using OrderManagementContext context = new();
		CustomerOrder customerOrder = new()
		{
			CustomerOrderId = Guid.NewGuid().ToString(),
			CustomerId = placeOrderRequest.CustomerId,
			OrderItems = BuildOrderItemsList(placeOrderRequest, orderId)
		};
		await context.CustomerOrders.AddAsync(customerOrder);
		await context.SaveChangesAsync();

		await using ServiceBusClient serviceBusClient = GetServiceBusClient(OrderManagementEnvironmentVariables.OrderPlacedQueueConnectionString);
		List<OrderItemMessage> orderItemMessages = customerOrder.ToOrderItemMessageList();
		foreach (OrderItemMessage orderItemMessage in orderItemMessages)
		{
			await SendSessionMessageToServiceBusAsync(
				serviceBusClient,
				_configuration[ConfigurationKeys.OrderPlacedQueueName],
				JsonSerializer.Serialize(orderItemMessage),
				orderItemMessage.ProductId);
		}

		await SendMessageToEventHubAsync(
			OrderManagementEnvironmentVariables.EventHubConnectionString,
			_configuration[ConfigurationKeys.OrderPlacedEventHub],
			JsonSerializer.Serialize(placeOrderRequest));

		return orderId;

	}

	private static List<OrderItem> BuildOrderItemsList(PlaceOrderRequest placeOrderRequest, string orderId)
	{
		List<OrderItem> orderItems = new();
		foreach (PlaceOrderItem placeOrderItem in placeOrderRequest.Items)
			orderItems.Add(new()
			{
				CustomerOrderId = orderId,
				ProductId = placeOrderItem.ProductId,
				Quantity = placeOrderItem.Quantity
			});
		return orderItems;
	}

	public static async Task<CustomerOrder?> GetOrder(string orderId)
	{
		using OrderManagementContext context = new();
		return await context.CustomerOrders.FirstOrDefaultAsync(x => x.CustomerOrderId == orderId);
	}

}