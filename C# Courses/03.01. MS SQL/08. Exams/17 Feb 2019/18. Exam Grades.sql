CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL (3, 2))
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @studentIdExistsOrNot INT = (SELECT s.Id
										FROM Students AS s
										WHERE s.Id = @studentId)
	IF(@grade > 6.00)
	BEGIN
	 RETURN 'Grade cannot be above 6.00!'
	END
	IF(@studentIdExistsOrNot IS NULL)
	BEGIN 
	RETURN 'The student with provided id does not exist in the school!'
	END
	
	DECLARE @count INT = (SELECT COUNT(*)
						FROM StudentsExams AS se
						JOIN Students AS s
						ON se.StudentId = s.Id
						WHERE s.Id = @studentId AND se.Grade BETWEEN @grade AND @grade+0.50)

	DECLARE @name NVARCHAR(60) = (SELECT s.FirstName 
								 FROM Students AS s
								 WHERE @studentId = s.Id)

	RETURN CONCAT('You have to update ', @count, ' grades for the student ', @name)
END
