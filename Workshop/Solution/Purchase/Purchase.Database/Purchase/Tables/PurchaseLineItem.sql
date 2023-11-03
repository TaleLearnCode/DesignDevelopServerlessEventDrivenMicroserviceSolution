CREATE TABLE Purchase.PurchaseLineItem
(
  PurchaseLineItemId INT                                             NOT NULL IDENTITY(1,1),
  CustomerPurchaseId CHAR(36)                                        NOT NULL,
  ProductId          CHAR(5)                                         NOT NULL,
  Quantity           INT                                             NOT NULL,
  ProductPrice       SMALLMONEY                                      NOT NULL,
  PurchaseStatusId   INT                                             NOT NULL CONSTRAINT dfOrderItem_OrderStatusId DEFAULT(1),
  DateTimeAdded      DATETIME2                                       NOT NULL CONSTRAINT dfOrderItem_DateTimeAdded DEFAULT(GETUTCDATE()),
  ValidFrom          DATETIME2  GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
  ValidTo            DATETIME2  GENERATED ALWAYS AS ROW END   HIDDEN NOT NULL,
  PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo),
  CONSTRAINT pkcPurchaseLineItem PRIMARY KEY CLUSTERED (PurchaseLineItemId),
  CONSTRAINT fkPurchaseLineItem_CustomerPurchase FOREIGN KEY (CustomerPurchaseId) REFERENCES Purchase.CustomerPurchase (CustomerPurchaseId),
  CONSTRAINT fkPurchaseLineItem_Product          FOREIGN KEY (ProductId)          REFERENCES Product.Product (ProductId),
  CONSTRAINT fkPurchaseLineItem_PurchaseStatus   FOREIGN KEY (PurchaseStatusId)   REFERENCES Purchase.PurchaseStatus (PurchaseStatusId)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = Purchase.PurchaseLineItemHistory))
GO

EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseLineItem',                                                     @value=N'Represents a line item within a purchase.',                                                                                                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseLineItem', @level2name=N'PurchaseLineItemId',                  @value=N'Identifier for the purchase line item.',                                                                                                   @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseLineItem', @level2name=N'CustomerPurchaseId',                  @value=N'Identifier for the associated customer purchase.',                                                                                         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseLineItem', @level2name=N'ProductId',                           @value=N'Identifier for the associated product.',                                                                                                   @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseLineItem', @level2name=N'Quantity',                            @value=N'The quantity of product being purchased.',                                                                                                 @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseLineItem', @level2name=N'ProductPrice',                        @value=N'The purchase price of the product.',                                                                                                       @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseLineItem', @level2name=N'PurchaseStatusId',                    @value=N'Identifier of the current status for the line item.',                                                                                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseLineItem', @level2name=N'ValidFrom',                           @value=N'The start date and time for the valid period of the current record.',                                                                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseLineItem', @level2name=N'ValidTo',                             @value=N'The end date and time for the valid period of the current record.',                                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseLineItem', @level2name=N'pkcPurchaseLineItem',                 @value=N'Defines the primary key for the PurchaseLineItem record using the PurchaseLineItemId column.',                                             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseLineItem', @level2name=N'fkPurchaseLineItem_CustomerPurchase', @value=N'Defines the relationship between the Purchase.PurchaseLineItem and Purchase.CustomerPurchase tables using the CustomerPurchaseId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseLineItem', @level2name=N'fkPurchaseLineItem_Product',          @value=N'Defines the relationship between the Purchase.PurchaseLineItem and Product.Product tables using the ProductId column.',                    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseLineItem', @level2name=N'fkPurchaseLineItem_PurchaseStatus',      @value=N'Defines the relationship between the Purchase.PurchaseLineItem and Purchase.PurchaseStatus tables using the PurchaseStatusId column.',  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO