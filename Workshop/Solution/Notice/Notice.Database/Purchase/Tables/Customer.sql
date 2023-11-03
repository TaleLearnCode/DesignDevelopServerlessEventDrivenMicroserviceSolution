CREATE TABLE Purchase.Customer
(
  CustomerId   INT          NOT NULL,
  EmailAddress VARCHAR(255) NOT NULL,
  CONSTRAINT pkcCustomer PRIMARY KEY CLUSTERED (CustomerId)
)
GO

EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer',                              @value=N'Represents a customer receiving notifications.',                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'CustomerId',   @value=N'Identifier for the customer.',                                                 @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'EmailAddress', @value=N'The email address where the customer will receive notifications.',             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'pkcCustomer',  @value=N'Defines the primary key for the Customer record using the CustomerId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO