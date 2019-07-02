CREATE TABLE [dbo].[ExanaduCompanies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientName] NVARCHAR(500) NULL, 
    [ClientEmail] NCHAR(100) NULL, 
    [ClientContactPeson] NCHAR(100) NULL, 
    [ClientContactNumber] NCHAR(100) NULL, 
    [ClientAddress] NCHAR(200) NULL, 
    [StartDate] DATE NULL, 
    [ExpiryDate] DATE NULL
)
