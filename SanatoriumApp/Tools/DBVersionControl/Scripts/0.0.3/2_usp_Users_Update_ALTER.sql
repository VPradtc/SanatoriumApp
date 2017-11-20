IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Users_Update') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Users_Update
END
GO

CREATE PROC usp_Users_Update
	@_currentUserId INT
	,@Id INT
	,@FirstName NVARCHAR(128)
	,@LastName NVARCHAR(128)
	,@RoleId INT
	,@Salary DECIMAL
AS
BEGIN
	UPDATE Users
	SET
		 FirstName=@FirstName
		,LastName=@LastName
		,RoleId=@RoleId
		,Salary=@Salary
		,ModifiedDate=GETUTCDATE()
		,ModifiedBy=@_currentUserId
	WHERE Id = @Id
END
