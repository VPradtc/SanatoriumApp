IF (
	NOT EXISTS (
		SELECT * 
		FROM INFORMATION_SCHEMA.TABLES 
		WHERE TABLE_SCHEMA = 'dbo' 
		AND TABLE_NAME = 'ScheduledMedicalProcedures'
	)
)
BEGIN
	CREATE TABLE ScheduledMedicalProcedures (
		[Id] INT PRIMARY KEY IDENTITY(1,1)
		,[BookingId] INT NOT NULL
		, CONSTRAINT FK_ScheduledMedicalProcedures_BookingId_Bookings_Id
		FOREIGN KEY(BookingId) REFERENCES Bookings(Id)

		,[UserId] INT NOT NULL
		, CONSTRAINT FK_ScheduledMedicalProcedures_UserId_Users_Id
		FOREIGN KEY(UserId) REFERENCES Users(Id)

		,[MedicalProcedureId] INT NOT NULL
		, CONSTRAINT FK_ScheduledMedicalProcedures_MedicalProcedureId_MedicalProcedures_Id
		FOREIGN KEY(MedicalProcedureId) REFERENCES MedicalProcedures(Id)

		,[ScheduledDate] DATETIME2 NOT NULL

		,[CreatedBy] INT NOT NULL
		,[ModifiedBy] INT NOT NULL
		,[CreatedDate] DATETIME2 NOT NULL DEFAULT(GETUTCDATE())
		,[ModifiedDate] DATETIME2 NOT NULL DEFAULT(GETUTCDATE())
		,[IsDeleted] BIT NOT NULL DEFAULT(0)

		, CONSTRAINT FK_ScheduledMedicalProcedures_CreatedBy_Users_Id
		FOREIGN KEY(CreatedBy) REFERENCES Users(Id)

		, CONSTRAINT FK_ScheduledMedicalProcedures_ModifiedBy_Users_Id
		FOREIGN KEY(ModifiedBy) REFERENCES Users(Id)
	)
END
GO
