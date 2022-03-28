SELECT TOP(2) e.DepositGroup
FROM WizzardDeposits AS e
GROUP BY e.DepositGroup
ORDER BY AVG(e.MagicWandSize)
