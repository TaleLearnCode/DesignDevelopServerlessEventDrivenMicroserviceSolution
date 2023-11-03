CREATE TABLE Inventory.Product
(
  ProductId   CHAR(5)       NOT NULL,
  ProductName NVARCHAR(100) NOT NULL,
  CONSTRAINT pkcProduct PRIMARY KEY CLUSTERED (ProductId)
)