CREATE TABLE [dbo].[Vendor]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Name] NCHAR(15) NULL, 
    [ContactPerson] NCHAR(15) NULL, 
    [Cell] NCHAR(15) NULL, 
    [Email] NCHAR(18) NULL, 
    [Address] NCHAR(50) NULL, 
    [City] INT NULL, 
    [EcomID] INT NULL, 
    CONSTRAINT [FK_Vendor_Cities] FOREIGN KEY ([City]) REFERENCES [Cities]([Id]), 
    CONSTRAINT [FK_Vendor_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [ExanaduCompanies]([Id])
)
