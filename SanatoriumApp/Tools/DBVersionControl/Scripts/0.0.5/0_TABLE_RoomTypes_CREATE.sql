IF (
	NOT EXISTS (
		SELECT * 
		FROM INFORMATION_SCHEMA.TABLES 
		WHERE TABLE_SCHEMA = 'dbo' 
		AND TABLE_NAME = 'RoomTypes'
	)
)
BEGIN
	CREATE TABLE RoomTypes (
		[Id] INT PRIMARY KEY
		,[Name] NVARCHAR(128)
	)
END
GO
