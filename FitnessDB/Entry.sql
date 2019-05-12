CREATE TABLE [dbo].[Entry]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NULL, 
    [Barcode] NCHAR(20) NULL, 
    [Date] DATE NULL, 
    [ReceptionistId] INT NULL
)