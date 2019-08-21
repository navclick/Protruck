CREATE TABLE [dbo].[BiltyToDos]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Biltyno] NUMERIC NULL, 
    [Donumber] NUMERIC NULL, 
    CONSTRAINT [FK_BiltyToDos_Bilty] FOREIGN KEY ([Biltyno]) REFERENCES [Bilty]([BiltyNo]), 
    CONSTRAINT [FK_BiltyToDos_Dorder] FOREIGN KEY ([Donumber]) REFERENCES [Dorder]([DoNumber])
)
