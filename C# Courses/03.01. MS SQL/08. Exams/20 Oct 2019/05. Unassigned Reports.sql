SELECT [Description], CONVERT(varchar(20), [OpenDate], 105)
FROM [Reports]
WHERE EmployeeID IS NULL
ORDER BY [OpenDate] ASC, [Description] ASC
