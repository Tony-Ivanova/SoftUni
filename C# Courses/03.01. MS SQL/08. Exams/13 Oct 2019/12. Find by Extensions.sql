CREATE PROCEDURE usp_FindByExtension(@extension VARCHAR(MAX))
AS
BEGIN
	SELECT Id, Name, CONCAT(Size,'KB') AS [Size]
	FROM Files
	WHERE Name LIKE '%' + @extension 
	ORDER BY Id ASC, Name ASC, Size Desc
END
