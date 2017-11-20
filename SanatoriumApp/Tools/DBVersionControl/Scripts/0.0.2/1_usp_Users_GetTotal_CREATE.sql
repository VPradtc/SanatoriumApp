IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Users_GetTotal') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Users_GetTotal
END
GO

CREATE PROC usp_Users_GetTotal
	@_currentUserId INT
AS
BEGIN
	SELECT
		COUNT(*)
	FROM Users
	WHERE IsDeleted = 0
END
