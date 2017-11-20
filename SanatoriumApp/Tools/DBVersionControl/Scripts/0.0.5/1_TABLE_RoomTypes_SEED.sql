IF (
	NOT EXISTS (
		SELECT TOP 1 1

		FROM RoomTypes
		WHERE [Name] = N'Regular'
	)
)
BEGIN
	INSERT RoomTypes (
		[Id]
		,[Name]
	)
	VALUES(
		1
		,N'Regular'
	)
END
GO

IF (
	NOT EXISTS (
		SELECT TOP 1 1

		FROM RoomTypes
		WHERE [Name] = N'Lux'
	)
)
BEGIN
	INSERT RoomTypes (
		[Id]
		,[Name]
	)
	VALUES(
		2
		,N'Lux'
	)
END
GO
