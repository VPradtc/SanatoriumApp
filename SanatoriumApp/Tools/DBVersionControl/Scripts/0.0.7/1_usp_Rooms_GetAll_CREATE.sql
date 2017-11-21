IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Rooms_GetAll') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Rooms_GetAll
END
GO

CREATE PROC usp_Rooms_GetAll
	@_currentUserId INT
AS
BEGIN
	SELECT
		*
	FROM Rooms
	WHERE IsDeleted = 0
END
