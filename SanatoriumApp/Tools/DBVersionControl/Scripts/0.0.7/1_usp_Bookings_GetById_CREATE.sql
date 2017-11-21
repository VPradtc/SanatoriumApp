IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Bookings_GetById') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Bookings_GetById
END
GO

CREATE PROC usp_Bookings_GetById
	@_currentUserId INT
	,@Id NVARCHAR(256)
AS
BEGIN
	SELECT TOP 1
		*
	FROM Bookings
	WHERE Id = @Id
		AND IsDeleted = 0
END
