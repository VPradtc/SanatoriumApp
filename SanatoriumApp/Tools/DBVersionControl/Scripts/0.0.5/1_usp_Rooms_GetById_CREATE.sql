IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Rooms_GetById') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Rooms_GetById
END
GO

CREATE PROC usp_Rooms_GetById
	@_currentUserId INT
	,@Id NVARCHAR(256)
AS
BEGIN
	SELECT TOP 1
		*
	FROM Rooms
	WHERE Id = @Id
		AND IsDeleted = 0
END
