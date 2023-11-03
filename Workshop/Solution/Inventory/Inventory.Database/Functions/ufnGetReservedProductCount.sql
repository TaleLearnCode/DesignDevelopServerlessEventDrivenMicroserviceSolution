CREATE FUNCTION Inventory.ufnGetReservedProductCount
(
  @ProductId CHAR(5)
)
RETURNS INT
AS
BEGIN
  DECLARE @Reserved INT
  SELECT @Reserved = SUM(InventoryReserve) FROM Inventory.InventoryTransaction WHERE ProductId = @ProductId
  RETURN @Reserved
END
GO