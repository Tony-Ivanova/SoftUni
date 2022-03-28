SELECT  ProductName, 
		OrderDate,
		DATEADD(Day, 3, OrderDate) AS [Pay Due],
		DATEADD(Month, 1, OrderDate) AS [Deliver Due]
FROM Orders
