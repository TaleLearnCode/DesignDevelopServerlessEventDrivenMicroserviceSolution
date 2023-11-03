CREATE TABLE Notice.NoticeLog
(
  NoticeLogId  VARCHAR(100)   NOT NULL,
  NoticeTypeId INT            NOT NULL,
  CustomerId   INT            NOT NULL,
  SentDateTime DATETIME2      NOT NULL CONSTRAINT dfNotificationLog_SendDateTime DEFAULT(GETUTCDATE()),
  NoticeBody   NVARCHAR(2000) NOT NULL,
  CONSTRAINT pkcNoticeLog PRIMARY KEY CLUSTERED (NoticeLogId),
  CONSTRAINT fkNotificationLog_NotificationType FOREIGN KEY (NoticeTypeId) REFERENCES Notice.NoticeType (NoticeTypeId),
  CONSTRAINT fkNotificationLog_Customer         FOREIGN KEY (CustomerId)   REFERENCES Purchase.Customer (CustomerId)
)
GO

EXEC sp_addextendedproperty @level0name=N'Notice', @level1name=N'NoticeLog',                                @value=N'Represents the log of notices sent to customers.',                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Notice', @level1name=N'NoticeLog', @level2name=N'NoticeLogId',    @value=N'Identifier for the notice log.',                                                 @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Notice', @level1name=N'NoticeLog', @level2name=N'NoticeTypeId',   @value=N'Identifier for the associated notice type.',                                     @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Notice', @level1name=N'NoticeLog', @level2name=N'CustomerId',     @value=N'Identifier for the associated customer.',                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Notice', @level1name=N'NoticeLog', @level2name=N'SentDateTime',   @value=N'The UTC date and time the notice was sent.',                                     @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Notice', @level1name=N'NoticeLog', @level2name=N'NoticeBody',     @value=N'The body of the notice message.',                                                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Notice', @level1name=N'NoticeLog', @level2name=N'pkcNoticeLog',   @value=N'Defines the primary key for the NoticeLog record using the NoticeLogId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO