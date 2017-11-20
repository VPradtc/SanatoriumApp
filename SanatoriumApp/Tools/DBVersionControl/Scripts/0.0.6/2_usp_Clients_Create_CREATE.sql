IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Clients_Create') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Clients_Create
END
GO

CREATE PROC usp_Clients_Create
	@_currentUserId INT
	,@Passport NVARCHAR(128)
	,@FirstName NVARCHAR(128)
	,@LastName NVARCHAR(128)
AS
BEGIN
	INSERT Clients (
		Passport
		,FirstName
		,LastName
		,CreatedBy
		,ModifiedBy
	)
	VALUES (
		@Passport
		,@FirstName
		,@LastName
		,@_currentUserId
		,@_currentUserId
	)
END
