IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_MedicalProcedures_Update') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_MedicalProcedures_Update
END
GO

CREATE PROC usp_MedicalProcedures_Update
	@_currentUserId INT
	,@Id INT
	,@Name NVARCHAR(128)
	,@BaseCost DECIMAL
AS
BEGIN
	UPDATE MedicalProcedures
	SET
		 [Name]=@Name
		,BaseCost=@BaseCost
		,ModifiedDate=GETUTCDATE()
		,ModifiedBy=@_currentUserId
	WHERE Id = @Id
END
