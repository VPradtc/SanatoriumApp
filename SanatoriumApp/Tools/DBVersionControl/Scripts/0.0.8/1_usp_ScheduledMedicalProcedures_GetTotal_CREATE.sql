IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_ScheduledMedicalProcedures_GetTotal') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_ScheduledMedicalProcedures_GetTotal
END
GO

CREATE PROC usp_ScheduledMedicalProcedures_GetTotal
	@_currentUserId INT
AS
BEGIN
	SELECT
		COUNT(*)
	FROM ScheduledMedicalProcedures
	WHERE IsDeleted = 0
END
