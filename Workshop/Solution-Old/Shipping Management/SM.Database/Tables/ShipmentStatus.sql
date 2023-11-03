CREATE TABLE Shipping.ShipmentStatus
(
  ShipmentStatusId   INT          NOT NULL,
  ShipmentStatusName VARCHAR(100) NOT NULL,
  CONSTRAINT pkcShipmentStatus PRIMARY KEY CLUSTERED (ShipmentStatusId)
)