CREATE TABLE [dbo].[LanseType]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(25) NULL, 
    [ActiveDays] INT NULL, 
    [ActivePerDay] INT NULL, 
    [ActiveHours] INT NULL, 
    [Price] INT NULL, 
    [Description] NCHAR(250) NOT NULL, 
    [Active] BIT NULL
)
