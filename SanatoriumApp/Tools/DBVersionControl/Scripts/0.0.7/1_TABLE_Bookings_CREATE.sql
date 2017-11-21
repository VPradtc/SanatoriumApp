IF (
	NOT EXISTS (
		SELECT * 
		FROM INFORMATION_SCHEMA.TABLES 
		WHERE TABLE_SCHEMA = 'dbo' 
		AND TABLE_NAME = 'Bookings'
	)
)
BEGIN
	CREATE TABLE Bookings (
		[Id] INT PRIMARY KEY IDENTITY(1,1)
		,[ClientId] INT
		, CONSTRAINT FK_Bookings_ClientId_Clients_Id
		FOREIGN KEY(ClientId) REFERENCES Clients(Id)

		,[RoomId] INT
		, CONSTRAINT FK_Bookings_RoomId_Rooms_Id
		FOREIGN KEY([RoomId]) REFERENCES Rooms(Id)

		,[StartDate] DATETIME2 NOT NULL
		,[EndDate] DATETIME2 NOT NULL

		,[CreatedBy] INT NOT NULL
		,[ModifiedBy] INT NOT NULL
		,[CreatedDate] DATETIME2 NOT NULL DEFAULT(GETUTCDATE())
		,[ModifiedDate] DATETIME2 NOT NULL DEFAULT(GETUTCDATE())
		,[IsDeleted] BIT NOT NULL DEFAULT(0)

		, CONSTRAINT FK_Bookings_CreatedBy_Users_Id
		FOREIGN KEY(CreatedBy) REFERENCES Users(Id)

		, CONSTRAINT FK_Bookings_ModifiedBy_Users_Id
		FOREIGN KEY(ModifiedBy) REFERENCES Users(Id)
	)
END
GO
