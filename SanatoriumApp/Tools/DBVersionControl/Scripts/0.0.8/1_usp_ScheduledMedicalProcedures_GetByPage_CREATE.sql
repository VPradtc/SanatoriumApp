IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_ScheduledMedicalProcedures_GetByPage') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_ScheduledMedicalProcedures_GetByPage
END
GO

CREATE PROC usp_ScheduledMedicalProcedures_GetByPage
	@_currentUserId INT
	,@Skip INT
	,@Take INT

	,@BookingId INT
AS
BEGIN
	SELECT
		smp.*
		,u.LastName + ' ' + u.FirstName AS UserName
		,mp.Name AS MedicalProcedureName
	FROM ScheduledMedicalProcedures smp
	JOIN Users u
		ON smp.UserId = u.Id
	JOIN MedicalProcedures mp
		ON smp.MedicalProcedureId = mp.Id
	WHERE smp.IsDeleted = 0
	AND smp.BookingId = @BookingId
	
	ORDER BY CreatedDate DESC
	OFFSET     @Skip ROWS
	FETCH NEXT @Take ROWS ONLY;
END
