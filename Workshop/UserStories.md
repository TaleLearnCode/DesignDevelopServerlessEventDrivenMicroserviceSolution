# User Stories

* [Order Placement and Notifications](#order-plcement-and-notifications)
* [Inventory Management and Order Fulfillment](#inventory-management-and-order-fulfillment)
* [Inventory Updates and Product Status Display](#inventory-updates-and-product-status-display)
* [Shipping Management and Order Fulfillment](#shipping-management-and-order-fulfillment)
* [Shipping Management, Order Updates, and Delivery Confirmation](#shipping-management-order-updates-and-delivery-confirmation)

## Order Placement and Notifications
As a *customer*, I want to be able to place an order on the Building Bricks website, so that I can receive the LEGO products I desire.

## Description
This user story outlines the process of order placement and notifications within the e-commerce system, focusing on order details storage, inventory check and reservation, as well as order confirmation notifications.  It also includes handling scenarios for potential errors, unavailability of products, and order cancellations.

## Acceptance Criteria

### Scenario 1: Placing an Order
Given that I am a registered user on the e-commerce platform,
When I browse the products and add desired items to my card,
Then I should be able to proceed to checkout.

### Scenario 2: Saving Order Details
Given that I have completed the checkout process,
When I click the "Place Order" button,
Then the system should save my order details in the Order database

### Scenario 3: Notifying Notification Management
Given that I have placed an order and my order details are saved,
When the order is saved in the Order database
Then a notification should be sent to Notification Management.

### Scenario 4: Sending Order Confirmation Notification
Given that Notification Management receives the order confirmation notification,
When the notification is received,
Then Notification Management should send out an order confirmation email to the customer.

### Scenario 5: Notifying Inventory Management of Order
Given that I have successfully placed an order,
When my order details are saved in the Order database,
Then a notification should be sent to Inventory Management for each ordered product.

### Scenario 6: Inventory Check and Reservation
Given that Inventory Management receives the notification for an ordered product,
When the notification is received in the order that orders are placed,
Then Inventory Management should conduct an inventory check to ensure product availability

### Scenario 7: Reserving Products for Shipment
Given that the inventory check is completed,
When the order products are available in sufficient quantity,
Then Inventory Management should reserve the items for shipment to the customer.

### Scenario 8: Handing Insufficient Inventory
Given that the inventory check reveals insufficient stock for an ordered product,
When Inventory Management cannot reserve the item(s) for shipment,
Then the system should inform the customer about the unavailability and inform them the order is back ordered

### Scenario 9: Handling Order Failure
Given that an error occurs during order placement,
When the system fails to save order details in the Order database,
Then the system should notify the customer about the issue and prompt them to retry the order.

### Scenario 10: Handling Order Cancellation
Given that the customer cancels the order before it is shipped,
When the cancellation request is received,
Then the system should release the reserved items back to inventory.

### Scenario 11: Handling Order Shipment
Given that the reserved items are ready for shipment,
When the order is scheduled for delivery,
Then the customer should receive a notification when shipping details.

### Scenario 12: Tracking Order Status
Given that the order is shipped,
When the customer wants to track the order status,
Then they should be able to view the real-time status through the website.

# Inventory Management and Order Fulfillment
As an *inventory manager*, I want to ensure that the items within an order are verified to be in stock, so that I can efficiently fulfill customer orders and maintain accurate inventory status.

## Description
This user story outlines the process of inventory management and order fulfillment within the e-commerce platform, specifically focusing on item availability verification, order status updates, handling backorders, and proving timely notifications to customers.

## Acceptance Criteria

### Scenario 1: Checking Item Availability
Given an incoming customer order with specific products and quantities,
When the order is received in the inventory management system,
THen the system should check the availability of each ordered item in the inventory.

### Scenario 2: Sufficient Stock Available
Given that there is sufficient stock for all ordered items,
When the inventory check confirms the availability,
Then the order quantity of each item should be reserved for the customer's order.

### Scenario 3: Updating Order Status
Given that the order quantities are successfully reserved,
When the order status is updated to "Ready for Fulfillment",
Then the fulfillment process should be initiated for the order.

### Scenario 4: Initiating Order Fulfillment
Given that the order status is "Ready for Fulfillment",
When the fulfillment process begins,
Then the ordered items should be picked, packed, and prepared for shipment.

### Scenario 5: Notifying Customer of Order Fulfillment
Given that the fulfillment process is completed,
When the order is ready for shipment,
Then the customer should receive a notification with shipping details and order status update.

### Scenario 6: Insufficient Stock Available
Given that there is insufficient stock for one or more ordered items,
When the inventory check reveals the unavailability,
Then the ordered quantity for the unavailable item(s) should be marked as "Backordered."

### Scenario 7: Notifying Customer of Backorder
Given that an item is marked as "Backordered",
When the inventory system updates the order status,
Then the customer should receive a notification informing them of the backorder situation.

### Scenario 8: Providing Estimated Restocking Date
Given that an item is backordered,
When the inventory management system has an estimated restocking date for the item,
Then the notification to the customer should include the expected date for restocking.

### Scenario 9: Handling Partial Fulfillment
Given that some items are in stock and others are backordered,
When the order fulfillment process begins,
Then the available items should be processed for shipment, and the backordered items should be reserved for future fulfillment.

### Scenario 10: Updating Backordered Items Status
Given that backordered items are restocked and ready for fulfillment,
When new stock becomes available for the backordered items,
Then the inventory system should update their status from "Backordered to "Ready for Fulfillment"

### Scenario 11: Notifying Customer of Fulfillment Completion
Given that backordered items are restocked and ready for fulfillment,
When the fulfillment process begins for the remaining items,
THen the customer should receive a notification indicating that the order is being prepared for complete shipment.

# Inventory Updates and Product Status Display
As a *product manager*, I want to receive near-real-time updates from Inventory Management, so that I can update the stock status within the product database for accurate product information.

## Description
This user story outlines the process of inventory updates from Inventory Management to Product Management and the periodic updating of static pages by Website Management.  By ensuring real-time synchronization and period updates, the platform can display accurate and up-to-date product inventory status to customers, leading to a better shopping experience and informed purchasing decisions.

## Acceptance Criteria

### Scenario 1: Receiving Inventory Updates
Given that new stock is added or reserved for an item in Inventory Management,
When the inventory is updated for a specific product,
Then Product Management should receive the updated inventory data.

### Scenario 2: Updating Product Database
Given that Product Management receive inventory updates,
When the updated inventory data is received,
Then Product Management should update the stock status within the product database for each affected product.

### Scenario 3: Real-Time Inventory Synchronization
Given that the stock status is updated in the product database,
When the update is completed,
Then the product information should reflect the current available quality for each product.

### Scenario 4: Periodic Static Page Updates
Given that the product database is updated with current inventory data,
When a specified time interval has passed (e.g. hourly, daily, or weekly),
Then Website Management should update the static pages displaying the product inventory status.

### Scenario 5: Triggering Static Page Updates
Given the specified time interval has elapsed,
When the trigger for static page updates occurs,
Then Website Management should imitate the update process for all product pages.

### Scenario 6: Reflecting Updated Inventory on Website
Given that the static pages are updated by Website Management,
When the update process is completed,
Then the product inventory status displayed on the website should reflect the most recent changes.

### Scenario 7: Displaying Accurate Stock Information
Given that the product inventory status is displayed on the website,
When customers view the product pages,
Then they should see the accurate and up-to-date stock status of each product.

### Scenario 8: Handling Synchronization Errors
Given that there are synchronization errors between Inventory Management and the product database,
When an error occurs during the update process,
Then Product Management and Website Management should be alerted, and corrective action should be taken to resolve the issue promptly

### Scenario 9: Verifying Data Accuracy
Given that the stock status is updated in the product database,
When Website Management perform periodic updates,
Then a verification process should be in place to ensure that the displayed inventory information is consistent and accurate.

# Shipping Management and Order Fulfillment

As a *shipping manager*, I want to receive notifications when the inventory for an order has been reserved, so that I can efficiently pick, pack, and ship the order to the customer.

## Description
This user story outlines the process of shipping management and order fulfillment within the platform.  By ensuring that Shipping Management receives notifications of reserved inventory, the fulfillment process can be efficiently initiated, leading to timely order shipments.  The collaboration between Shipping Management, Order Management, and Notification Management ensures that customer are informed about their order status, leading to a positive customer experience.

## Acceptance Criteria

### Scenario 1: Inventory Reserved for Order
Given that the inventory for an order has been successfully reserved by Inventory Management,
When the inventory is reserved for a specific order,
Then Shipping Management should receive a notification indicating the order is ready for fulfillment.

### Scenario 2: Initiating Order Fulfillment
Given that Shipping Management receives the notification,
When the order is marked as ready for fulfillment,
Then the fulfillment process should be initiated, and the order should be prepared for shipment.

### Scenario 3: Picking and Packing
Given that the fulfillment process in initiated
When the order is ready to be shipped,
Then Shipping Management should pick the items from inventory, pack them securely, and prepare the package for shipment.

### Scenario 4: Notifying Order Shipment
Given that the order is picked, packed, and ready for shipment
When the order is shipped,
Then Shipping Management should send out a notification confirming the order has been shipped.

### Scenario 5: Listing for Shipment Notification
Given that the the order has been shipped,
When Order Management listens for shipment notifications,
Then Order Management should update the order status to "Shipped."

### Scenario 6: Sending Shipment Notifications
Given that Order Management updates the order status to "Shipped,"
When Shipping Management sends out the shipment notification,
Then Notification Management should be notified to send shipment notifications to the customer.

### Scenario 7: Customer Notification of Shipment
Given that Notification Management receives the notification,
When the shipment notification is triggered,
Then the customer should receive a notification confirming that their order has been shipped.

### Scenario 8: Handling Shipment Errors
WGiven that an order occurs during the shipment process,
When Shipping Management encounters an issue,
Then the appropriate teams should be notified, and corrective actions should be taken to resolve the problem.

# Shipping Management, Order Updates, and Delivery Confirmation
As a *shipping manager*, I want to receive notifications from carriers when a package has been delivered, so that II can promptly inform Order Management about the successful delivery and trigger delivery confirmation emails to customers.

## Summary
This user story outlines the process of handling delivery notifications from carriers, updating the order status in the order database, and sending delivery confirmation emails to customers.  By ensuring that Shipping Management is informed about successful deliveries, the order status can be accurately updated, and customers can be promptly notified about their order's successful delivery, enhancing customer satisfaction and overall experience with the platform.

## Acceptance Criteria

### Scenario 1: Package Delivery Notification
Given that a package has been successfully delivered by the carrier,
When the delivery is completed,
Then Shipping Management should receive a notification from the carrier indicating successful delivery.

### Scenario 2: Informing Order Management
Given that Shipping Management received the delivery notification,
When the package is confirmed as delivered,
Then Shipping Management should promptly notify Order Management about the the successful delivery.

### Scenario 3: Updating Order Database
Given that Order Management is informed about the delivery,
When the delivery notification is received,
Then Order Management should update the corresponding order record in the order database to mark the order status as "Delivered."

### Scenario 4: Notifying Notification Management
Given that the order status is updated to "Delivered" in the order database,
When the order is marked as delivered,
Then Shipping Management should notify Notification Management about the successful delivery.

### Scenario 5: Sending Delivery Confirmation Email
Given that Notification Management receives the delivery notification,
When the notification is received,
Then Notification Management should send a delivery confirmation email to the customer.

### Scenario 6: Delivery Confirmation to Customer
Given that the delivery confirmation email is sent,
When the customer receives the email,
Then the customer should be informed that their order has been successfully delivered.

### Scenario 7: Handling Delivery Notification Errors
Given that an error occurs during the delivery notification process,
When Shipping Management encounters an issue with receiving notifications,
Then the appropriate teams should be notified, and corrective actions should be taken to resolve the problem promptly.