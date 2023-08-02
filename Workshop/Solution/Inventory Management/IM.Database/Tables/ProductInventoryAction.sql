CREATE TABLE Inventory.ProductInventoryAction
(
  ProductInventoryActionId   INT NOT NULL,
  ProductInventoryActionName NVARCHAR(100),
  CONSTRAINT pkcProductInventoryAction PRIMARY KEY CLUSTERED (ProductInventoryActionId)
)