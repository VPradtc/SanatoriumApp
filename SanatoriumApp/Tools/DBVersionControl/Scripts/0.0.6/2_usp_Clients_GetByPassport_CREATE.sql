IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Clients_GetByPassport') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Clients_GetByPassport
END
GO

CREATE PROC usp_Clients_GetByPassport
	@_currentUserId INT
	,@Passport NVARCHAR(128)
AS
BEGIN
	SELECT TOP 1
		*
	FROM Clients
	WHERE Passport = @Passport
END
