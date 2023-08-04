CREATE TABLE Shipping.Shipment
(
  ShipmentId       INT      NOT NULL IDENTITY(1,1),
  ShipmentStatusId INT      NOT NULL,
  CustomerOrderId  CHAR(36) NOT NULL,
  CONSTRAINT pkcShipment PRIMARY KEY CLUSTERED (ShipmentId),
  CONSTRAINT fkShipment_ShipmentStatus FOREIGN KEY (ShipmentStatusId) REFERENCES Shipping.ShipmentStatus (ShipmentStatusId),
  CONSTRAINT fkShipment_CustomerOrder  FOREIGN KEY (CustomerOrderId)  REFERENCES Shipping.CustomerOrder (CustomerOrderId)
)