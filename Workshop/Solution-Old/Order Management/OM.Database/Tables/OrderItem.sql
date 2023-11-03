CREATE TABLE OrderManagement.OrderItem
(
  OrderItemId      INT       NOT NULL IDENTITY(1,1),
  CustomerOrderId  CHAR(36)  NOT NULL,
  ProductId        CHAR(5)   NOT NULL,
  Quantity         INT       NOT NULL,
  OrderStatusId    INT       NOT NULL CONSTRAINT dfOrderItem_OrderStatusId DEFAULT(1),
  DateTimeAdded    DATETIME2 NOT NULL CONSTRAINT dfOrderItem_DateTimeAdded DEFAULT(GETUTCDATE()),
  DateTimeModified DATETIME2     NULL,
  CONSTRAINT pkcOrderItme PRIMARY KEY CLUSTERED (OrderItemId),
  CONSTRAINT fkOrderItem_CustomerOrder FOREIGN KEY (CustomerOrderId) REFERENCES OrderManagement.CustomerOrder (CustomerOrderId),
  CONSTRAINT fkOrderItem_Product       FOREIGN KEY (ProductId)       REFERENCES OrderManagement.Product (ProductId),
  CONSTRAINT fkOrderItem_OrderStatus   FOREIGN KEY (OrderStatusId)   REFERENCES OrderManagement.OrderStatus (OrderStatusId)
)