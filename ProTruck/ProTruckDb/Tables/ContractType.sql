CREATE TABLE [dbo].[ContractType]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Type] NCHAR(10) NULL, 
    [EcomID] INT NULL, 
    [CreatedOn] DATE NULL, 
    CONSTRAINT [FK_ContractType_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [ExanaduCompanies]([Id])
)
