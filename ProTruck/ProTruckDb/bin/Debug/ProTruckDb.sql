﻿/*
Deployment script for ProTruckDb

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ProTruckDb"
:setvar DefaultFilePrefix "ProTruckDb"
:setvar DefaultDataPath "C:\Users\ASAD\AppData\Local\Microsoft\VisualStudio\SSDT\ProTruck"
:setvar DefaultLogPath "C:\Users\ASAD\AppData\Local\Microsoft\VisualStudio\SSDT\ProTruck"

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
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key 67ec3b83-6c36-45ce-89f2-66dcadc629d9 is skipped, element [dbo].[Users].[EmailC] (SqlSimpleColumn) will not be renamed to EmailConfirmed';


GO
PRINT N'Rename refactoring operation with key 3a1e16b9-e091-46f5-9509-a1ea94910ead is skipped, element [dbo].[ExanaduCompanies].[Expairy] (SqlSimpleColumn) will not be renamed to ExpiryDate';


GO
PRINT N'Rename refactoring operation with key 78b09d61-c183-434e-a6cd-abb63ef1e7d5 is skipped, element [dbo].[Modules].[Contr] (SqlSimpleColumn) will not be renamed to Controller';


GO
PRINT N'Rename refactoring operation with key da29891f-0cea-4a03-b7f4-6ca6a21bfb7e is skipped, element [dbo].[Users].[EcomID] (SqlSimpleColumn) will not be renamed to RoleID';


GO
PRINT N'Creating [dbo].[ExanaduCompanies]...';


GO
CREATE TABLE [dbo].[ExanaduCompanies] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [ClientName]          NVARCHAR (500) NULL,
    [ClientEmail]         NCHAR (100)    NULL,
    [ClientContactPeson]  NCHAR (100)    NULL,
    [ClientContactNumber] NCHAR (100)    NULL,
    [ClientAddress]       NCHAR (200)    NULL,
    [StartDate]           DATE           NULL,
    [ExpiryDate]          DATE           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[LinkRoleMenus]...';


GO
CREATE TABLE [dbo].[LinkRoleMenus] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [RoleID] INT NULL,
    [MenuID] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Menus]...';


GO
CREATE TABLE [dbo].[Menus] (
    [Id]         INT         IDENTITY (1, 1) NOT NULL,
    [Name]       NCHAR (100) NULL,
    [Controller] NCHAR (100) NULL,
    [Action]     NCHAR (100) NULL,
    [Icon]       NCHAR (200) NULL,
    [IsActive]   NCHAR (10)  NULL,
    [ModuleID]   INT         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Modules]...';


GO
CREATE TABLE [dbo].[Modules] (
    [Id]         INT         IDENTITY (1, 1) NOT NULL,
    [Name]       NCHAR (200) NULL,
    [Controller] NCHAR (100) NULL,
    [Action]     NCHAR (100) NULL,
    [IsActive]   BIT         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Roles]...';


GO
CREATE TABLE [dbo].[Roles] (
    [Id]        INT         IDENTITY (1, 1) NOT NULL,
    [Role]      NCHAR (100) NULL,
    [Desc]      NCHAR (500) NULL,
    [CreatedOn] DATE        NULL,
    [CreatedBy] INT         NULL,
    [EcomID]    INT         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [FullName]        NCHAR (100)    NULL,
    [Email]           NCHAR (100)    NULL,
    [Password]        NVARCHAR (MAX) NULL,
    [Phone]           NCHAR (100)    NULL,
    [EmailVeringCode] NVARCHAR (MAX) NULL,
    [EmailConfirmed]  BIT            NULL,
    [AccountStatus]   INT            NULL,
    [CreatedOn]       NCHAR (10)     NULL,
    [RoleID]          INT            NULL,
    [EcomID]          INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[FK_LinkRoleMenus_Roles]...';


GO
ALTER TABLE [dbo].[LinkRoleMenus] WITH NOCHECK
    ADD CONSTRAINT [FK_LinkRoleMenus_Roles] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Roles] ([Id]);


GO
PRINT N'Creating [dbo].[FK_LinkRoleMenus_Menus]...';


GO
ALTER TABLE [dbo].[LinkRoleMenus] WITH NOCHECK
    ADD CONSTRAINT [FK_LinkRoleMenus_Menus] FOREIGN KEY ([MenuID]) REFERENCES [dbo].[Menus] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Menus_Modules]...';


GO
ALTER TABLE [dbo].[Menus] WITH NOCHECK
    ADD CONSTRAINT [FK_Menus_Modules] FOREIGN KEY ([ModuleID]) REFERENCES [dbo].[Modules] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Roles_ExanaduCompanies]...';


GO
ALTER TABLE [dbo].[Roles] WITH NOCHECK
    ADD CONSTRAINT [FK_Roles_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [dbo].[ExanaduCompanies] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Roles_Users]...';


GO
ALTER TABLE [dbo].[Roles] WITH NOCHECK
    ADD CONSTRAINT [FK_Roles_Users] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Users_ExanaduCompanies]...';


GO
ALTER TABLE [dbo].[Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Users_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [dbo].[ExanaduCompanies] ([Id]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '67ec3b83-6c36-45ce-89f2-66dcadc629d9')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('67ec3b83-6c36-45ce-89f2-66dcadc629d9')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '3a1e16b9-e091-46f5-9509-a1ea94910ead')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('3a1e16b9-e091-46f5-9509-a1ea94910ead')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '78b09d61-c183-434e-a6cd-abb63ef1e7d5')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('78b09d61-c183-434e-a6cd-abb63ef1e7d5')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'da29891f-0cea-4a03-b7f4-6ca6a21bfb7e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('da29891f-0cea-4a03-b7f4-6ca6a21bfb7e')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[LinkRoleMenus] WITH CHECK CHECK CONSTRAINT [FK_LinkRoleMenus_Roles];

ALTER TABLE [dbo].[LinkRoleMenus] WITH CHECK CHECK CONSTRAINT [FK_LinkRoleMenus_Menus];

ALTER TABLE [dbo].[Menus] WITH CHECK CHECK CONSTRAINT [FK_Menus_Modules];

ALTER TABLE [dbo].[Roles] WITH CHECK CHECK CONSTRAINT [FK_Roles_ExanaduCompanies];

ALTER TABLE [dbo].[Roles] WITH CHECK CHECK CONSTRAINT [FK_Roles_Users];

ALTER TABLE [dbo].[Users] WITH CHECK CHECK CONSTRAINT [FK_Users_ExanaduCompanies];


GO
PRINT N'Update complete.';


GO
