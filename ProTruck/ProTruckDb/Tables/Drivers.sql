CREATE TABLE [dbo].[Drivers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(15) NULL, 
    [Phone] NCHAR(15) NULL, 
    [Address] NCHAR(500) NULL, 
    [DeviceID] NCHAR(150) NULL, 
    [Status] BIT NULL, 
    [Vehicle] INT NULL, 
    [CreatedOn] DATE NULL, 
    [EcomID] INT NULL, 
    CONSTRAINT [FK_Drivers_vehicle] FOREIGN KEY ([Vehicle]) REFERENCES [vehicle]([Id]), 
    CONSTRAINT [FK_Drivers_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [ExanaduCompanies]([Id])
)
