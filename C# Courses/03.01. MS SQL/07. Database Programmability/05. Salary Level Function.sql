CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @SalaryLevel VARCHAR(10)
		BEGIN
		IF(@salary < 30000)
			BEGIN
				SET @SalaryLevel = 'Low'
			END
		ELSE IF(@salary <= 50000)
			BEGIN
				SET @SalaryLevel = 'Average'
			END 
		ELSE IF(@salary > 50000)
			BEGIN
				SET @SalaryLevel = 'High'
			END
		END
	RETURN @SalaryLevel
END

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] 
FROM Employees
