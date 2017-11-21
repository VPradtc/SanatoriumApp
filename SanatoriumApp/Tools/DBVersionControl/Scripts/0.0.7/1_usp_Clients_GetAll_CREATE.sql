IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Clients_GetAll') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Clients_GetAll
END
GO

CREATE PROC usp_Clients_GetAll
	@_currentUserId INT
AS
BEGIN
	SELECT
		*
	FROM Clients
	WHERE IsDeleted = 0
END
