SELECT DISTINCT LEFT(e.FirstName, 1) AS [FirstLetter]
FROM WizzardDeposits AS e
WHERE e.DepositGroup = 'Troll Chest'
GROUP BY LEFT(e.FirstName, 1)
ORDER BY FirstLetter
