IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Users_GetAll') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Users_GetAll
END
GO

CREATE PROC usp_Users_GetAll
	@_currentUserId INT
AS
BEGIN
	SELECT
		*
	FROM Users
	WHERE IsDeleted = 0
END
