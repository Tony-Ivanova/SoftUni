CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	
	DECLARE @studentIdExistsOrNot INT = (SELECT s.Id
								FROM Students AS s
								WHERE s.Id = @StudentId)

	IF(@studentIdExistsOrNot IS NULL)
	BEGIN
	RAISERROR('This school has no student with the provided id!', 18, 2)
	END

	 DELETE
	 FROM StudentsExams
	 WHERE StudentId = @StudentId

	DELETE
	  FROM StudentsSubjects
	 WHERE StudentId = @StudentId

	DELETE
	 FROM StudentsTeachers
	WHERE StudentId = @StudentId

   DELETE
     FROM Students
    WHERE Id = @StudentId 
END
