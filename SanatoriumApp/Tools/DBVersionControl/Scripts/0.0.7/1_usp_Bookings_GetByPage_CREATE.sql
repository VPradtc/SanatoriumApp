IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Bookings_GetByPage') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Bookings_GetByPage
END
GO

CREATE PROC usp_Bookings_GetByPage
	@_currentUserId INT
	,@Skip INT
	,@Take INT
AS
BEGIN
	SELECT
		b.*
		, c.LastName + ' ' + c.FirstName AS ClientName
		, r.Name AS RoomName
	FROM Bookings b
	JOIN Clients c
	ON b.ClientId = c.Id
	JOIN Rooms r
	ON b.RoomId = r.Id
	WHERE b.IsDeleted = 0
	
	ORDER BY CreatedDate DESC
	OFFSET     @Skip ROWS
	FETCH NEXT @Take ROWS ONLY;
END
