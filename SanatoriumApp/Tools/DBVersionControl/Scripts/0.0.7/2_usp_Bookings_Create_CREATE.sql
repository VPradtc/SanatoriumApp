IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Bookings_Create') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Bookings_Create
END
GO

CREATE PROC usp_Bookings_Create
	@_currentUserId INT
	,@ClientId INT
	,@RoomId INT
	,@StartDate DATETIME2
	,@EndDate DATETIME2
AS
BEGIN
	INSERT Bookings (
		ClientId
		,RoomId
		,StartDate
		,EndDate
		,CreatedBy
		,ModifiedBy
	)
	VALUES (
		@ClientId
		,@RoomId
		,@StartDate
		,@EndDate
		,@_currentUserId
		,@_currentUserId
	)
END
