﻿/*
Deployment script for ProTruck

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ProTruck"
:setvar DefaultFilePrefix "ProTruck"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key 9481cf97-9501-4d55-b1af-db872660b0e2 is skipped, element [dbo].[Vendor].[Cell] (SqlSimpleColumn) will not be renamed to ContactPerson';


GO
PRINT N'Creating [dbo].[Contractor]...';


GO
CREATE TABLE [dbo].[Contractor] (
    [Id]            INT         IDENTITY (1, 1) NOT NULL,
    [Name]          NCHAR (15)  NULL,
    [ContactPerson] NCHAR (15)  NULL,
    [Cell]          NCHAR (18)  NULL,
    [Email]         NCHAR (20)  NULL,
    [Address]       NCHAR (100) NULL,
    [City]          INT         NULL,
    [EcomID]        INT         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Vendor]...';


GO
CREATE TABLE [dbo].[Vendor] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL,
    [Name]          NCHAR (15) NULL,
    [ContactPerson] NCHAR (15) NULL,
    [Cell]          NCHAR (15) NULL,
    [Email]         NCHAR (18) NULL,
    [Address]       NCHAR (50) NULL,
    [City]          INT        NULL,
    [EcomID]        INT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Contractor_Cities]...';


GO
ALTER TABLE [dbo].[Contractor] WITH NOCHECK
    ADD CONSTRAINT [FK_Contractor_Cities] FOREIGN KEY ([City]) REFERENCES [dbo].[Cities] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Contractor_ExanaduCompanies]...';


GO
ALTER TABLE [dbo].[Contractor] WITH NOCHECK
    ADD CONSTRAINT [FK_Contractor_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [dbo].[ExanaduCompanies] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Vendor_Cities]...';


GO
ALTER TABLE [dbo].[Vendor] WITH NOCHECK
    ADD CONSTRAINT [FK_Vendor_Cities] FOREIGN KEY ([City]) REFERENCES [dbo].[Cities] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Vendor_ExanaduCompanies]...';


GO
ALTER TABLE [dbo].[Vendor] WITH NOCHECK
    ADD CONSTRAINT [FK_Vendor_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [dbo].[ExanaduCompanies] ([Id]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '9481cf97-9501-4d55-b1af-db872660b0e2')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('9481cf97-9501-4d55-b1af-db872660b0e2')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Contractor] WITH CHECK CHECK CONSTRAINT [FK_Contractor_Cities];

ALTER TABLE [dbo].[Contractor] WITH CHECK CHECK CONSTRAINT [FK_Contractor_ExanaduCompanies];

ALTER TABLE [dbo].[Vendor] WITH CHECK CHECK CONSTRAINT [FK_Vendor_Cities];

ALTER TABLE [dbo].[Vendor] WITH CHECK CHECK CONSTRAINT [FK_Vendor_ExanaduCompanies];


GO
PRINT N'Update complete.';


GO
