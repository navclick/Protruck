CREATE TABLE [dbo].[Modules]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(200) NULL, 
    [Controller] NCHAR(100) NULL, 
    [Action] NCHAR(100) NULL, 
    [IsActive] BIT NULL, 
    [Icon] NCHAR(300) NULL
)
