IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Rooms_Delete') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Rooms_Delete
END
GO

CREATE PROC usp_Rooms_Delete
	@_currentUserId INT
	,@Id INT
AS
BEGIN
	UPDATE Rooms
	SET
		 IsDeleted = 1
	WHERE Id = @Id
END
