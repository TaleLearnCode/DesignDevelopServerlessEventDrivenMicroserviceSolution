CREATE TABLE Inventory.ProductInventory
(
  ProductInventoryId       INT          NOT NULL IDENTITY(1,1),
  ProductId                CHAR(5)      NOT NULL,
  ProductInventoryActionId INT          NOT NULL,
  ActionDateTime           DATETIME2    NOT NULL CONSTRAINT dfProductInventory_ActionDateTime DEFAULT(GETUTCDATE()),
  InventoryCredit          INT          NOT NULL CONSTRAINT dfProductInventory_InventoryCredit DEFAULT(0),
  InventoryDebit           INT          NOT NULL CONSTRAINT dfProductInventory_InventoryDebit DEFAULT(0),
  OrderNumber              VARCHAR(100)     NULL,
  CONSTRAINT pkcProductInventory PRIMARY KEY CLUSTERED (ProductInventoryId),
  CONSTRAINT fkProductInventory_Product FOREIGN KEY (ProductId) REFERENCES Inventory.Product (ProductId),
  CONSTRAINT fkProductInventory_ProductInventoryAction FOREIGN KEY (ProductInventoryActionId) REFERENCES Inventory.ProductInventoryAction (ProductInventoryActionId)
)