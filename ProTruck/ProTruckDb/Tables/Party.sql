CREATE TABLE [dbo].[Party]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Party] NCHAR(100) NULL, 
    [ConectPerson] NCHAR(15) NULL, 
    [Phone] NCHAR(15) NULL, 
    [IsSubParty] BIT NULL, 
    [CreatedOn] DATE NULL,
	[ParentId] INT NULL,
    [EcomID] INT NULL, 
    CONSTRAINT [FK_Party_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [ExanaduCompanies]([Id])
)
