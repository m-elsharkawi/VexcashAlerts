CREATE TABLE [dbo].[AlertType]
(
	[AlertTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AlertTypeName] NVARCHAR(50) NOT NULL, 
    [CreationDate] DATETIME NOT NULL DEFAULT GETDATE(), 
    [LastUpdateDate] DATETIME NOT NULL DEFAULT GETDATE(), 
    [IsActive] BIT NOT NULL DEFAULT 1
);

GO

CREATE TRIGGER [dbo].[trg_AlertType_LastUpdateDate]
    ON [dbo].[AlertType]
    AFTER UPDATE
    AS
    BEGIN
        SET NoCount ON
        UPDATE dbo.AlertType
        SET LastUpdateDate = GETDATE()
        WHERE AlertTypeId IN (SELECT DISTINCT AlertTypeId FROM inserted);

    END