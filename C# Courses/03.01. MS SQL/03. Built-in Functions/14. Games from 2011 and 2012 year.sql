SELECT TOP(50) [Name], Convert(varchar(10), [Start], 120) as [Start date]
FROM Games
WHERE DATEPART(YEAR, [Start]) IN (2011, 2012)
ORDER BY [Start date], [Name]

ИЛИ

SELECT TOP 50 Name, FORMAT(Start,'yyyy-MM-dd') AS [Start Date] 
FROM Games
WHERE (SELECT YEAR(Start)) IN (2011,2012)
ORDER BY [Start Date], Name

ИЛИ

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start date]
FROM Games
WHERE DATEPART(YEAR, [Start]) IN (2011, 2012)
ORDER BY [Start date], [Name]

