SELECT SUM(oneLevelUp.[Difference]) AS [SumDifference]
FROM (SELECT DepositAmount - (SELECT DepositAmount
FROM WizzardDeposits
WHERE Id = secondBase.Id + 1) AS [Difference]
FROM WizzardDeposits AS secondBase) AS oneLevelUp
