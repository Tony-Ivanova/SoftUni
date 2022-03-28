CREATE TABLE Employees(
	Id INT PRIMARY KEY NOT NULL, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	Title NVARCHAR(60) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees
(Id, FirstName, LastName, Title)
VALUES
(1, 'Ivan', 'Ivanov', 'Director'),
(2, 'Gosho', 'Peshov', 'Saler'),
(3, 'Pesho', 'Goshev', 'Engineer')

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY NOT NULL, 
	FirstName NVARCHAR(60) NOT NULL, 
	LastName NVARCHAR(60) NOT NULL, 
	PhoneNumber VARCHAR(20), 
	EmergencyName NVARCHAR(60) NOT NULL, 
	EmergencyNumber VARCHAR(20) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers
(AccountNumber, FirstName, LastName, EmergencyName, EmergencyNumber)
VALUES
(1, 'Ivan', 'Goshov', 'Somewhere over the rainbow', 8888),
(2, 'Pesho', 'Ivanov', 'Catch me if you can', 2637),
(3, 'Gosho', 'Peshov', 'Who actually cares', 3765)

CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(30) PRIMARY KEY NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus
(RoomStatus)
VALUES
('Free'),
('Occupied'),
('Reserved')

CREATE TABLE RoomTypes(
	RoomType NVARCHAR(30) PRIMARY KEY NOT NULL, 
	Notes NVARCHAR(MAX)
	)

INSERT INTO RoomTypes
(RoomType)
VALUES
('Economy'),
('Luxury'),
('Honeymoon suit')

CREATE TABLE BedTypes(
	BedType NVARCHAR(20) PRIMARY KEY NOT NULL, 
	Notes NVARCHAR(60)
)

INSERT INTO BedTypes
(BedType)
VALUES
('Single'),
('Double'),
('King sized')

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY NOT NULL, 
	RoomType NVARCHAR(30) REFERENCES RoomTypes(RoomType), 
	BedType NVARCHAR (20) REFERENCES BedTypes(BedType), 
	Rate DECIMAL(2,1), 
	RoomStatus NVARCHAR(30) REFERENCES RoomStatus(RoomStatus), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms
(RoomNumber, RoomType, BedType, RoomStatus)
VALUES
(101, 'Economy', 'Single', 'Occupied'),
(102, 'Luxury', 'King sized', 'Reserved'),
(103, 'Honeymoon suit', 'King sized', 'Free')

CREATE TABLE Payments(
	Id INT PRIMARY KEY NOT NULL, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	PaymentDate DATE NOT NULL, 
	AccountNumber INT NOT NULL, 
	FirstDateOccupied DATE NOT NULL, 
	LastDateOccupied DATE NOT NULL, 
	TotalDays INT NOT NULL, 
	AmountCharged DECIMAL(10,2) NOT NULL, 
	TaxRate DECIMAL(10,2) NOT NULL, 
	TaxAmount DECIMAL(10,2) NOT NULL, 
	PaymentTotal DECIMAL(10,2) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments
(Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged,
TaxRate, TaxAmount, PaymentTotal)
VALUES
(1, 1, '2010.11.11', 108272678, '2009.11.11', '2009.12.12', 60, 9760.208, 29.0, 20.1, 890880.22),
(2, 3, '2010.11.11', 108272678, '2009.02.11', '2009.03.12', 30, 9760.208, 29.0, 20.1, 4553.22),
(3, 2, '2010.11.11', 108272678, '2009.11.11', '2009.11.15', 4, 9760.208, 29.0, 20.1, 3478.22)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY NOT NULL, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	DateOccupied DATE NOT NULL, 
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber), 
	RateApplied DECIMAL(10, 2) NOT NULL,
	PhoneCharge VARCHAR(30) NOT NULL,
    Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies
(Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES
(1, 1, '2018.11.11', 2, 102, 22.2, 29386473),
(2, 1, '2019.11.11', 1, 101, 33.3, 28462933),
(3, 2, '2011.11.11', 1, 103, 22.1, 29382022)
