CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY NOT NULL,
	DirectorName NVARCHAR(60) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors
(Id, DirectorName, Notes)
VALUES
(1, 'Gosho Goshev', Null),
(2, 'Pesho Peshev', 'The best director ever'),
(3, 'Gergana Gerganova', Null),
(4, 'Petranka Gosheva', 'Current number of movies over 50'),
(5, 'Pesho Goshev', Null)

CREATE TABLE Genres(
	Id INT PRIMARY KEY NOT NULL,
	GenreName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Genres
(Id, GenreName, Notes)
VALUES
(1, 'Comedy', 'Tell God your plans'),
(2, 'Drama', 'After you say "I do!"'),
(3, 'SCI-FI', 'Just heaven!'),
(4, 'Horror', 'Where the brave may live forever'),
(5, 'Crime', 'Where nobody lives')

CREATE TABLE Categories(
	Id INT PRIMARY KEY NOT NULL,
	CategoryName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories
(Id, CategoryName, Notes)
VALUES
(1, 'For kids', NUll),
(2, 'For teens', NUll),
(3, 'For young adults', NUll),
(4, 'Adults', NUll),
(5, 'Good God', NUll)

CREATE TABLE Movies(
	Id INT PRIMARY KEY NOT NULL,
	Title NVARCHAR(90) NOT NULL,
	DirectorID INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear INT,
	[Length] NVARCHAR(8),
	GenreID INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryID INT FOREIGN KEY REFERENCES Categories(Id),
	Rating INT,
	Notes NVARCHAR(MAX) 
)

INSERT INTO Movies
(Id, Title, DirectorID, CopyrightYear, GenreID, CategoryID, Rating)
VALUES
(1, 'Title 1', 1, 1987, 2, 3, 5),
(2, 'Title 2', 2, 1928, 2, 2, 2),
(3, 'Title 3', 4, 1982, 3, 3, 10),
(4, 'Title 4', 5, 1955, 5, 5, 8),
(5, 'Title 5', 3, 1956, 3, 3, NULL)
