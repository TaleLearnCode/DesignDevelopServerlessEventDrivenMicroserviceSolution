﻿MERGE INTO Inventory.Product AS TARGET
USING (VALUES ('10255', 'Assembly Square'),
              ('10265',	'Ford Mustang'),
              ('10266',	'NASA Apollo 11 Lunar Lander'),
              ('10270',	'Bookshop'),
              ('10273',	'Hauned House'),
              ('10274',	'Ghostbusters™ ECTO-1'),
              ('10276',	'Colosseum'),
              ('10278',	'Police Station'),
              ('10280',	'Flower Bouquet'),
              ('10281',	'Bonsai Tree'),
              ('10283',	'NASA Space Shuttle Discovery'),
              ('10290',	'Pickup Truck'),
              ('10292',	'The Friends Apartments'),
              ('10293',	'Santa''s Visit'),
              ('10294',	'LEGO® Titanic'),
              ('10295',	'Porsche 911'),
              ('10297',	'Boutique Hotel'),
              ('10298',	'Vespa 125'),
              ('10299',	'Real Madrid – Santiago Bernabéu Stadium'),
              ('10300',	'Back to the Future Time Machine'),
              ('10302',	'Optimus Prime'),
              ('10303',	'Loop Coaster'),
              ('10304',	'Chevrolet Camaro Z28'),
              ('10305',	'Bonsai Tree'),
              ('10306',	'Atari® 2600'),
              ('10307',	'Eiffel tower'),
              ('10309',	'Succulents'),
              ('10312',	'Jazz Club'),
              ('10314',	'Corvette'),
              ('10315',	'Tranquil Garden'),
              ('10316',	'THE LORD OF THE RINGS: RIVENDELL™'),
              ('10317',	'Land Rover Classic Defender 90'),
              ('10320',	'Eldorado Fortress'),
              ('10321',	'Corvette'),
              ('10323',	'PAC-MAN Arcade'),
              ('10497',	'Galaxy Explorer'),
              ('21028',	'New York City'),
              ('21034',	'London'),
              ('21042',	'Statue of Liberty'),
              ('21044',	'Paris'),
              ('21054',	'The White House'),
              ('21056',	'Taj Mahal'),
              ('21057',	'Statue of Liberty'),
              ('21058',	'Great Pyramid of Giza'),
              ('21060',	'Himeji Castle'),
              ('21318',	'Tree House'),
              ('21323',	'Grand Piano'),
              ('21325',	'Medieval Blacksmith'),
              ('21326',	'Winnie the Pooh'),
              ('21327',	'Typewriter'),
              ('21330',	'LEGO® Ideas Home Alone'),
              ('21332',	'The Globe'),
              ('21334',	'Jazz Quartet'),
              ('21335',	'Motorized Lighthouse'),
              ('21336',	'The Office'),
              ('21337',	'Table Football'),
              ('21338',	'A-Frame Cabin'),
              ('21339',	'BTS Dynamite'),
              ('21340',	'Tales of the Space Age'),
              ('21341',	'Disney Hocus Pocus: The Sanderson Sisters'' Cottage'),
              ('40220',	'London Bus'),
              ('40517',	'Vespa'),
              ('40518', 'High Speed Train'))
AS SOURCE (ProductId, ProductName)
ON TARGET.ProductId = SOURCE.ProductId
WHEN MATCHED THEN UPDATE SET TARGET.ProductName = SOURCE.ProductName
WHEN NOT MATCHED THEN INSERT (ProductId,
                              ProductName)
                      VALUES (SOURCE.ProductId,
                              SOURCE.ProductName);