IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Bookings_GetTotal') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Bookings_GetTotal
END
GO

CREATE PROC usp_Bookings_GetTotal
	@_currentUserId INT
AS
BEGIN
	SELECT
		COUNT(*)
	FROM Bookings
	WHERE IsDeleted = 0
END
