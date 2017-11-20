IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Clients_Delete') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Clients_Delete
END
GO

CREATE PROC usp_Clients_Delete
	@_currentUserId INT
	,@Id INT
AS
BEGIN
	UPDATE Clients
	SET
		 IsDeleted = 1
	WHERE Id = @Id
END
