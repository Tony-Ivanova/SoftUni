SELECT e.DepositGroup, e.MagicWandCreator, MIN(e.DepositCharge) AS [MinDepositCharge]
FROM WizzardDeposits AS e
GROUP BY e.MagicWandCreator, e.DepositGroup
ORDER BY e.MagicWandCreator, e.DepositGroup
