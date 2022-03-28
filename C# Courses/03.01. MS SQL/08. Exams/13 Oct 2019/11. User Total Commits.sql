CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(MAX))
RETURNS INT
--The function must return count of all commits for the user:
AS
BEGIN
	RETURN(SELECT COUNT(*)
		FROM Users AS u
		JOIN Commits AS c
		ON u.Id = c.ContributorId
		WHERE u.Username = @username) 
END
