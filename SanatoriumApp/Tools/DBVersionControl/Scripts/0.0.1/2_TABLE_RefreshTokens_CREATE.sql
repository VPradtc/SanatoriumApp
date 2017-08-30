IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'RefreshTokens'))
BEGIN
	CREATE TABLE RefreshTokens (
		 [Id] INT PRIMARY KEY IDENTITY(1,1)
		,[Subject] NVARCHAR(128)
		,[TokenValue] UNIQUEIDENTIFIER
		,[IssuedUtc] DATETIME2
		,[ExpiresUtc] DATETIME2
		,[ProtectedTicket] NVARCHAR(1024)
	)
END
GO
