IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Rooms_Create') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Rooms_Create
END
GO

CREATE PROC usp_Rooms_Create
	@_currentUserId INT
	,@Name NVARCHAR(128)
	,@RoomTypeId INT
	,@Capacity INT
AS
BEGIN
	INSERT Rooms (
		[Name]
		,[RoomTypeId]
		,Capacity
		,CreatedBy
		,ModifiedBy
	)
	VALUES (
		@Name
		,@RoomTypeId
		,@Capacity
		,@_currentUserId
		,@_currentUserId
	)
END
