CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) UNIQUE NOT NULL,
	ProfilePicture VARBINARY(MAX), 
	CHECK(DATALENGTH(ProfilePicture) <= 921600),
	LastLoginTime DATETIME2,
	IsDeleted BIT NOT NULL

)

INSERT INTO Users 
(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Gosho Goshev', 'Oh, the horror!', 0, NULL, 0),
('Goshina Gosheva','Do give me a break', 0, NULL, 1),
('Pesho Goshev', 'One more to go', 0, NULL, 1),
('Fritz Schönberg', 'Finally, we are here', 0, NULL, 0),
('Pesho Peshev', 'Do we have [to]?', NULL, NULL, 0)
