IF EXISTS ( SELECT * FROM   sysobjects 
            WHERE  id = object_id(N'usp_RefreshTokens_Delete') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_RefreshTokens_Delete
END
GO

CREATE PROC usp_RefreshTokens_Delete
	 @_currentUserId INT
	,@Id INT
AS
BEGIN
	DELETE RefreshTokens
	WHERE [Id] = @Id
END
GO
