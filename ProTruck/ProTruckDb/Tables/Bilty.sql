CREATE TABLE [dbo].[Bilty]
(
	[BiltyNo] NUMERIC NOT NULL PRIMARY KEY identity, 
    [VehicleId] INT NULL, 
    [SenderParty] INT NULL, 
    [PaymentCode] NUMERIC NULL, 
    [DriverId] INT NULL, 
    [Weight] DECIMAL NULL, 
    [UnitId] INT NULL, 
    [Rate] FLOAT NULL, 
    [TotalAmount] DECIMAL NULL, 
    [PaidAmount] DECIMAL NULL, 
    [RemainingAmount] DECIMAL NULL, 
    [Qty] DECIMAL NULL, 
    [Address] NVARCHAR(MAX) NULL, 
    [BiltyDate] DATE NULL, 
    [CreateDate] DATE NULL, 
    [Status] INT NULL, 
    [PartyId] INT NULL, 
    [Contractno] NUMERIC NULL, 
    [GoodTypeId] INT NULL, 
    CONSTRAINT [FK_Bilty_vehicle] FOREIGN KEY ([VehicleId]) REFERENCES [vehicle]([Id]),
	
	CONSTRAINT [FK_Bilty_Drivers] FOREIGN KEY ([DriverId]) REFERENCES [Drivers]([Id]),
	CONSTRAINT [FK_Bilty_Party] FOREIGN KEY ([PartyId]) REFERENCES [Party]([Id]),
	CONSTRAINT [FK_Bilty_GoodTypes] FOREIGN KEY ([GoodTypeId]) REFERENCES [GoodsTypes]([Id])

)
