IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Rooms_GetTotal') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Rooms_GetTotal
END
GO

CREATE PROC usp_Rooms_GetTotal
	@_currentUserId INT
AS
BEGIN
	SELECT
		COUNT(*)
	FROM Rooms
	WHERE IsDeleted = 0
END
