CREATE TABLE Shipping.ShipmentStatus
(
  ShipmentStatusId   INT          NOT NULL,
  ShipmentStatusName VARCHAR(100) NOT NULL,
  CONSTRAINT pkcShipmentStatus PRIMARY KEY CLUSTERED (ShipmentStatusId)
)
GO

EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'ShipmentStatus',                                    @value=N'Represents the status for a shipment.',                                                    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'ShipmentStatus', @level2name=N'ShipmentStatusId',   @value=N'Identifier for the shipment status record.',                                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'ShipmentStatus', @level2name=N'ShipmentStatusName', @value=N'Name of the shipment status.',                                                             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Shipping', @level1name=N'ShipmentStatus', @level2name=N'pkcShipmentStatus',  @value=N'Defines the primary key for the ShipmentStatus record using the ShipmentStatusId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO