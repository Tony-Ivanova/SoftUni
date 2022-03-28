CREATE PROC usp_CalculateFutureValueForAccount(@AccountID INT, @InterestRate FLOAT)
AS
BEGIN
	SELECT
	ah.Id, 
	ah.FirstName AS [First Name], 
	ah.LastName AS [Last Name], 
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	WHERE @AccountID = a.Id
END  
