MERGE INTO Purchase.Customer AS TARGET
USING (VALUES (1, 'Julie',     'Hartshorn', '2598 Butternut Lane',   'Ava',             'IL', 'US', '62707'),
              (2, 'William',   'Pierce',    '859 Courtright Street', 'Gardner',         'ND', 'US', '58036'),
              (3, 'Christine', 'Brandt',    '3428 Burnside Avenue',  'Monument Valley', 'UT', 'US', '84536'),
              (4, 'Patsy',     'Hauser',    '121 Old Dear Lane',     'Marlboro',        'NY', 'US', '12542'),
              (5, 'Carlos',    'Riley',     '2949 White River Way',  'Salt Lake City',  'UT', 'US', '84104'),
              (6, 'Edward',    'Tate',      '2776 MacLaren Street',  'Ottawa',          'ON', 'CA', 'K1P 5M7'),
              (7, 'Christi',   'Miller',    '775 Lynden Road',       'Orono',           'ON', 'CA', 'L0B 1M0'))
AS SOURCE (CustomerId, FirstName, LastName, StreetAddress, City, CountryDivisionCode, CountryCode, PostalCode)
ON TARGET.CustomerId = SOURCE.CustomerId
WHEN MATCHED THEN UPDATE SET TARGET.FirstName           = SOURCE.FirstName,
                             TARGET.LastName            = SOURCE.LastName,
                             TARGET.StreetAddress       = SOURCE.StreetAddress,
                             TARGET.City                = SOURCE.City,
                             TARGET.CountryDivisionCode = SOURCE.CountryDivisionCode,
                             TARGET.CountryCode         = SOURCE.CountryCode,
                             TARGET.PostalCode          = SOURCE.PostalCode
WHEN NOT MATCHED THEN INSERT (CustomerId,
                              FirstName,
                              LastName,
                              StreetAddress,
                              City,
                              CountryDivisionCode,
                              CountryCode,
                              PostalCode)
                      VALUES (SOURCE.CustomerId,
                              SOURCE.FirstName,
                              SOURCE.LastName,
                              SOURCE.StreetAddress,
                              SOURCE.City,
                              SOURCE.CountryDivisionCode,
                              SOURCE.CountryCode,
                              SOURCE.PostalCode);