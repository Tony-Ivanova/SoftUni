SELECT	e.EmployeeID, 
		e.FirstName,
CASE
	WHEN p.StartDate > '20050101' THEN NULL
	ELSE p.Name
END AS [ProjectName]
FROM Employees AS e
	JOIN EmployeesProjects AS ae
	ON	(e.EmployeeID = ae.EmployeeID AND e.EmployeeID = 24)
	LEFT OUTER JOIN Projects AS p
	ON (ae.ProjectID = p.ProjectID)
