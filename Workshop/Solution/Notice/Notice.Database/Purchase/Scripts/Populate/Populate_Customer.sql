MERGE INTO Purchase.Customer AS TARGET
USING (VALUES (1, 'Julie.Hartshorn@chefscrest.com'),
              (2, 'William.Pierce@chefscrest.com'),
              (3, 'Christine.Brandt@chefscrest.com'),
              (4, 'Patsy.Hauser@chefscrest.com'),
              (5, 'Carlos.Riley@chefscrest.com'),
              (6, 'Edward.Tate@chefscrest.com'),
              (7, 'Christi.Miller@chefscrest.com'))
AS SOURCE (CustomerId, EmailAddress)
ON TARGET.CustomerId = SOURCE.CustomerId
WHEN MATCHED THEN UPDATE SET TARGET.EmailAddress        = SOURCE.EmailAddress
WHEN NOT MATCHED THEN INSERT (CustomerId,
                              EmailAddress)
                      VALUES (SOURCE.CustomerId,
                              SOURCE.EmailAddress);