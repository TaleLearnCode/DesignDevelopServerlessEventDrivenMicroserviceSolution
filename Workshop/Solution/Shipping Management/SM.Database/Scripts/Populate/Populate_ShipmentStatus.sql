MERGE INTO Shipping.ShipmentStatus AS TARGET
USING (VALUES (1, 'Picking'),
              (2, 'Packed'),
              (3, 'Shipped'),
              (4, 'Delivered'))
AS SOURCE (ShipmentStatusId, ShipmentStatusName)
ON TARGET.ShipmentStatusId = SOURCE.ShipmentStatusId
WHEN MATCHED THEN UPDATE SET TARGET.ShipmentStatusName = SOURCE.ShipmentStatusName
WHEN NOT MATCHED THEN INSERT (ShipmentStatusId,
                              ShipmentStatusName)
                      VALUES (SOURCE.ShipmentStatusId,
                              SOURCE.ShipmentStatusName);