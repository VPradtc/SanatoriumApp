IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Bookings_Update') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Bookings_Update
END
GO

CREATE PROC usp_Bookings_Update
	@_currentUserId INT
	,@Id INT
	,@ClientId INT
	,@RoomId INT
	,@StartDate DATETIME2
	,@EndDate DATETIME2
AS
BEGIN
	UPDATE Bookings
	SET
		 ClientId=@ClientId
		,RoomId=@RoomId
		,StartDate=@StartDate
		,EndDate=@EndDate
		,ModifiedDate=GETUTCDATE()
		,ModifiedBy=@_currentUserId
	WHERE Id = @Id
END
