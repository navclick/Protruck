CREATE TABLE [dbo].[Bank]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Bank] NCHAR(20) NULL, 
    [Branch] NCHAR(20) NULL, 
    [Address] NCHAR(50) NULL
)
