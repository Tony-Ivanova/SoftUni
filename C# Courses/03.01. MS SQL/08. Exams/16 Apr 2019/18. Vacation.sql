CREATE FUNCTION udf_CalculateTickets(@origin NVARCHAR(MAX), @destination NVARCHAR(MAX), @peopleCount INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	
	DECLARE @doesFlightExist INT = (SELECT f.Id
								FROM Flights AS f
								WHERE @origin = f.Origin AND @destination = f.Destination)

	IF(@peopleCount <= 0)
	BEGIN
	RETURN 'Invalid people count!'
	END
	
	IF(@doesFlightExist IS NULL)
	BEGIN
	RETURN 'Invalid flight!'
	END

	DECLARE @price DECIMAL(18,2) = (SELECT t.Price
					FROM Tickets AS t
					JOIN Flights AS f
					ON f.Id = t.FlightId
					WHERE t.FlightId = @doesFlightExist)
		
										
	RETURN CONCAT('Total price ', @peopleCount*@price)
END
