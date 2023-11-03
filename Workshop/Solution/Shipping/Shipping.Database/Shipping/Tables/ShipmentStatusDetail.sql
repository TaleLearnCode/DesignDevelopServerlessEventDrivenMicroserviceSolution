CREATE TABLE Shipping.ShipmentStatusDetail
(
  ShipmentStatusDetailId INT       NOT NULL IDENTITY(1,1),
  ShipmentId             INT       NOT NULL,
  ShipmentStatusId       INT       NOT NULL,
  StatusDateTime         DATETIME2 NOT NULL CONSTRAINT dfShipmentStatusDetail_StatusDateTime DEFAULT(GETUTCDATE()),
  CONSTRAINT pkcShipmentStatusDetail PRIMARY KEY CLUSTERED (ShipmentStatusDetailId),
  CONSTRAINT fkShipmentStatusDetail_Shipment        FOREIGN KEY (ShipmentId)       REFERENCES Shipping.Shipment (ShipmentId),
  CONSTRAINT fkShipmentStatusDetails_ShipmentStatus FOREIGN KEY (ShipmentStatusId) REFERENCES Shipping.ShipmentStatus (ShipmentStatusId)
)
GO

EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'ShipmentStatusDetail',                                                        @value=N'Represents the status for a shipment.',                                                                                                    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'ShipmentStatusDetail', @level2name=N'ShipmentStatusDetailId',                 @value=N'Identifier for the shipment status detail record.',                                                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'ShipmentStatusDetail', @level2name=N'ShipmentId',                             @value=N'Identifier for the associated shipment record.',                                                                                           @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'ShipmentStatusDetail', @level2name=N'ShipmentStatusId',                       @value=N'Identifier for the associated shipment status.',                                                                                           @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'ShipmentStatusDetail', @level2name=N'StatusDateTime',                         @value=N'The UTC date/time of the shipment status.',                                                                                                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'ShipmentStatusDetail', @level2name=N'pkcShipmentStatusDetail',                @value=N'Defines the primary key for the ShipmentStatusDetail record using the ShipmentStatusDetailId column.',                                     @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'ShipmentStatusDetail', @level2name=N'fkShipmentStatusDetail_Shipment',        @value=N'Defines the relationship between the Shipment.ShipmentStatusDetail and Shipment.Shipment tables using the ShipmentId column.',             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'ShipmentStatusDetail', @level2name=N'fkShipmentStatusDetails_ShipmentStatus', @value=N'Defines the relationship between the Shipment.ShipmentStatusDetail and Shipment.ShipmentStatus tables using the ShipmentStatusId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO