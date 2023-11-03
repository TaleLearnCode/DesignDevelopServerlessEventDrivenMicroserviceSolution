-- emailfake.com

SET IDENTITY_INSERT Purchase.Customer ON
GO

MERGE INTO Purchase.Customer AS TARGET
USING (VALUES (1, 'Julie',     'Hartshorn', 'Julie.Hartshorn@chefscrest.com',  '2598 Butternut Lane',   'Ava',             'IL', 'US', '62707'),
              (2, 'William',   'Pierce',    'William.Pierce@chefscrest.com',   '859 Courtright Street', 'Gardner',         'ND', 'US', '58036'),
              (3, 'Christine', 'Brandt',    'Christine.Brandt@chefscrest.com', '3428 Burnside Avenue',  'Monument Valley', 'UT', 'US', '84536'),
              (4, 'Patsy',     'Hauser',    'Patsy.Hauser@chefscrest.com',     '121 Old Dear Lane',     'Marlboro',        'NY', 'US', '12542'),
              (5, 'Carlos',    'Riley',     'Carlos.Riley@chefscrest.com',     '2949 White River Way',  'Salt Lake City',  'UT', 'US', '84104'),
              (6, 'Edward',    'Tate',      'Edward.Tate@chefscrest.com',      '2776 MacLaren Street',  'Ottawa',          'ON', 'CA', 'K1P 5M7'),
              (7, 'Christi',   'Miller',    'Christi.Miller@chefscrest.com',   '775 Lynden Road',       'Orono',           'ON', 'CA', 'L0B 1M0'))
AS SOURCE (CustomerId, FirstName, LastName, EmailAddress, StreetAddress, City, CountryDivisionCode, CountryCode, PostalCode)
ON TARGET.CustomerId = SOURCE.CustomerId
WHEN MATCHED THEN UPDATE SET TARGET.FirstName           = SOURCE.FirstName,
                             TARGET.LastName            = SOURCE.LastName,
                             TARGET.EmailAddress        = SOURCE.EmailAddress,
                             TARGET.StreetAddress       = SOURCE.StreetAddress,
                             TARGET.City                = SOURCE.City,
                             TARGET.CountryDivisionCode = SOURCE.CountryDivisionCode,
                             TARGET.CountryCode         = SOURCE.CountryCode,
                             TARGET.PostalCode          = SOURCE.PostalCode
WHEN NOT MATCHED THEN INSERT (CustomerId,
                              FirstName,
                              LastName,
                              EmailAddress,
                              StreetAddress,
                              City,
                              CountryDivisionCode,
                              CountryCode,
                              PostalCode)
                      VALUES (SOURCE.CustomerId,
                              SOURCE.FirstName,
                              SOURCE.LastName,
                              SOURCE.EmailAddress,
                              SOURCE.StreetAddress,
                              SOURCE.City,
                              SOURCE.CountryDivisionCode,
                              SOURCE.CountryCode,
                              SOURCE.PostalCode);

SET IDENTITY_INSERT Purchase.Customer OFF
GO