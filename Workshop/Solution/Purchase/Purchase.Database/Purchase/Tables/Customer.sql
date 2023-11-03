CREATE TABLE Purchase.Customer
(
  CustomerId          INT           NOT NULL IDENTITY(1,1),
  FirstName           NVARCHAR(100) NOT NULL,
  LastName            NVARCHAR(100) NOT NULL,
  StreetAddress       NVARCHAR(100) NOT NULL,
  City                NVARCHAR(100) NOT NULL,
  CountryDivisionCode CHAR(3)           NULL,
  CountryCode         CHAR(2)       NOT NULL,
  PostalCode          VARCHAR(20)       NULL,
  EmailAddress        VARCHAR(255)  NOT NULL,
  CONSTRAINT pkcCustomer PRIMARY KEY CLUSTERED (CustomerId),
  CONSTRAINT fkCustomer_Country         FOREIGN KEY (CountryCode)                      REFERENCES Core.Country (CountryCode),
  CONSTRAINT fkCustomer_CountryDivision FOREIGN KEY (CountryCode, CountryDivisionCode) REFERENCES Core.CountryDivision (CountryCode, CountryDivisionCode)
)
GO

EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer',                                            @value=N'Represents a customer making purchases.',                                                                                                       @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'CustomerId',                 @value=N'Identifier for the customer.',                                                                                                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'FirstName',                  @value=N'The first name of the customer.',                                                                                                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'LastName',                   @value=N'The last name of the customer.',                                                                                                                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'StreetAddress',              @value=N'The street address for the customer.',                                                                                                          @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'City',                       @value=N'The city for the customer shipping address.',                                                                                                   @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'CountryDivisionCode',        @value=N'Code for the country division for the customer shipping address.',                                                                              @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'CountryCode',                @value=N'Code for the country for the customer shipping address.',                                                                                       @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'PostalCode',                 @value=N'Postal code for the customer shipping address.',                                                                                                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'EmailAddress',               @value=N'Email address for the customer',                                                                                                                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'pkcCustomer',                @value=N'Defines the primary key for the Customer record using the CustomerId column.',                                                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'fkCustomer_Country',         @value=N'Defines the relationship between the Purchase.Customer and Core.Country tables using the CountryCode column.',                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Purchase', @level1name=N'Customer', @level2name=N'fkCustomer_CountryDivision', @value=N'Defines the relationship between the Purchase.Customer and Core.CountryDivision tables using the CountryCode and CountryDivisionCode columns.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO