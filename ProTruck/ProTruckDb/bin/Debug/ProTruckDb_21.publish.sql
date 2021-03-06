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
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\"

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
PRINT N'Creating [dbo].[Contract]...';


GO
CREATE TABLE [dbo].[Contract] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [ContractNo]   NUMERIC (18) NULL,
    [ContractType] INT          NULL,
    [Party]        INT          NULL,
    [TotatQty]     FLOAT (53)   NULL,
    [Unit]         INT          NULL,
    [EcomID]       INT          NULL,
    [CreatedOn]    DATE         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Contract_ContractType]...';


GO
ALTER TABLE [dbo].[Contract] WITH NOCHECK
    ADD CONSTRAINT [FK_Contract_ContractType] FOREIGN KEY ([ContractType]) REFERENCES [dbo].[ContractType] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Contract_Party]...';


GO
ALTER TABLE [dbo].[Contract] WITH NOCHECK
    ADD CONSTRAINT [FK_Contract_Party] FOREIGN KEY ([Party]) REFERENCES [dbo].[Party] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Contract_ExanaduCompanies]...';


GO
ALTER TABLE [dbo].[Contract] WITH NOCHECK
    ADD CONSTRAINT [FK_Contract_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [dbo].[ExanaduCompanies] ([Id]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Contract] WITH CHECK CHECK CONSTRAINT [FK_Contract_ContractType];

ALTER TABLE [dbo].[Contract] WITH CHECK CHECK CONSTRAINT [FK_Contract_Party];

ALTER TABLE [dbo].[Contract] WITH CHECK CHECK CONSTRAINT [FK_Contract_ExanaduCompanies];


GO
PRINT N'Update complete.';


GO
