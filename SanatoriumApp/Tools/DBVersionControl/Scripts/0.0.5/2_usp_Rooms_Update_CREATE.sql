IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Rooms_Update') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Rooms_Update
END
GO

CREATE PROC usp_Rooms_Update
	@_currentUserId INT
	,@Id INT
	,@Name NVARCHAR(128)
	,@RoomTypeId INT
	,@Capacity INT
AS
BEGIN
	UPDATE Rooms
	SET
		 [Name]=@Name
		,RoomTypeId=@RoomTypeId
		,Capacity=@Capacity
		,ModifiedDate=GETUTCDATE()
		,ModifiedBy=@_currentUserId
	WHERE Id = @Id
END
