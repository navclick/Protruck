﻿CREATE TABLE [dbo].[vehicle]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [RegNumber] NCHAR(10) NULL, 
    [Type] INT NULL, 
    [Manufacturer] NCHAR(15) NULL, 
    [Model] NCHAR(15) NULL, 
    [Capacity] INT NULL, 
    [Unit] INT NULL, 
    [Status] INT NULL, 
    [CreatedOn] DATE NULL, 
    [EcomID] INT NULL, 
  
)