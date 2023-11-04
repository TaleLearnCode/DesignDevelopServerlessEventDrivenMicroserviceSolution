# 08 - Send Backorder Notice

## User Story
The Notice system monitors the Inventory Reserved messages looking for backorder notices. Upon receiving a backorder notice, the Notice system will send the customer informing them that the order has been backordered.

## Tasks
- 08A - [Add consumer group for Notice on the Inventory Reserved Event Hub](#add-consumer-group-for-nootice-on-the-inventory-reserved-event-hub-08a)
- 08B - [Add service logic for user story](#add-service-logic-for-user-story-08b)
- 08C - [Create an Azure Function to watch for backorder notices](#create-an-azure-function-to-watch-for-backorder-notices-08c)
- 08D - [Test the Send Backorder Notice User Story](#test-the-send-backorder-notice-user-story-08d)

### Add consumer group for Notice on the Inventory Reserved Event Hub (08A)
1. From the [Azure Portal](https://azure.portal.com), navigate to the Event Hub namespace created from the workshop.
1. Click on the **Inventory Reserved** event hub from the **Event Hubs** listing.
1. Click on the **Consumer groups** option under **Entities** on the left-hand navigation panel
1. Click the **+ Consumer group** button.
1. Enter *notice* in the **Name** field.
1. Click the **Create** button.

### Add a shared access policy for Purchase to access the Inventory Reserved event hub (06A)
1. Click on the **Shared access policies** option under **Settings** on the left-hand navigation panel.
1. Click the **+ Add** button
1. In the **Add SAS Policy** blade, provide the enter the following:

- **Policy name**: Notice
- **Manage**: Unchecked
- **Send**: Unchecked
- **Listen**:Checked

7. Click the **Create** button
1. Click on the policy you just created
1. Copy the **Connection string-primary key**

### Add service logic for user story (08B)
1. From Visual Studio, open the **NoticeServices.cs** file.
1. Add the **SendBackorderNoticeAsync** method to the NoticeServices class.

~~~
	public async Task SendBackorderNoticeAsync(InventoryReservedMessage inventoryReservedMessage)
	{
		string subject = $"Backorder Notice - {inventoryReservedMessage.OrderId}";
		string htmlContent = $"<html><body><p>Thank you for your order. Unfortunately, the {inventoryReservedMessage.ProductId} - {inventoryReservedMessage.ProductName} is on backorder and will be shipped as soon as it is back in stock.</p></body></html>";
		string plainTextContent = $"Thank you for your order. Your order number is {inventoryReservedMessage.OrderId}. Your order is on backorder.";
		await SendEmailAsync(inventoryReservedMessage.CustomerId, NoticeTypes.BackorderNotice, subject, htmlContent, plainTextContent);
	}
~~~

### Create an Azure Function to watch for backorder notices (8C)
1. From Visual Studio, right-click on the **Functions** folder within the **Notice.Functions** folder and click the **Add > New Azure Function**
1. Enter **InventoryReservedMonitor.cs** for the name of the new Azure Function class.

![Screenshot of the Add New Function dialog](images/07-UpdatePurchaseStatusOnInventoryReserve/add-new-item.png)

3. Click the **Add** button
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
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BuildingBricks.Notice.Functions;

public class InventoryReservedMonitor
{

	private readonly ILogger<InventoryReservedMonitor> _logger;
	private readonly NoticeServices _noticeServices;

	public InventoryReservedMonitor(
		ILogger<InventoryReservedMonitor> logger,
		NoticeServices noticeServices)
	{
		_logger = logger;
		_noticeServices = noticeServices;
	}

	[Function("Notice-InventoryReservedMonitor")]
	public async Task RunAsync([EventHubTrigger("%InventoryReservedEventHub%", Connection = "InventoryReservedConnectionString", ConsumerGroup = "%InventoryReservedConsumerGroup%")] EventData[] eventMessages)
	{
		foreach (EventData eventMessage in eventMessages)
		{
			_logger.LogInformation("Inventory Reserved Event Received");
			InventoryReservedMessage? inventoryReservedMessage = JsonSerializer.Deserialize<InventoryReservedMessage>(eventMessage.EventBody);
			if (inventoryReservedMessage is not null && inventoryReservedMessage.Backordered)
			{
				_logger.LogWarning("Inventory Reserved Event Received for Backordered Purchase {PurchaseId}", inventoryReservedMessage.ProductId);
				await _noticeServices.SendBackorderNoticeAsync(inventoryReservedMessage);
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
    "PlaceOrderConnectionString": "{PLACE_ORDER_EVENT_HUB_CONNECTION_STRING}",
    "PlaceOrderEventHub": "{PLACE_ORDER_EVENT_HUB_NAME}"
    "InventoryReservedConnectionString": "{INVENTORY_RESERVED_EVENT_HUB_CONNECTION_STRING}",
    "InventoryReservedEventHub": "{INVENTORY_RESERVED_EVENT_HUB_NAME}",
    "InventoryReservedConsumerGroup": "purchase"
  }
}
~~~

### Test the Send Backorder Notice User Story (08D)
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
      "productId": "10295",
      "quantity": 1
    }
  ]
}
~~~

![Screenshot of Postman](images/04-PlaceOrder/04H-PostmanSetup.png)

7. Click the **Send** button
8. Validate that the appropriate Purchase.CustomerPurchase and Purchase.PurchaseLineItem record was updated