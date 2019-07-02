CREATE TABLE [dbo].[Menus]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(100) NULL, 
    [Controller] NCHAR(100) NULL, 
    [Action] NCHAR(100) NULL, 
    [Icon] NCHAR(200) NULL, 
    [IsActive] NCHAR(10) NULL, 
    [ModuleID] INT NULL, 
    CONSTRAINT [FK_Menus_Modules] FOREIGN KEY ([ModuleID]) REFERENCES [Modules]([id]) 
)
