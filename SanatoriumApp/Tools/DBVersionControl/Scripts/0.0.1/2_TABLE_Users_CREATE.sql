IF (
	NOT EXISTS (
		SELECT * 
		FROM INFORMATION_SCHEMA.TABLES 
		WHERE TABLE_SCHEMA = 'dbo' 
		AND TABLE_NAME = 'Users'
	)
)
BEGIN
	CREATE TABLE Users (
		 [Id] INT PRIMARY KEY IDENTITY (1,1)
		,[FirstName] NVARCHAR(128)
		,[LastName] NVARCHAR(128)
		,[Email] NVARCHAR(256) NOT NULL
		,[ApiPasswordHash] NVARCHAR(512)
		,[ApiPasswordSalt] NVARCHAR(64)

		,CONSTRAINT [UQ_Users_Email]
			UNIQUE([Email])

		,[RoleId] INT NOT NULL
		,CONSTRAINT [FK_Users_RoleId_Roles_Id]
			FOREIGN KEY([RoleId])
			REFERENCES [Roles]([Id])

		,[CreatedBy] INT NULL
		,[ModifiedBy] INT NULL
		,[CreatedDate] DATETIME2 NOT NULL DEFAULT(GETUTCDATE())
		,[ModifiedDate] DATETIME2 NOT NULL DEFAULT(GETUTCDATE())
		,[IsDeleted] BIT NOT NULL DEFAULT(0)
	)
END
GO

IF (
	NOT EXISTS (
		SELECT *
		FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS
		WHERE CONSTRAINT_NAME ='FK_Users_CreatedBy_Users_Id'
	)
)
BEGIN
	ALTER TABLE Users
	ADD CONSTRAINT [FK_Users_CreatedBy_Users_Id]
		FOREIGN KEY([CreatedBy])
		REFERENCES [Users]([Id])
END


IF (
	NOT EXISTS (
		SELECT *
		FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS
		WHERE CONSTRAINT_NAME ='FK_Users_ModifiedBy_Users_Id'
	)
)
BEGIN
	ALTER TABLE Users
	ADD CONSTRAINT [FK_Users_ModifiedBy_Users_Id]
		FOREIGN KEY([ModifiedBy])
		REFERENCES [Users]([Id])
END
