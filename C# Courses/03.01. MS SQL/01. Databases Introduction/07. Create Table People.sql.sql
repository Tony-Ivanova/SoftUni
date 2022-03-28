CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY,
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(Max)
)

INSERT INTO People 
([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES 
('Pesho Peshev', 0, 1.73, 97.42, 'm', '1967-04-02', 'Do we have [to]?'),
('Gosho Goshev', 0, 1.84, 87.34, 'm', '1976-02-03', 'Oh, the horror!'),
('Goshina Gosheva',0, 1.56, 67.33, 'f', '1982-08-09', 'Do give me a break'),
('Pesho Goshev', 0, 1.93, 83.22, 'm', '1987-12-12', 'One more to go'),
('Fritz Schönberg', 0, 1.67, 89.72, 'm', '1976-02-28', 'Finally, we are here')
