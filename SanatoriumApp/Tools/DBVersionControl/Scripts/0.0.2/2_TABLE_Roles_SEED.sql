IF EXISTS (
	SELECT TOP 1 1
	FROM Roles
	WHERE Name = N'MedicalStaff'
)
BEGIN
	UPDATE Roles
	SET [Name] = N'MedicalStaff'
	WHERE Id = 2
END
GO

IF NOT EXISTS (
	SELECT TOP 1 1
	FROM Roles
	WHERE Name = N'UtilityStaff'
)
BEGIN
	INSERT Roles(
		 [Id]
		,[Name]
	)
	VALUES(
			3
		,N'UtilityStaff'
	)
END
