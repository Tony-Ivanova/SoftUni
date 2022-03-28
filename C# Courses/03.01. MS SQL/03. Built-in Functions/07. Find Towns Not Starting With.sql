SELECT TownID, [Name]
FROM Towns
WHERE [Name] LIKE '[^R,B,D]%'
ORDER BY [NAME]

ИЛИ

SELECT TownID, [Name]
FROM Towns
WHERE LEFT([Name], 1) NOT IN ('R', 'D', 'B')
ORDER BY [NAME]
