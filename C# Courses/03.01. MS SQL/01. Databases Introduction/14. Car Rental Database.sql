CREATE TABLE Categories(
	Id INT PRIMARY KEY NOT NULL, 
	CategoryName NVARCHAR(50) NOT NULL, 
	DailyRate DECIMAL(10,2) NOT NULL, 
	WeeklyRate DECIMAL(10,2) NOT NULL, 
	MonthlyRate DECIMAL(10,2) NOT NULL, 
	WeekendRate DECIMAL(10,2) NOT NULL
)

INSERT INTO Categories
(Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
(1, 'Category 1', 10, 70, 30, 5),
(2, 'Category 2', 20, 80, 40, 10),
(3, 'Category 3', 30, 70, 20, 1)

CREATE TABLE Cars(
	Id INT PRIMARY KEY NOT NULL, 
	PlateNumber VARCHAR(30) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL, 
	Model VARCHAR(30) NOT NULL, 
	CarYear INT NOT NULL, 
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id), 
	Doors TINYINT NOT NULL, 
	Picture VARBINARY(MAX), 
	Condition NVARCHAR(50), 
	Available BIT NOT NULL
)

INSERT INTO Cars
(Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Available)
VALUES
(1, 'PK2343OK', 'Mercedes-Benz', 'B200', 2006, 1, 5, 1),
(2, 'C0101CS', 'Opel', 'Astra', 2003, 2, 5, 0),
(3, 'A0192PO', 'Volkswagen', 'Polo', 1998, 3, 5, 0)


CREATE TABLE Employees(
	Id INT PRIMARY KEY NOT NULL, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	Title VARCHAR(30) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees
(Id, FirstName, LastName, Title)
VALUES
(1, 'Ivan', 'Ivanov', 'Director'),
(2, 'Gosho', 'Peshov', 'Saler'),
(3, 'Pesho', 'Goshev', 'Engineer')

CREATE TABLE Customers(
	Id INT PRIMARY KEY NOT NULL, 
	DriverLicenceNumber VARCHAR(30) NOT NULL, 
	FullName NVARCHAR(60) NOT NULL, 
	[Address] NVARCHAR(100) NOT NULL,
	City NVARCHAR(20) NOT NULL, 
	ZIPCode NVARCHAR(20) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers
(Id, DriverLicenceNumber, FullName, [Address], City, ZIPCode)
VALUES
(1, 27282837, 'Ivan Goshov', 'Somewhere over the rainbow', 'Golden City', 8888),
(2, 27226267, 'Pesho Ivanov', 'Catch me if you can', 'Underhill', 2637),
(3, 25267262, 'Gosho Peshov', 'Who actually cares', 'Hell or heaven', 3765) 

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id), 
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel DECIMAL (10,2) NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL, 
	TotalKilometrage INT NOT NULL, 
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL, 
	TotalDays INT NOT NULL,
	RateApplied DECIMAL (10,2),
	TaxRate DECIMAL (10,2), 
	OrderStatus NVARCHAR(60) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders
(Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, 
KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, OrderStatus)
VALUES
(1, 1, 1, 1, 100, 200, 300, 400, '1982.11.11', '1982.11.12', 30, 'completed'),
(2, 1, 2, 1, 200, 200, 1000, 10, '1987.11.11', '1987.11.12', 20, 'in progress'),
(3, 2, 2, 3, 300, 200, 100, 100, '2007.11.11', '2008.11.12', 20, 'completed')
