CREATE TABLE [dbo].[Lanse]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TypeId] INT NOT NULL, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NULL, 
    [Active] BINARY(1) NOT NULL, 
    [Price] INT NOT NULL, 
    [SearchIndex] NCHAR(10) NULL,
	[TimesUsed] INT NULL
)