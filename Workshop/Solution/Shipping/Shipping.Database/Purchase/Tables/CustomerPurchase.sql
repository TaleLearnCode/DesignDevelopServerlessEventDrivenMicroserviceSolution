CREATE TABLE Purchase.CustomerPurchase
(
  CustomerPurchaseId CHAR(36) NOT NULL,
  CustomerId         INT      NOT NULL,
  CONSTRAINT pkcCustomerPurchase PRIMARY KEY CLUSTERED (CustomerPurchaseId)
)