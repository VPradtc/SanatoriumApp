IF (
	NOT EXISTS (
		SELECT * 
		FROM INFORMATION_SCHEMA.TABLES 
		WHERE TABLE_SCHEMA = 'dbo' 
		AND TABLE_NAME = 'MedicalProcedures'
	)
)
BEGIN
	CREATE TABLE MedicalProcedures (
		[Id] INT PRIMARY KEY IDENTITY(1,1)
		,[Name] NVARCHAR(128)
		,[BaseCost] DECIMAL
		
		,[CreatedBy] INT NOT NULL
		,[ModifiedBy] INT NOT NULL
		,[CreatedDate] DATETIME2 NOT NULL DEFAULT(GETUTCDATE())
		,[ModifiedDate] DATETIME2 NOT NULL DEFAULT(GETUTCDATE())
		,[IsDeleted] BIT NOT NULL DEFAULT(0)

		, CONSTRAINT FK_MedicalProcedures_CreatedBy_Users_Id
		FOREIGN KEY(CreatedBy) REFERENCES Users(Id)

		, CONSTRAINT FK_MedicalProcedures_ModifiedBy_Users_Id
		FOREIGN KEY(ModifiedBy) REFERENCES Users(Id)
	)
END
GO
