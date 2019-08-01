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
PRINT N'Altering [dbo].[Vendor]...';


GO
ALTER TABLE [dbo].[Vendor] ALTER COLUMN [Address] NCHAR (100) NULL;

ALTER TABLE [dbo].[Vendor] ALTER COLUMN [Cell] NCHAR (100) NULL;

ALTER TABLE [dbo].[Vendor] ALTER COLUMN [ContactPerson] NCHAR (100) NULL;

ALTER TABLE [dbo].[Vendor] ALTER COLUMN [Email] NCHAR (100) NULL;

ALTER TABLE [dbo].[Vendor] ALTER COLUMN [Name] NCHAR (100) NULL;


GO
PRINT N'Update complete.';


GO