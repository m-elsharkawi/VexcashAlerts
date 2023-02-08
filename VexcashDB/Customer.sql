CREATE TABLE [dbo].[Customer]
(
	[CustomerId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerName] NVARCHAR(50) NOT NULL, 
    [CreditNumber] NVARCHAR(50) NOT NULL, 
    [Amount] DECIMAL NULL, 
    [PhoneNumber] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [DueDate] DATE NULL, 
    [CreationDate] DATETIME NOT NULL DEFAULT GETDATE(), 
    [LastUpdateDate] DATETIME NOT NULL DEFAULT GETDATE(),
    [IsActive] BIT NOT NULL DEFAULT 1
);


GO

CREATE TRIGGER [dbo].[trg_Customer_LastUpdateDate]
    ON [dbo].[Customer]
    AFTER UPDATE
    AS
    BEGIN
        SET NoCount ON
        UPDATE dbo.Customer
        SET LastUpdateDate = GETDATE()
        WHERE CustomerId IN (SELECT DISTINCT CustomerId FROM inserted);
END

    
