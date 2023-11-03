CREATE TABLE Purchase.PurchaseStatus
(
  PurchaseStatusId   INT NOT NULL,
  PurchaseStatusName VARCHAR(100) NOT NULL,
  CONSTRAINT pkcPurchaseStatus PRIMARY KEY CLUSTERED (PurchaseStatusId)
)
GO

EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseStatus',                                    @value=N'Represents the status of a purchase.',                                                     @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseStatus', @level2name=N'PurchaseStatusId',   @value=N'Identifier for the purchase status.',                                                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseStatus', @level2name=N'PurchaseStatusName', @value=N'Name for the purchase status.',                                                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'PurchaseStatus', @level2name=N'pkcPurchaseStatus',  @value=N'Defines the primary key for the PurchaseStatus record using the PurchaseStatusId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO