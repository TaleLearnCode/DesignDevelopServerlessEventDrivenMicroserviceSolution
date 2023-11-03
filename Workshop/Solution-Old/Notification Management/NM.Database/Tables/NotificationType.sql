CREATE TABLE NotificationManagement.NotificationType
(
  NotificationTypeId   INT NOT NULL,
  NotificationTypeName VARCHAR(100) NOT NULL,
  CONSTRAINT pkcNotificationType PRIMARY KEY CLUSTERED (NotificationTypeId)
)