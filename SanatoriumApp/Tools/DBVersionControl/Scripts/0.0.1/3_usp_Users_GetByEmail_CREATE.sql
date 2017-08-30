IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Users_GetByEmail') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Users_GetByEmail
END
GO

CREATE PROC usp_Users_GetByEmail
	@_currentUserId INT
	,@Email NVARCHAR(256)
AS
BEGIN
	SELECT TOP 1
		*
	FROM Users
	WHERE Email = @Email
		AND IsDeleted = 0
END
