IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_MedicalProcedures_GetById') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_MedicalProcedures_GetById
END
GO

CREATE PROC usp_MedicalProcedures_GetById
	@_currentUserId INT
	,@Id NVARCHAR(256)
AS
BEGIN
	SELECT TOP 1
		*
	FROM MedicalProcedures
	WHERE Id = @Id
		AND IsDeleted = 0
END
