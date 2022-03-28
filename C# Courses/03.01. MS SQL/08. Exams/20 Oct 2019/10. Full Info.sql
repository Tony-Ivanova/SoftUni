SELECT 
CASE WHEN e.FirstName IS NULL THEN 'None'
ELSE CONCAT(e.FirstName, ' ', e.LastName)
END AS [Employee],
	   ISNULL(d.[Name], 'None') AS [Department],
	   ISNULL(c.[Name], 'None') AS [Category],
	   ISNULL(r.[Description], 'None') AS [Description],
	   ISNULL(CONVERT(varchar(20), r.[OpenDate], 104), 'None') AS [OpenDate],
	   ISNULL(s.[Label], 'None') AS [Status],
	   ISNULL(u.[Name], 'None') AS [User]
FROM Reports AS r
LEFT JOIN Users As u
ON r.UserId = u.Id
LEFT JOIN Employees AS e
ON r.EmployeeId = e.Id
LEFT JOIN Departments as d
ON d.Id = e.DepartmentId
LEFT Join Categories AS c
ON c.Id = r.CategoryId
LEFT Join Status as s
ON s.Id = r.StatusId
ORDER BY e.FirstName DESC, e.LastName DESC, [Department] ASC, [Category] ASC, 
[Description] ASC, [OpenDate] ASC, [Status] ASC, [User] ASc
