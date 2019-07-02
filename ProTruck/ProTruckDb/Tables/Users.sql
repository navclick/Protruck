﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FullName] NCHAR(100) NULL, 
    [Email] NCHAR(100) NULL, 
    [Password] NVARCHAR(MAX) NULL, 
    [Phone] NCHAR(100) NULL, 
    [EmailVeringCode] NVARCHAR(MAX) NULL, 
    [EmailConfirmed] BIT NULL, 
    [AccountStatus] INT NULL, 
    [CreatedOn] NCHAR(10) NULL, 
    [RoleID] INT NULL, 
    [EcomID] INT NOT NULL, 
    [Picture] NCHAR(200) NULL, 
    CONSTRAINT [FK_Users_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [ExanaduCompanies]([id]) 
)
