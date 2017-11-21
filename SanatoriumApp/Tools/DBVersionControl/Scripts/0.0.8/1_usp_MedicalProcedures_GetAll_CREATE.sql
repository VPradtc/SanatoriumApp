IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_MedicalProcedures_GetAll') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_MedicalProcedures_GetAll
END
GO

CREATE PROC usp_MedicalProcedures_GetAll
	@_currentUserId INT
AS
BEGIN
	SELECT
		*
	FROM MedicalProcedures
	WHERE IsDeleted = 0
END
