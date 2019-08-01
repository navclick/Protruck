CREATE TABLE [dbo].[Vendor]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Name] NCHAR(100) NULL, 
    [ContactPerson] NCHAR(100) NULL, 
    [Cell] NCHAR(100) NULL, 
    [Email] NCHAR(100) NULL, 
    [Address] NCHAR(100) NULL, 
    [City] INT NULL, 
    [EcomID] INT NULL, 
    CONSTRAINT [FK_Vendor_Cities] FOREIGN KEY ([City]) REFERENCES [Cities]([Id]), 
    CONSTRAINT [FK_Vendor_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [ExanaduCompanies]([Id])
)
