SELECT TOP(5) c.[Name] AS [CategoryName], COUNT(r.CategoryId) AS [ReportsNumber]
FROM Reports AS r
JOIN Categories AS c
ON r.CategoryId = c.Id
GROUP BY r.CategoryId, c.[Name]
ORDER BY COUNT(r.CategoryId) DESC, [CategoryName] ASC
