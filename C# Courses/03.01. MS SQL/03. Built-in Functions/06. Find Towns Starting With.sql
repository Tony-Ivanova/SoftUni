SELECT TownID, [Name]
FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [NAME] ASC
ИЛИ
SELECT TownID, [Name]
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [NAME]
