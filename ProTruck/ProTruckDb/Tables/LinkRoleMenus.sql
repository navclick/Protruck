CREATE TABLE [dbo].[LinkRoleMenus]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoleID] INT NULL, 
    [MenuID] INT NULL, 
    CONSTRAINT [FK_LinkRoleMenus_Roles] FOREIGN KEY ([RoleID]) REFERENCES [Roles]([id]), 
    CONSTRAINT [FK_LinkRoleMenus_Menus] FOREIGN KEY ([MenuID]) REFERENCES [Menus]([id])

)
