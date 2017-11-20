IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_MedicalProcedures_Delete') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_MedicalProcedures_Delete
END
GO

CREATE PROC usp_MedicalProcedures_Delete
	@_currentUserId INT
	,@Id INT
AS
BEGIN
	UPDATE MedicalProcedures
	SET
		 IsDeleted = 1
	WHERE Id = @Id
END
