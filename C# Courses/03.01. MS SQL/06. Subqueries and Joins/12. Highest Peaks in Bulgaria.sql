SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Peaks AS p
	 INNER JOIN Mountains AS m ON (p.MountainId = m.Id)
	 INNER JOIN MountainsCountries AS mc ON (mc.MountainId = m.Id AND mc.CountryCode = 'BG')
WHERE p.Elevation > 2835
ORDER BY p.Elevation DESC
