IF (
	NOT EXISTS (
		SELECT * 
		FROM INFORMATION_SCHEMA.TABLES 
		WHERE TABLE_SCHEMA = 'dbo' 
		AND TABLE_NAME = 'Clients'
	)
)
BEGIN
	CREATE TABLE Clients (
		[Id] INT PRIMARY KEY IDENTITY(1,1)
		,[Passport] NVARCHAR(128)
		,[FirstName] NVARCHAR(128)
		,[LastName] NVARCHAR(128)

		, CONSTRAINT UQ_Clients_Passport
		UNIQUE ([Passport])

		,[CreatedBy] INT NOT NULL
		,[ModifiedBy] INT NOT NULL
		,[CreatedDate] DATETIME2 NOT NULL DEFAULT(GETUTCDATE())
		,[ModifiedDate] DATETIME2 NOT NULL DEFAULT(GETUTCDATE())
		,[IsDeleted] BIT NOT NULL DEFAULT(0)

		, CONSTRAINT FK_Clients_CreatedBy_Users_Id
		FOREIGN KEY(CreatedBy) REFERENCES Users(Id)

		, CONSTRAINT FK_Clients_ModifiedBy_Users_Id
		FOREIGN KEY(ModifiedBy) REFERENCES Users(Id)
	)
END
GO
