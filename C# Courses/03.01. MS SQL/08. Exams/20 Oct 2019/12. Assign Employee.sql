CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS
BEGIN
	DECLARE @DepartmentOfEmployee INT = (SELECT DepartmentId
								FROM Employees AS e
								WHERE e.Id = @EmployeeId)

	DECLARE @DepartmentOfCategory INT = (SELECT DepartmentId
								FROM Categories 
								WHERE Id IN
								(SELECT CategoryId
								FROM Reports AS r
								WHERE r.Id = @ReportId))

	DECLARE @CategoryId INT = (SELECT TOP(1) Id
							FROM Categories
							ORDER BY Id DESC)

	IF(@DepartmentOfEmployee = @DepartmentOfCategory)
	BEGIN
	UPDATE REPORTS
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId
	END

	ELSE IF(@DepartmentOfEmployee != @DepartmentOfCategory)
	BEGIN
	THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;
	END
END
