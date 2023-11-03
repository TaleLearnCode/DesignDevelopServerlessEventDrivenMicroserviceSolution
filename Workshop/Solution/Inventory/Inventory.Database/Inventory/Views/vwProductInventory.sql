CREATE VIEW Inventory.vwProductInventory
AS
SELECT Product.ProductId                                         ProductId,
       Product.ProductName                                       ProductName,
       Inventory.ufnGetProductInventoryOnHand(Product.ProductId) ProductInventoryOnHand,
       Inventory.ufnGetReservedProductCount(Product.ProductId)   ReservedCount
  FROM Product.Product
GO