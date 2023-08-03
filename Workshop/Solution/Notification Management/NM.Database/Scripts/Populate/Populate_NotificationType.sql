MERGE INTO NotificationManagement.NotificationType AS TARGET
USING (VALUES (1, 'Order Confirmation'),
              (2, 'Order Shipped'),
              (3, 'Order Received'))
AS SOURCE (NotificationTypeId, NotificationTypeName)
ON TARGET.NotificationTypeId = SOURCE.NotificationTypeId
WHEN MATCHED THEN UPDATE SET TARGET.NotificationTypeName = SOURCE.NotificationTypeName
WHEN NOT MATCHED THEN INSERT (NotificationTypeId,
                              NotificationTypeName)
                      VALUES (SOURCE.NotificationTypeId,
                              SOURCE.NotificationTypeName);