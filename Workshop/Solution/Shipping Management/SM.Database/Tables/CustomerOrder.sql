CREATE TABLE Shipping.CustomerOrder
(
  CustomerOrderId CHAR(36) NOT NULL,
  CustomerId      INT      NOT NULL,
  CONSTRAINT pkcCustomerOrder PRIMARY KEY CLUSTERED (CustomerOrderId)
)