SELECT e.DepositGroup,
SUM(e.DepositAmount) AS [TotalSum]
FROM WizzardDeposits AS e
GROUP BY e.DepositGroup
