CREATE TABLE [dbo].[AlertTemplate]
(
	[AlertTemplateId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AlertTemplateName] NVARCHAR(50) NOT NULL, 
    [AlertTypeId] INT NOT NULL, 
    [AlertSubject] NVARCHAR(50) NOT NULL, 
    [AlertText] NVARCHAR(MAX) NOT NULL, 
    [CreationDate] DATETIME NOT NULL DEFAULT GETDATE(), 
    [LastUpdateDate] DATETIME NOT NULL DEFAULT GETDATE(),
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_AlertTemplate_AlertType] FOREIGN KEY ([AlertTypeId]) REFERENCES [AlertType]([AlertTypeId])
    
);


GO

CREATE TRIGGER [dbo].[trg_EmailTemplate_LastUpdateDate]
    ON [dbo].[AlertTemplate]
    AFTER UPDATE
    AS
    BEGIN
        SET NoCount ON
        UPDATE dbo.AlertTemplate
        SET LastUpdateDate = GETDATE()
        WHERE AlertTemplateId IN (SELECT DISTINCT AlertTemplateId FROM inserted);
    END
