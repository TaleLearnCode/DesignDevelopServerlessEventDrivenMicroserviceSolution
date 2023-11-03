CREATE TABLE OrderManagement.CustomerOrder
(
  CustomerOrderId  CHAR(36)  NOT NULL,
  CustomerId       INT       NOT NULL,
  OrderStatusId    INT       NOT NULL CONSTRAINT dfCustomerOrder_OrderStatusId DEFAULT(1),
  OrderDateTime    DATETIME2 NOT NULL CONSTRAINT dfCustomerOrder_OrderDateTime DEFAULT(GETUTCDATE()),
  ReserveDateTime  DATETIME2     NULL,
  ShipDateTime     DATETIME2     NULL,
  CompleteDateTime DATETIME2     NULL,
  CONSTRAINT pkcCustomerOrder PRIMARY KEY CLUSTERED (CustomerOrderId)
)