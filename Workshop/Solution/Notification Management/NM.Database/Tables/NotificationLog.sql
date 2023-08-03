CREATE TABLE NotificationManagement.NotificationLog
(
  NotificationLogId  INT NOT NULL IDENTITY(1,1),
  NotificationTypeId INT NOT NULL,
  CustomerId         INT NOT NULL,
  SentDateTime       DATETIME2 NOT NULL CONSTRAINT dfNotificationLog_SendDateTime DEFAULT(GETUTCDATE()),
  CONSTRAINT pkcNotificationLog PRIMARY KEY CLUSTERED (NotificationLogId),
  CONSTRAINT fkNotificationLog_NotificationType FOREIGN KEY (NotificationTypeId) REFERENCES NotificationManagement.NotificationType (NotificationTypeId),
  CONSTRAINT fkNotificationLog_Customer         FOREIGN KEY (CustomerId)         REFERENCES NotificationManagement.Customer (CustomerId)
)