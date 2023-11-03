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