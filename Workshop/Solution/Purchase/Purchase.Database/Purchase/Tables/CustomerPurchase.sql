CREATE TABLE Purchase.CustomerPurchase
(
  CustomerPurchaseId CHAR(36)  NOT NULL,
  CustomerId         INT       NOT NULL,
  PurchaseStatusId   INT       NOT NULL CONSTRAINT dfCustomerPurchase_PurchaseStatusId DEFAULT(1),
  PurchaseDateTime   DATETIME2 NOT NULL CONSTRAINT dfCustomerPurchase_PurchaseDateTime DEFAULT(GETUTCDATE()),
  ReserveDateTime    DATETIME2     NULL,
  ShipDateTime       DATETIME2     NULL,
  CompleteDateTime   DATETIME2     NULL,
  CONSTRAINT pkcCustomerPurchase PRIMARY KEY CLUSTERED (CustomerPurchaseId),
  CONSTRAINT fkCustomerPurchase_Customer       FOREIGN KEY (CustomerId)       REFERENCES Purchase.Customer (CustomerId),
  CONSTRAINT fkCustomerPurchase_PurchaseStatus FOREIGN KEY (PurchaseStatusId) REFERENCES Purchase.PurchaseStatus (PurchaseStatusId)
)
GO

EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'CustomerPurchase',                                                   @value=N'Represents a purchase by a customer.',                                                                                                 @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'CustomerPurchase', @level2name=N'CustomerPurchaseId',                @value=N'Identifier for the customer purchase.',                                                                                                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'CustomerPurchase', @level2name=N'CustomerId',                        @value=N'Identifier for the associated customer.',                                                                                              @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'CustomerPurchase', @level2name=N'PurchaseStatusId',                  @value=N'Identifier for the current purchase status.',                                                                                          @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'CustomerPurchase', @level2name=N'PurchaseDateTime',                  @value=N'The UTC date and time of the purchase.',                                                                                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'CustomerPurchase', @level2name=N'ReserveDateTime',                   @value=N'The UTC date and time of when the product(s) are reserved for the purchase.',                                                          @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'CustomerPurchase', @level2name=N'ShipDateTime',                      @value=N'The UTC date and time of when the purchase is shipped.',                                                                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'CustomerPurchase', @level2name=N'CompleteDateTime',                  @value=N'The UTC date and time of when the purchase is completed (shipment received).',                                                         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'CustomerPurchase', @level2name=N'pkcCustomerPurchase',               @value=N'Defines the primary key for the CustomerPurchase record using the CustomerPurchaseId column.',                                         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'CustomerPurchase', @level2name=N'fkCustomerPurchase_Customer',       @value=N'Defines the relationship between the Purchase.CustomerPurchase and Purchase.Customer tables using the CustomerId column.',             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'CustomerPurchase', @level2name=N'fkCustomerPurchase_PurchaseStatus', @value=N'Defines the relationship between the Purchase.CustomerPurchase and Purchase.PurchaseStatus tables using the PurchaseStatusId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO