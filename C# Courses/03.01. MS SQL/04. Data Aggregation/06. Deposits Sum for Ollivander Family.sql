SELECT e.DepositGroup,
SUM(e.DepositAmount) AS [TotalSum]
FROM WizzardDeposits AS e
WHERE e.MagicWandCreator LIKE 'Ollivander family'
GROUP BY e.DepositGroup
