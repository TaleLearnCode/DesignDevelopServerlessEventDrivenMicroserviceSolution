CREATE TABLE OrderManagement.Customer
(
  CustomerId          INT           NOT NULL IDENTITY(1,1),
  FirstName           NVARCHAR(100) NOT NULL,
  LastName            NVARCHAR(100) NOT NULL,
  StreetAddress       NVARCHAR(100) NOT NULL,
  City                NVARCHAR(100) NOT NULL,
  CountryDivisionCode CHAR(2)           NULL,
  CountryCode         CHAR(2)       NOT NULL,
  PostalCode          VARCHAR(20)       NULL,
  EMailAddress        VARCHAR(255)  NOT NULL,
  CONSTRAINT pkcCustomer PRIMARY KEY CLUSTERED (CustomerId)
)