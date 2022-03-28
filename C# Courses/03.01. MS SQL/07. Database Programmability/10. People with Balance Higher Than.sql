CREATE PROC usp_GetHoldersWithBalanceHigherThan(@money DECIMAL(18,2))
AS
BEGIN
	SELECT ah.FirstName, ah.LastName
	FROM Accounts AS a
	JOIN AccountHolders AS ah
	ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @money
	ORDER BY ah.FirstName, ah.LastName
END
