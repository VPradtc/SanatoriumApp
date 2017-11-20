IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Users_Create') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Users_Create
END
GO

CREATE PROC usp_Users_Create
	@_currentUserId INT
	,@ApiPasswordHash NVARCHAR(512)
	,@ApiPasswordSalt NVARCHAR(64)
	,@Email NVARCHAR(256)
	,@FirstName NVARCHAR(128)
	,@LastName NVARCHAR(128)
	,@RoleId INT
	,@Salary DECIMAL
AS
BEGIN
	INSERT Users (
		ApiPasswordHash
		,ApiPasswordSalt
		,Email
		,FirstName
		,LastName
		,RoleId
		,Salary
		,CreatedBy
		,ModifiedBy
	)
	VALUES (
		@ApiPasswordHash
		,@ApiPasswordSalt
		,@Email
		,@FirstName
		,@LastName
		,@RoleId
		,@Salary
		,@_currentUserId
		,@_currentUserId
	)
END
