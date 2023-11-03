MERGE Inventory.InventoryAction AS TARGET
USING (VALUES (1, 'Stock Received'),
              (2, 'Reserved for Order'),
              (3, 'Order Item Shipped'),
              (4, 'Order Item Canceled'),
              (5, 'Inventory Adjustment'))
AS SOURCE (InventoryActionId, InventoryActionName)
ON TARGET.InventoryActionId = SOURCE.InventoryActionId
WHEN MATCHED THEN UPDATE SET TARGET.InventoryActionName = SOURCE.InventoryActionName
WHEN NOT MATCHED THEN INSERT (InventoryActionId,
                              InventoryActionName)
                      VALUES (SOURCE.InventoryActionId,
                              SOURCE.InventoryActionName);
GO