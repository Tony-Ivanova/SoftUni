CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE DATEPART(Year, HireDate) > 2000
