CREATE TABLE Inventory.InventoryTransaction
(
  InventoryId       INT          NOT NULL IDENTITY(1,1),
  ProductId         CHAR(5)      NOT NULL,
  InventoryActionId INT          NOT NULL,
  ActionDateTime    DATETIME2    NOT NULL CONSTRAINT dfInventory_ActionDateTime   DEFAULT(GETUTCDATE()),
  InventoryCredit   INT          NOT NULL CONSTRAINT dfInventory_InventoryCredit  DEFAULT(0),
  InventoryDebit    INT          NOT NULL CONSTRAINT dfInventory_InventoryDebit   DEFAULT(0),
  InventoryReserve  INT          NOT NULL CONSTRAINT dfInventory_InventoryReserve DEFAULT(0),
  OrderNumber       VARCHAR(100)     NULL,
  CONSTRAINT pkcInventory PRIMARY KEY CLUSTERED (InventoryId),
  CONSTRAINT fkInventory_Product         FOREIGN KEY (ProductId)         REFERENCES Product.Product (ProductId),
  CONSTRAINT fkInventory_InventoryAction FOREIGN KEY (InventoryActionId) REFERENCES Inventory.InventoryAction (InventoryActionId)
)
GO

EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction',                                             @value=N'Represents the inventory status of a product.',                                                                                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'InventoryId',                 @value=N'Identifier for the product inventory transaction.',                                                                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'ProductId',                   @value=N'Identifier for the product.',                                                                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'InventoryActionId',           @value=N'Identifier for the associated product inventory action.',                                                                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'ActionDateTime',              @value=N'The date and time of the product inventory transaction.',                                                                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'InventoryCredit',             @value=N'The number of items to credit the product inventory by.',                                                                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'InventoryDebit',              @value=N'The number of items to debit the product inventory by.',                                                                             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'InventoryReserve',            @value=N'The number of items to put on product inventory hold.',                                                                             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'OrderNumber',                 @value=N'Identifier for any associated product.',                                                                                             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'pkcInventory',                @value=N'Defines the primary key for the Inventory record using the InventoryId column.',                                       @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'fkInventory_Product',         @value=N'Defines the relationship between the Inventory and Product tables using the ProductId column.',                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'fkInventory_InventoryAction', @value=N'Defines the relationship between the Inventory and InventoryAction tables using the InventoryActionId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'dfInventory_ActionDateTime',  @value=N'Sets the default date/time of the transaction to the current UTC date/time.',                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'dfInventory_InventoryCredit', @value=N'Sets the default transaction credit value to 0.',                                                                                    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'dfInventory_InventoryDebit',  @value=N'Sets the default transaction debit value to 0.',                                                                                     @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryTransaction', @level2name=N'dfInventory_InventoryReserve',@value=N'Sets the default transaction reserve value to 0.',                                                                                   @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO