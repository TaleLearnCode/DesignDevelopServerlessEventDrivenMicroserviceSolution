MERGE Inventory.ProductInventoryAction AS TARGET
USING (VALUES (1, 'Stock Received'),
              (2, 'Reserved for Order'),
              (3, 'Order Item Shipped'),
              (4, 'Order Item Cancelled'),
              (5, 'Inventory Adjustment'))
AS SOURCE (ProductInventoryActionId, ProductInventoryActionName)
ON TARGET.ProductInventoryActionId = SOURCE.ProductInventoryActionId
WHEN MATCHED THEN UPDATE SET TARGET.ProductInventoryActionName = SOURCE.ProductInventoryActionName
WHEN NOT MATCHED THEN INSERT (ProductInventoryActionId,
                              ProductInventoryActionName)
                      VALUES (SOURCE.ProductInventoryActionId,
                              SOURCE.ProductInventoryActionName);
GO