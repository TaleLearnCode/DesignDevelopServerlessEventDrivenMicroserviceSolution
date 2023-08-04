CREATE TABLE NotificationManagement.Customer
(
  CustomerId   INT          NOT NULL,
  EmailAddress VARCHAR(255) NOT NULL,
  CONSTRAINT pkcCustomer PRIMARY KEY CLUSTERED (CustomerId)
)