CREATE TABLE Product.Product
(
  ProductId   CHAR(5)       NOT NULL,
  ProductName NVARCHAR(100) NOT NULL,
  CONSTRAINT pkcProduct PRIMARY KEY CLUSTERED (ProductId)
)
GO

EXEC sp_addextendedproperty @level0name=N'Product', @level1name=N'Product',                             @value=N'Represents a product in inventory.',                                         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Product', @level1name=N'Product', @level2name=N'ProductId',   @value=N'Identifier for the product.',                                                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Product', @level1name=N'Product', @level2name=N'ProductName', @value=N'Name for the product.',                                                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Product', @level1name=N'Product', @level2name=N'pkcProduct',  @value=N'Defines the primary key for the Product record using the ProductId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO