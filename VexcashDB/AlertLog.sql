CREATE TABLE [dbo].[AlertLog]
(
	[AlertLogId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT NOT NULL, 
    [AlertText] NVARCHAR(MAX) NOT NULL, 
    [AlertTime] DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [FK_AlertLog_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([CustomerId])
)
