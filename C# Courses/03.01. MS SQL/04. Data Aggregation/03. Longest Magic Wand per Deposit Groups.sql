SELECT e.DepositGroup,
MAX(e.MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits AS e
GROUP BY e.DepositGroup
