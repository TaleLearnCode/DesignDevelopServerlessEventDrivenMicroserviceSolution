CREATE TABLE Inventory.InventoryAction
(
  InventoryActionId   INT NOT NULL,
  InventoryActionName NVARCHAR(100),
  CONSTRAINT pkcInventoryAction PRIMARY KEY CLUSTERED (InventoryActionId)
)
GO

EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryAction',                                     @value=N'Represents a type of action taken on the inventory of a product.',                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryAction', @level2name=N'InventoryActionId',   @value=N'Identifier for the inventory action.',                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryAction', @level2name=N'InventoryActionName', @value=N'Name for the inventory action.',                                                              @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Inventory', @level1name=N'InventoryAction', @level2name=N'pkcInventoryAction',  @value=N'Defines the primary key for the InventoryAction record using the InventoryActionId column.',  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO