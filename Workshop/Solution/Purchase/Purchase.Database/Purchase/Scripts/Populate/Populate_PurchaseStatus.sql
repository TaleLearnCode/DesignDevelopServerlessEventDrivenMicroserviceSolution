MERGE INTO Purchase.PurchaseStatus AS TARGET
USING (VALUES (1, 'Placed'),
              (2, 'Reserved'),
              (3, 'Shipped'),
              (4, 'Complete'))
AS SOURCE (PurchaseStatusId, PurchaseStatusName)
ON TARGET.PurchaseStatusId = SOURCE.PurchaseStatusId
WHEN MATCHED THEN UPDATE SET TARGET.PurchaseStatusName = SOURCE.PurchaseStatusName
WHEN NOT MATCHED THEN INSERT (PurchaseStatusId,
                              PurchaseStatusName)
                      VALUES (SOURCE.PurchaseStatusId,
                              SOURCE.PurchaseStatusName);
GO