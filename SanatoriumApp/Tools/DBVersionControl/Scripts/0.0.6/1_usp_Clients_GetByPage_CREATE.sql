IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Clients_GetByPage') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Clients_GetByPage
END
GO

CREATE PROC usp_Clients_GetByPage
	@_currentUserId INT
	,@Skip INT
	,@Take INT
AS
BEGIN
	SELECT
		*
	FROM Clients
	WHERE IsDeleted = 0
	
	ORDER BY CreatedDate DESC
	OFFSET     @Skip ROWS
	FETCH NEXT @Take ROWS ONLY;
END
