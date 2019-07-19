CREATE TABLE [dbo].[Expense]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Expense] NCHAR(50) NULL, 
    [Description] NCHAR(100) NULL, 
    [Type] INT NULL, 
    [EcomID] INT NULL, 
    CONSTRAINT [FK_Expense_ExanaduCompanies] FOREIGN KEY ([EcomID]) REFERENCES [ExanaduCompanies]([Id])
)
