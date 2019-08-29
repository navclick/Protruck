CREATE TABLE [dbo].[ExpenseVoucherDetails]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [ExpenseVoucherId] INT NULL, 
    [ExpenseId] INT NULL, 
    [Amount] DECIMAL NULL, 
    [vehicelId] INT NULL, 
    [Billtyno] NUMERIC NULL, 
    [Remarks] NVARCHAR(150) NULL, 
    CONSTRAINT [FK_ExpenseVoucherDetails_ExpenseVoucher] FOREIGN KEY ([ExpenseVoucherId]) REFERENCES [ExpenseVoucher]([Id]), 
    CONSTRAINT [FK_ExpenseVoucherDetails_Expense] FOREIGN KEY ([ExpenseId]) REFERENCES [Expense]([Id]), 
    CONSTRAINT [FK_ExpenseVoucherDetails_vehicle] FOREIGN KEY ([vehicelId]) REFERENCES [vehicle]([Id])

)
