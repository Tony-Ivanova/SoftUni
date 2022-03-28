SELECT TOP(3) e.EmployeeID, e.FirstName
FROM Employees AS e
	FULL JOIN EmployeesProjects AS ae ON e.EmployeeID = ae.EmployeeID 	
WHERE ae.EmployeeID IS NULL
ORDER BY e.EmployeeID ASC
