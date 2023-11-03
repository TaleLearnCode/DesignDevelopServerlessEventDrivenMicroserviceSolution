CREATE TABLE Purchase.Customer
(
  CustomerId          INT           NOT NULL,
  FirstName           NVARCHAR(100) NOT NULL,
  LastName            NVARCHAR(100) NOT NULL,
  StreetAddress       NVARCHAR(100) NOT NULL,
  City                NVARCHAR(100) NOT NULL,
  CountryDivisionCode CHAR(3)           NULL,
  CountryCode         CHAR(2)       NOT NULL,
  PostalCode          VARCHAR(20)       NULL,
  CONSTRAINT pkcCustomer PRIMARY KEY CLUSTERED (CustomerId)
)