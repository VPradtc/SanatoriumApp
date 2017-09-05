IF NOT EXISTS (
	SELECT TOP 1 1
	FROM Roles
	WHERE Name = N'Admin'
)
BEGIN
	INSERT Roles(
		 [Id]
		,[Name]
	)
	VALUES(
			1
		,N'Admin'
	)
END

IF NOT EXISTS (
	SELECT TOP 1 1
	FROM Roles
	WHERE Name = N'User'
)
BEGIN
	INSERT Roles(
		 [Id]
		,[Name]
	)
	VALUES(
			2
		,N'User'
	)
END
GO
