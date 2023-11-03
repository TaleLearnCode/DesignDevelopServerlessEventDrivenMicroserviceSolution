CREATE FUNCTION Inventory.ufnGetProductInventoryOnHand
(
  @ProductId CHAR(5)
)
RETURNS INT
AS
BEGIN
  
  DECLARE @Credits INT
  DECLARE @Debits INT
  DECLARE @Reserved INT
  
  SELECT @Credits = SUM(InventoryCredit) FROM Inventory.InventoryTransaction WHERE ProductId = @ProductId
  SELECT @Debits = SUM(InventoryDebit) FROM Inventory.InventoryTransaction WHERE ProductId = @ProductId
  SELECT @Reserved = SUM(InventoryReserve) FROM Inventory.InventoryTransaction WHERE ProductId = @ProductId


  RETURN @Credits - (@Debits + @Reserved)

END
GO