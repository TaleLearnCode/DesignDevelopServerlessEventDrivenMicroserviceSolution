# 12 - Start Picking Order (Shipping)

## User Story
When the Shipping services receives an Inventory Reserved message, the order is picked for shipment.

### Definition of Done
The Shipment record is updated to indicate that the order is ready to be picked.

---

## Workshop Exercises

**Tasks**
- 12A - [Add consumer group for Shipping on the Inventory Reserved Event Hub](#add-consumer-group-for-shipping-on-the-inventory-reserved-event-hub-12a)
- 12B - [Add a shared access policy for Shipping to access the Inventory Reserved event hub](#add-a-shared-access-policy-for-shipping-to-access-the-inventory-reserved-event-hub-12b)
- 12C - [Add service logic for user story](#add-service-logic-for-user-story-12c)
- 12D - [Create an Azure Function to watch for inventory reserved notices](#create-an-azure-function-to-watch-for-inventory-reserved-notices-12d)
- 12E - [Test the Start Picking Order User Story](#test-the-start-picking-order-user-story-12e)

### Add consumer group for Shipping on the Inventory Reserved Event Hub (12A)
1. From the [Azure Portal](https://azure.portal.com), navigate to the Event Hub namespace created from the workshop.
1. Click on the **Inventory Reserved** event hub from the **Event Hubs** listing.
1. Click on the **Consumer groups** option under **Entities** on the left-hand navigation panel
1. Click the **+ Consumer group** button.
1. Enter *shipping* in the **Name** field.
1. Click the **Create** button.

### Add a shared access policy for Shipping to access the Inventory Reserved event hub (12B)
1. Click on the **Shared access policies** option under **Settings** on the left-hand navigation panel.
1. Click the **+ Add** button
1. In the **Add SAS Policy** blade, provide the enter the following:

- **Policy name**: Shipping
- **Manage**: Unchecked
- **Send**: Unchecked
- **Listen**: Checked

7. Click the **Create** button
1. Click on the policy you just created
1. Copy the **Connection string-primary key**

### Add service logic for user story (12C)
1. From Visual Studio, open the **ShippingServices.cs** file.
1. Add the **StartPickingOrderAsync** method to the ShippingServices class.

~~~
public async Task StartPickingOrderAsync(string orderId)
{
	using ShippingContext shippingContext = new(_configServices);
	CustomerPurchase? customerPurchase = await shippingContext.CustomerPurchases
		.Include(x => x.Shipments)
		.FirstOrDefaultAsync(x => x.CustomerPurchaseId == orderId);
	if (customerPurchase is not null && customerPurchase.Shipments.Any())
	{
		foreach (Shipment shipment in customerPurchase.Shipments)
			shipment.ShipmentStatusId = ShipmentStatuses.Picking;
		await shippingContext.SaveChangesAsync();
	}
}
~~~

### Create an Azure Function to watch for inventory reserved notices (12D)
1. From Visual Studio, right-click on the **Functions** folder within the **Shipping.Functions** folder and click the **Add > New Azure Function**
1. Enter **InventoryReservedMonitor.cs** for the name of the new Azure Function class.
1. Click the **Add** button
1. Select the **Event Hub trigger** and specify the following values:

| Field                          | Value                             |
|--------------------------------|-----------------------------------|
| Connection string setting name | InventoryReservedConnectionString |
| Event Hub name                 | %InventorReservedEventHub%        |

5. Click the **Add** button.
1. Replace the auto-generated code with the following:

~~~
using Azure.Messaging.EventHubs;
using BuildingBricks.EventMessages;
using BuildingBricks.Shipping;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Shipping.Functions;

public class InventoryReservedMonitor
{
	private readonly ILogger<InventoryReservedMonitor> _logger;
	private readonly ShippingServices _shippingServices;

	public InventoryReservedMonitor(
		ILogger<InventoryReservedMonitor> logger,
		ShippingServices shippingServices)
	{
		_logger = logger;
		_shippingServices = shippingServices;
	}

	[Function(nameof(InventoryReservedMonitor))]
	public async Task RunAsync([EventHubTrigger("%InventoryReservedEventHub%", Connection = "InventoryReservedConnectionString", ConsumerGroup = "%InventoryReservedConsumerGroup%")] EventData[] eventMessages)
	{
		foreach (EventData eventMessage in eventMessages)
		{
			InventoryReservedMessage? inventoryReservedMessage = JsonSerializer.Deserialize<InventoryReservedMessage>(eventMessage.EventBody);
			if (inventoryReservedMessage is not null)
			{
				_logger.LogInformation("Inventory reserved for Order #{OrderNumber}", inventoryReservedMessage.OrderId);
				await _shippingServices.StartPickingOrderAsync(inventoryReservedMessage.OrderId);
			}
		}
	}

}
~~~

7. Open the **local.settings.json** file within the **Purchase.Functions** project.
1. Add the InventoryReservedConnectionString, InventoryReservedEventHub, and InventoryReservedConsumerGroup values.

~~~
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "AppConfigEndpoint": "{APP_CONFIG_ENDPOINT}",
    "OrderPlacedConnectionString": "{ORDER_PLACED_EVENT_HUB_CONNECTION_STRING}",
    "OrderPlacedEventHub": "{ORDER_PLACED_EVENT_HUB_NAME}",
    "OrderPlacedConsumerGroup": "shipping",
    "InventoryReservedConnectionString": "{INVENTORY_RESERVED_EVENT_HUB_CONNECTION_STRING}",
    "InventoryReservedEventHub": "{INVENTORY_RESERVED_EVENT_HUB_NAME}",
    "InventoryReservedConsumerGroup": "shipping"
  }
}
~~~

### Test the Start Picking Order User Story (12E)
1. Open Postman and create a new request
1. Change the HTTP verb to **Post**
1. Paste the **PlaceOrder** endpoint URL
1. Click the **Body** tab
1. Select **raw** and **JSON**
1. Enter the JSON below:

~~~
{
  "customerId": 1,
  "items":
  [
    {
      "productId": "10255",
      "quantity": 1
    }
  ]
}
~~~

![Screenshot of Postman](images/04-PlaceOrder/04H-PostmanSetup.png)

7. Click the **Send** button
8. Validate that the appropriate Shipping.Shipment record was updated