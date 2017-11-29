IF EXISTS ( SELECT * FROM   sysobjects
            WHERE  id = object_id(N'usp_Clients_GetRevenueByDateRange') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROC usp_Clients_GetRevenueByDateRange
END
GO

CREATE PROC usp_Clients_GetRevenueByDateRange
	@_currentUserId INT
AS
BEGIN
	SELECT
		COUNT(*)
	FROM ScheduledMedicalProcedures
	WHERE IsDeleted = 0
END
