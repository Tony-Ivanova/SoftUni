SELECT e.DepositGroup,
SUM(e.DepositAmount) AS [TotalSum]
FROM WizzardDeposits AS e
WHERE e.MagicWandCreator LIKE 'Ollivander family'
GROUP BY e.DepositGroup
HAVING SUM(e.DepositAmount) < 150000
ORDER BY SUM(e.DepositAmount) DESC
