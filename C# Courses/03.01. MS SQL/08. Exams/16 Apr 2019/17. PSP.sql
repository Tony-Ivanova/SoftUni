SELECT p.Name, p.Seats, COUNT(t.PassengerId)
FROM Planes AS p
LEFT JOIN Flights AS fl
ON p.Id =  fl.PlaneId
LEFT JOIN Tickets AS t
ON t.FlightId = fl.Id
GROUP BY p.Name, p.Seats
ORDER BY COUNT(t.PassengerId) DESC, p.Name ASC, p.Seats ASC
