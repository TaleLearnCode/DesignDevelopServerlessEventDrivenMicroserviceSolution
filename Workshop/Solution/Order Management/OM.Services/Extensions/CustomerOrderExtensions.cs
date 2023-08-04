using BuildingBlocks.Core.EventMessage;
using BuildingBricks.OM.Models;

namespace BuildingBricks.OM.Extensions;

internal static class CustomerOrderExtensions
{

	internal static List<OrderItemMessage> ToOrderItemMessageList(this CustomerOrder customerOrder)
	{
		List<OrderItemMessage> orderItemMessages = new();
		foreach (OrderItem orderItem in customerOrder.OrderItems)
			orderItemMessages.Add(new()
			{
				OrderId = customerOrder.CustomerOrderId,
				OrderItemId = orderItem.OrderItemId,
				ProductId = orderItem.ProductId,
				Quantity = orderItem.Quantity
			});
		return orderItemMessages;
	}

}