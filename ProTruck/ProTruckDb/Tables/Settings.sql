CREATE TABLE [dbo].[Settings]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [DoAutoincrement] BIT NULL, 
    [LastDoNumber] NUMERIC NULL, 
    [PackPerWeight] INT NULL, 
    [EcomID] INT NULL, 
    CONSTRAINT [FK_Settings_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [ExanaduCompanies]([Id])
)
