IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_MedicalProcedures_GetTotal') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_MedicalProcedures_GetTotal
END
GO

CREATE PROC usp_MedicalProcedures_GetTotal
	@_currentUserId INT
AS
BEGIN
	SELECT
		COUNT(*)
	FROM MedicalProcedures
	WHERE IsDeleted = 0
END
