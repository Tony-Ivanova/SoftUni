SELECT TOP(5) EmployeeID, JobTitle, e.AddressID, AddressText
FROM Employees AS e
LEFT OUTER JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY e.AddressID ASC
