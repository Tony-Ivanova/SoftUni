SELECT e.DepositGroup,
e.IsDepositExpired,
AVG(e.DepositInterest) AS [AverageInterest]
FROM WizzardDeposits AS e
WHERE e.DepositStartDate > '1985-01-01'
GROUP BY e.DepositGroup, e.IsDepositExpired
ORDER BY e.DepositGroup DESC, e.IsDepositExpired ASC
