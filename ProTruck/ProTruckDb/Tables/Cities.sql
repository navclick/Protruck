CREATE TABLE [dbo].[Cities]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [City] NCHAR(20) NULL, 
    [CreatedOn] DATE NULL, 
    [EcomID] INT NULL, 
    CONSTRAINT [FK_Cities_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [ExanaduCompanies]([Id])
)
