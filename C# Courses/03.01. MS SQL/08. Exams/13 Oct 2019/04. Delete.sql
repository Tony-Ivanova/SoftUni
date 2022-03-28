DELETE 
FROM Issues
WHERE RepositoryId IN
(
SELECT Id 
FROM Repositories
WHERE [Name] LIKE 'Softuni-Teamwork' 
)

DELETE 
FROM RepositoriesContributors
WHERE RepositoryId IN
(
SELECT Id 
FROM Repositories
WHERE [Name] LIKE 'Softuni-Teamwork' 
)
