SELECT t.FlightId, Sum(t.Price) AS Price
FROM Tickets as t
RIGHT JOIN Flights as f
ON f.Id = t.FlightId
GROUP BY t.FlightId
ORDER BY SUM(t.Price) DESC, t.FlightId ASC
