CREATE TABLE OrderManagement.OrderStatus
(
  OrderStatusId   INT NOT NULL,
  OrderStatusName VARCHAR(100) NOT NULL,
  CONSTRAINT pkcOrderStatus PRIMARY KEY CLUSTERED (OrderStatusId)
)