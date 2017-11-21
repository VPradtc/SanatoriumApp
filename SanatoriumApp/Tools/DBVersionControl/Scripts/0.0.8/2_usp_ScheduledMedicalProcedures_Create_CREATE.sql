IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_ScheduledMedicalProcedures_Create') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_ScheduledMedicalProcedures_Create
END
GO

CREATE PROC usp_ScheduledMedicalProcedures_Create
	@_currentUserId INT
	,@BookingId INT
	,@UserId INT
	,@MedicalProcedureId INT
	,@ScheduledDate DATETIME2
AS
BEGIN
	INSERT ScheduledMedicalProcedures (
		BookingId
		,UserId
		,MedicalProcedureId
		,ScheduledDate
		,CreatedBy
		,ModifiedBy
	)
	VALUES (
		@BookingId
		,@UserId
		,@MedicalProcedureId
		,@ScheduledDate
		,@_currentUserId
		,@_currentUserId
	)
END
