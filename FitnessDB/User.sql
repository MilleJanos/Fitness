CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Barcode] NCHAR(20) NOT NULL, 
    [FirstName] NCHAR(30) NOT NULL, 
    [LastName] NCHAR(30) NOT NULL, 
    [BirthDate] DATE NOT NULL, 
    [Email] NCHAR(200) NULL, 
    [PhoneNumber] NCHAR(20) NULL, 
    [ImageId] IMAGE NOT NULL, 
    [Role] NCHAR(15) NULL
)