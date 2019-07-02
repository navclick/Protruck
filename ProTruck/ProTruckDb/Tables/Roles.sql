CREATE TABLE [dbo].[Roles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Role] NCHAR(100) NULL, 
    [Desc] NCHAR(500) NULL, 
    [CreatedOn] DATE NULL, 
    [EcomID] INT NULL, 
    CONSTRAINT [FK_Roles_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [ExanaduCompanies]([id]), 
    
)
