IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Bookings_GetByOverlappingDateRange') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Bookings_GetByOverlappingDateRange
END
GO

CREATE PROC usp_Bookings_GetByOverlappingDateRange
	@_currentUserId INT
	,@StartDate DATETIME2
	,@EndDate DATETIME2
	,@RoomId INT
AS
BEGIN
	SELECT
		*
	FROM Bookings b
	WHERE b.RoomId = @RoomId
	AND (
		(
			b.StartDate >= @StartDate
			AND
			b.EndDate <= @EndDate
		)
		OR
		(
			b.EndDate >= @StartDate
			AND
			b.EndDate <= @EndDate
		)
	)
END
