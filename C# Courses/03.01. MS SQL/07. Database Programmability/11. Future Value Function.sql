CREATE FUNCTION ufn_CalculateFutureValue(@initialSum DECIMAL(18, 4), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE	@futureValue DECIMAL (18, 4) = @initialSum * POWER(1+@yearlyInterestRate, @numberOfYears)
	RETURN @futureValue
END
