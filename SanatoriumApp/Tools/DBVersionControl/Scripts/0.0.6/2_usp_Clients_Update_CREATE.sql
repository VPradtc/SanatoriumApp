IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Clients_Update') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Clients_Update
END
GO

CREATE PROC usp_Clients_Update
	@_currentUserId INT
	,@Id INT
	,@Passport NVARCHAR(128)
	,@FirstName NVARCHAR(128)
	,@LastName NVARCHAR(128)
AS
BEGIN
	UPDATE Clients
	SET
		 Passport=@Passport
		,FirstName=@FirstName
		,LastName=@LastName
		,ModifiedDate=GETUTCDATE()
		,ModifiedBy=@_currentUserId
	WHERE Id = @Id
END
