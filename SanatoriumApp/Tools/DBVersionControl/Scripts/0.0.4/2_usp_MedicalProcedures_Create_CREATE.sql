IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_MedicalProcedures_Create') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_MedicalProcedures_Create
END
GO

CREATE PROC usp_MedicalProcedures_Create
	@_currentUserId INT
	,@Name NVARCHAR(128)
	,@BaseCost DECIMAL
AS
BEGIN
	INSERT MedicalProcedures (
		[Name]
		,BaseCost
		,CreatedBy
		,ModifiedBy
	)
	VALUES (
		@Name
		,@BaseCost
		,@_currentUserId
		,@_currentUserId
	)
END
