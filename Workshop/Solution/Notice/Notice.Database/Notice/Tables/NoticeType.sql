CREATE TABLE Notice.NoticeType
(
  NoticeTypeId   INT NOT NULL,
  NoticeTypeName VARCHAR(100) NOT NULL,
  CONSTRAINT pkcNoticeType PRIMARY KEY CLUSTERED (NoticeTypeId)
)
GO

EXEC sp_addextendedproperty @level0name=N'Notice', @level1name=N'NoticeType',                                @value=N'Represents the types of notices sent to customers.',                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Notice', @level1name=N'NoticeType', @level2name=N'NoticeTypeId',   @value=N'Identifier for the notice type.',                                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Notice', @level1name=N'NoticeType', @level2name=N'NoticeTypeName', @value=N'Name of the notice type.',                                                         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Notice', @level1name=N'NoticeType', @level2name=N'pkcNoticeType',  @value=N'Defines the primary key for the NoticeType record using the NoticeTypeId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO