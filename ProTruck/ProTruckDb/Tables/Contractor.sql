CREATE TABLE [dbo].[Contractor]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Name] NCHAR(15) NULL, 
    [ContactPerson] NCHAR(15) NULL, 
    [Cell] NCHAR(18) NULL, 
    [Email] NCHAR(20) NULL, 
    [Address] NCHAR(100) NULL, 
    [City] INT NULL, 
    [EcomID] INT NULL, 
    CONSTRAINT [FK_Contractor_Cities] FOREIGN KEY ([City]) REFERENCES [Cities]([Id]), 
    CONSTRAINT [FK_Contractor_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [ExanaduCompanies]([Id])
)
