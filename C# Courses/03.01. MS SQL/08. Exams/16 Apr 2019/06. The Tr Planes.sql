SELECT p.Id, p.Name, p.Seats, p.Range
FROM Planes as p
WHERE p.Name LIKE '%tr%'
ORDER BY p.Id ASC, p.Name ASC, p.Seats ASC, p.Range ASC
