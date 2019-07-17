CREATE TABLE [dbo].[GoodsTypes]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Goods] NCHAR(20) NULL, 
    [Description] NCHAR(50) NULL, 
    [Unit] INT NULL, 
    [EcomID] INT NULL, 
    CONSTRAINT [FK_GoodsTypes_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [ExanaduCompanies]([Id])
)
