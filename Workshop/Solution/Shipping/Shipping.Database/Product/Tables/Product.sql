CREATE TABLE Product.Product
(
  ProductId     CHAR(5)       NOT NULL,
  ProductName   NVARCHAR(100) NOT NULL,
  ProductWeight INT           NOT NULL,
  CONSTRAINT pkcProduct PRIMARY KEY CLUSTERED (ProductId)
)