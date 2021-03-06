﻿CREATE TABLE [dbo].[Contract]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [ContractNo] NUMERIC NULL, 
    [ContractType] INT NULL, 
    [Party] INT NULL, 
    [TotatQty] FLOAT NULL, 
    [Unit] INT NULL, 
    [EcomID] INT NULL, 
    [CreatedOn] DATE NULL, 
    CONSTRAINT [FK_Contract_ContractType] FOREIGN KEY ([ContractType]) REFERENCES [ContractType]([Id]), 
    CONSTRAINT [FK_Contract_Party] FOREIGN KEY ([Party]) REFERENCES [Party]([Id]), 
    CONSTRAINT [FK_Contract_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [ExanaduCompanies]([Id])
)
