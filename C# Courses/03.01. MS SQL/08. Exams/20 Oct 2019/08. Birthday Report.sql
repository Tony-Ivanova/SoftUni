SELECT u.[Username], c.[Name] AS [CategoryName]
FROM Reports AS r
JOIN Users AS u
ON r.UserId = u.Id
JOIN Categories AS c
ON c.Id = r.CategoryId
WHERE DATEPART(DAY, u.Birthdate) = DATEPART(Day,r.OpenDate) AND DATEPART(MONTH, u.Birthdate) = DATEPART(Month, r.OpenDate)
ORDER BY u.[Username] ASC, [CategoryName] ASC
