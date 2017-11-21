IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_ScheduledMedicalProcedures_Update') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_ScheduledMedicalProcedures_Update
END
GO

CREATE PROC usp_ScheduledMedicalProcedures_Update
	@_currentUserId INT
	,@Id INT
	,@UserId INT
	,@MedicalProcedureId INT
	,@ScheduledDate DATETIME2
AS
BEGIN
	UPDATE ScheduledMedicalProcedures
	SET
		 UserId=@UserId
		,MedicalProcedureId=@MedicalProcedureId
		,ScheduledDate=@ScheduledDate
		,ModifiedDate=GETUTCDATE()
		,ModifiedBy=@_currentUserId
	WHERE Id = @Id
END
