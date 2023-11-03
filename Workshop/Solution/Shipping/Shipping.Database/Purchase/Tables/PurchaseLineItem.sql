CREATE TABLE Purchase.OrderItem
(
  OrderItemId     INT      NOT NULL,
  CustomerOrderId CHAR(36) NOT NULL,
  ProductId       CHAR(5)  NOT NULL,
  CONSTRAINT pkcOrderItem PRIMARY KEY CLUSTERED (OrderItemId),
  CONSTRAINT fkOrderItem_CustomerOrder FOREIGN KEY (CustomerOrderId) REFERENCES Purchase.CustomerPurchase(CustomerPurchaseId),
  CONSTRAINT fkOrderItem_Product       FOREIGN KEY (ProductId)       REFERENCES Product.Product(ProductId)
)