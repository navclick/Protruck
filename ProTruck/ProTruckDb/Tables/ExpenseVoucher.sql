CREATE TABLE [dbo].[ExpenseVoucher]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Date] DATE NULL, 
    [ExpenseType] INT NULL, 
    [Desc] NVARCHAR(100) NULL, 
    [TotalAmount] DECIMAL NULL, 
    [ReceivedBy] NVARCHAR(50) NULL, 
    [EcomId] INT NULL

)
