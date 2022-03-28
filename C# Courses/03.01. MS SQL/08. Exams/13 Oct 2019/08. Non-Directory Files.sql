SELECT d.Id, d.Name, CONCAT(d.Size,'KB') AS [Size]
FROM Files AS f
RIGHT JOIN Files AS d
ON f.ParentId = d.Id
WHERE f.ParentId IS NULL
ORDER BY d.Id ASC, d.Name ASC, [Size] DESC 
