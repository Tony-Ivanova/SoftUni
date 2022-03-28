SELECT TOP(10) s.FirstName, s.LastName, CONVERT(DECIMAL(3,2), AVG(se.Grade)) AS [Grade]
FROM Students AS s
JOIN StudentsExams AS se
ON s.Id = se.StudentId
GROUP BY s.FirstName, s.LastName
ORDER BY AVG(se.Grade) DESC, s.FirstName, s.LastName ASC
