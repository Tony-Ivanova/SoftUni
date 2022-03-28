SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [FullName], COUNT(r.UserId)
FROM Employees AS e
LEFT JOIN Reports AS r
ON e.Id = EmployeeId
GROUP BY e.FirstName, e.LastName
ORDER BY COUNT(r.UserId) DESC, [FullName] ASC
