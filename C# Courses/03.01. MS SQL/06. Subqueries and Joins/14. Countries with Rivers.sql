SELECT TOP(5) c.CountryName,
r.RiverName

FROM Countries AS c 
	JOIN Continents AS con ON (c.ContinentCode = con.ContinentCode AND con.ContinentName = 'Africa')	
	LEFT JOIN CountriesRivers AS cr ON (c.CountryCode = cr.CountryCode)
	LEFT JOIN Rivers AS r ON (cr.RiverId = r.Id)
ORDER BY c.CountryName
