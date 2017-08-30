IF EXISTS ( SELECT * FROM   sysobjects 
            WHERE  id = object_id(N'usp_RefreshTokens_GetByTokenValue') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_RefreshTokens_GetByTokenValue
END
GO

CREATE PROC usp_RefreshTokens_GetByTokenValue
	 @_currentUserId INT
	,@TokenValue UNIQUEIDENTIFIER
AS
BEGIN
	SELECT TOP 1 *
		FROM RefreshTokens rt
		WHERE rt.TokenValue = @TokenValue
END
GO
