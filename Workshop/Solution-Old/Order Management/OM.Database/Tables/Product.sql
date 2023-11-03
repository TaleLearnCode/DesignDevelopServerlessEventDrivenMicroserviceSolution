CREATE TABLE OrderManagement.Product
(
  ProductId   CHAR(5)       NOT NULL,
  ProductName NVARCHAR(100) NOT NULL,
  Price       SMALLMONEY    NOT NULL,
  CONSTRAINT pkcProduct PRIMARY KEY CLUSTERED (ProductId)
)