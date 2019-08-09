CREATE TABLE [dbo].[AdressHistory]
(
	[Id] INT NOT NULL PRIMARY KEY Identity,
    [Party] INT NULL, 
    [EnglisgAddress] NVARCHAR(MAX) NULL, 
    [UrduAddress] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_AdressHistory_Party] FOREIGN KEY ([Party]) REFERENCES [Party]([Id])
)
