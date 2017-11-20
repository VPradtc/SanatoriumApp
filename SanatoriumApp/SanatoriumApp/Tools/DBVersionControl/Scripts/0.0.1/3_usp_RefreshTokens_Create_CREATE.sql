IF EXISTS ( SELECT * FROM   sysobjects 
            WHERE  id = object_id(N'usp_RefreshTokens_Create') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC [usp_RefreshTokens_Create]
END
GO

CREATE PROC [usp_RefreshTokens_Create]
	 @_currentUserId INT
	,@Subject NVARCHAR(128)
	,@TokenValue UNIQUEIDENTIFIER
	,@IssuedUtc DATETIME2
	,@ExpiresUtc DATETIME2
	,@ProtectedTicket NVARCHAR(1024)
AS
BEGIN
	INSERT RefreshTokens(
		 [Subject]
		,[TokenValue]
		,[IssuedUtc]
		,[ExpiresUtc]
		,[ProtectedTicket]
	)
		VALUES(
			 @Subject
			,@TokenValue
			,@IssuedUtc
			,@ExpiresUtc
			,@ProtectedTicket
		)

	RETURN SCOPE_IDENTITY()
END
GO
