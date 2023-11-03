MERGE INTO Notice.NoticeType AS TARGET
USING (VALUES (1, 'Order Confirmation'),
              (2, 'Backorder Notice'),
              (3, 'Order Shipped'),
              (4, 'Order Received'))
AS SOURCE (NoticeTypeId, NoticeTypeName)
ON TARGET.NoticeTypeId = SOURCE.NoticeTypeId
WHEN MATCHED THEN UPDATE SET TARGET.NoticeTypeName = SOURCE.NoticeTypeName
WHEN NOT MATCHED THEN INSERT (NoticeTypeId,
                              NoticeTypeName)
                      VALUES (SOURCE.NoticeTypeId,
                              SOURCE.NoticeTypeName);