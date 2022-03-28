CREATE PROC usp_GetTownsStartingWith(@text VARCHAR(MAX))
AS
SELECT [Name]
FROM Towns
WHERE [Name] LIKE @text + '%'


EXEC usp_GetTownsStartingWith 'b'
