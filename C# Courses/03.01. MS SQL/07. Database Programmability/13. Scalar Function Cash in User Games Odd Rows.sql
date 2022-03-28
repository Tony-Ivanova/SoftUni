CREATE FUNCTION ufn_CashInUsersGames(@NameGame NVARCHAR(MAX))
RETURNS @output TABLE (SumCash DECIMAL(18, 4))
AS
BEGIN
	INSERT INTO @output SELECT(
	SELECT SUM(Cash) AS [SumCash] 
	FROM (
		SELECT *, ROW_NUMBER() OVER(ORDER BY Cash DESC) AS [RowNum] 
		FROM UsersGames
		WHERE GameId IN (
			SELECT Id 
			FROM Games
			WHERE [Name] = @NameGame
	)) AS [RowNumTable]
	WHERE [RowNum] % 2 <> 0)
	RETURN;
END
