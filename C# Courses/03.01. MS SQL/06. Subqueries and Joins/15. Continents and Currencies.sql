SELECT c.ContinentCode,
		c.CurrencyCode,
			COUNT(c.CurrencyCode) AS CountOFCurrency,
			DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS CurrencyRank
			FROM Countries AS c
			GROUP BY c.ContinentCOde, c.CurrencyCode
			HAVING COUNT(c.CurrencyCode) > 1) AS k
			WHERE k.CurrencyRANK = 1
			ORDER BY k.ContinentCode
