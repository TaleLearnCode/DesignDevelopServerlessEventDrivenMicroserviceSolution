CREATE TABLE Shipping.Shipment
(
  ShipmentId         INT                                            NOT NULL IDENTITY(1,1),
  ShipmentStatusId   INT                                            NOT NULL,
  CustomerPurchaseId CHAR(36)                                       NOT NULL,
  ValidFrom          DATETIME2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
  ValidTo            DATETIME2 GENERATED ALWAYS AS ROW END   HIDDEN NOT NULL,
  PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo),
  CONSTRAINT pkcShipment PRIMARY KEY CLUSTERED (ShipmentId),
  CONSTRAINT fkShipment_ShipmentStatus   FOREIGN KEY (ShipmentStatusId)   REFERENCES Shipping.ShipmentStatus (ShipmentStatusId),
  CONSTRAINT fkShipment_CustomerPurchase FOREIGN KEY (CustomerPurchaseId) REFERENCES Purchase.CustomerPurchase (CustomerPurchaseId)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = Shipping.ShipmentHistory))
GO

EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'Shipment',                                             @value=N'Represents a shipment of product to a customer.',                                                                                                       @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'Shipment', @level2name=N'ShipmentId',                  @value=N'Identifier for the shipment.',                                                                                                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'Shipment', @level2name=N'ShipmentStatusId',            @value=N'Identifier for the associated shipment status.',                                                                                                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'Shipment', @level2name=N'CustomerPurchaseId',          @value=N'Identifier for the associated customer purchase.',                                                                                                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'Shipment', @level2name=N'ValidFrom',                   @value=N'The start date and time for the valid period of the current record.',                                                                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'Shipment', @level2name=N'ValidTo',                     @value=N'The end date and time for the valid period of the current record.',                                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'Shipment', @level2name=N'pkcShipment',                 @value=N'Defines the primary key for the Shipment record using the ShipmentId column.',                                                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'Shipment', @level2name=N'fkShipment_ShipmentStatus',   @value=N'Defines the relationship between the Purchase.Shipment and Purchase.ShipmentStatus tables using the CountryCode column.',                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'Shipment', @level2name=N'fkShipment_CustomerPurchase', @value=N'Defines the relationship between the Purchase.Shipment and Purchase.CustomerPurchase tables using the CountryCode column.',                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
