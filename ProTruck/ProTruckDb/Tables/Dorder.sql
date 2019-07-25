CREATE TABLE [dbo].[Dorder]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [DoNumber] NUMERIC NULL, 
    [ContractNumber] NUMERIC NULL, 
	[ContractType] INT NULL,
    [QTY] INT NULL, 
    [GoodsType] INT NULL, 
    [AddressEng] NVARCHAR(MAX) NULL, 
    [AddressUrd] NVARCHAR(MAX) NULL, 
    [CityID] INT NULL, 
    [Party] INT NULL, 
    [Weight] FLOAT NULL, 
    [Unit] INT NULL, 
    [Attached] NUMERIC NULL, 
    [DoDate] DATE NULL, 
    [CreatedOn] DATE NULL, 
    [EcomID] INT NULL, 
    CONSTRAINT [FK_Dorder_ContractType] FOREIGN KEY ([ContractType]) REFERENCES [ContractType]([Id]), 
    CONSTRAINT [FK_Dorder_GoodsTypes] FOREIGN KEY ([GoodsType]) REFERENCES [GoodsTypes]([Id]), 
    CONSTRAINT [FK_Dorder_Cities] FOREIGN KEY ([CityID]) REFERENCES [Cities]([Id]), 
    CONSTRAINT [FK_Dorder_Party] FOREIGN KEY ([Party]) REFERENCES [Party]([Id])
)
