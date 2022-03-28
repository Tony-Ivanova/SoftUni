SELECT s.FirstName, s.LastName, COUNT(st.TeacherId) AS [TeachersCount]
FROM Students as s
JOIN StudentsTeachers as st
ON s.Id = st.StudentId
GROUP BY s.FirstName, s.LastName
