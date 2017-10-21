CREATE DATABASE Bakery
GO

USE Bakery
GO

/*--01--*/
CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) UNIQUE,
	Description NVARCHAR(250),
	Recipe NVARCHAR(MAX),
	Price MONEY CHECK(Price > 0)
)

CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) UNIQUE
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) UNIQUE,
	AddressText NVARCHAR(30),
	Summary NVARCHAR(200),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30),
	Description NVARCHAR(200),
	OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
	DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id),
	CONSTRAINT PK_ProductsIngredients PRIMARY KEY(ProductId, IngredientId)
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR CHECK(Gender IN ('M', 'F')),
	Age INT,
	PhoneNumber CHAR(10) CHECK(LEN(PhoneNumber) = 10),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	Description NVARCHAR(255),
	Rate Decimal(4, 2) CHECK(Rate BETWEEN 0 AND 10),
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)

/*--02--*/
INSERT INTO Distributors(Name, CountryId, AddressText, Summary) VALUES
('Deloitte & Touche', 2, '6 Arch St #9757' ,'Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName, LastName, Age, Gender, PhoneNumber, CountryId) VALUES
('Francoise',	'Rautenstrauch',	15,	'M',	'0195698399',	5),
('Kendra',	'Loud',	22,	'F',	'0063631526',	11),
('Lourdes',	'Bauswell',	50,	'M',	'0139037043',	8),
('Hannah',	'Edmison',	18,	'F',	'0043343686',	1),
('Tom',	'Loeza',	31,	'M',	'0144876096',	23),
('Queenie',	'Kramarczyk',	30,	'F',	'0064215793',	29),
('Hiu',	'Portaro',	25,	'M',	'0068277755',	16),
('Josefa',	'Opitz',	43,	'F',	'0197887645',	17)

/*--03--*/
UPDATE Ingredients
SET DistributorId = 35
WHERE Name IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

/*--04--*/
DELETE FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

/*--05--*/
SELECT Name, Price, Description FROM Products
ORDER BY Price DESC, Name

/*--06--*/
SELECT Name, Description, OriginCountryId FROM Ingredients
WHERE OriginCountryId IN(1, 10, 20)

/*--07--*/
SELECT TOP 15 i.Name, i.Description, c.Name AS CountryName FROM Ingredients AS i
JOIN Countries AS c ON i.OriginCountryId = c.Id
WHERE c.Name IN ('Bulgaria', 'Greece')
ORDER BY i.Name, c.Name 

/*--08--*/
SELECT TOP 10 p.Name, p.Description, AVG(f.Rate) AS AverageRate, COUNT(f.Id) AS FeedbacksAmount FROM Products AS p
JOIN Feedbacks AS f ON p.Id = f.ProductId
GROUP BY p.Id, p.Name, p.Description
ORDER BY AverageRate DESC, FeedbacksAmount DESC

/*--09--*/
SELECT f.ProductId, f.Rate, f.Description, f.CustomerId, c.Age, c.Gender FROM Feedbacks AS f
JOIN Customers AS c ON f.CustomerId = c.Id
WHERE f.Rate < 5
ORDER BY f.ProductId DESC, f.Rate

/*--10--*/
SELECT CONCAT(c.FirstName, ' ' , c.LastName) AS CustomerName, c.PhoneNumber, c.Gender FROM Customers AS c
LEFT JOIN Feedbacks AS f ON c.Id = f.CustomerId
WHERE f.ProductId IS NULL
ORDER BY c.Id

/*--11--*/
SELECT f.ProductId, CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName, f.Description AS FeedbackDescription FROM Feedbacks AS f
JOIN
(
	SELECT CustomerId, COUNT(Id) AS Count FROM Feedbacks
	GROUP BY CustomerId
	HAVING COUNT(Id) >= 3
) AS t
ON f.CustomerId = t.CustomerId
JOIN Customers AS c ON c.Id = t.CustomerId
ORDER BY f.ProductId, CustomerName, f.Id

/*--12--*/
SELECT c.FirstName, c.Age, c.PhoneNumber FROM Customers AS c
JOIN Countries AS co ON c.CountryId =co.Id
WHERE (c.Age >= 21 AND c.FirstName LIKE '%an%') OR (RIGHT(c.PhoneNumber, 2) = '38' AND co.Name NOT LIKE  'Greece')
ORDER BY FirstName, Age DESC

/*--13--*/
SELECT d.Name AS DistributorName, i.Name AS IngredientName, p.Name AS ProductName, AVG(f.Rate) AS AverageRate FROM Distributors AS d
JOIN Ingredients AS i ON d.Id = i.DistributorId
JOIN ProductsIngredients AS pi ON i.Id = pi.IngredientId
JOIN Products AS p ON pi.ProductId = p.Id
JOIN Feedbacks AS f ON p.Id = f.ProductId
GROUP BY i.Name, d.Name, p.Name
HAVING AVG(Rate) BETWEEN 5 AND 8
ORDER BY d.Name, i.Name, p.Name

/*--14--*/
WITH CTE_HighestRatePerCountry(HighestRate) AS
(
	SELECT TOP 1 AVG(Rate) FROM Feedbacks AS f
	JOIN Customers AS c ON f.CustomerId = c.Id
	JOIN Countries AS co ON c.CountryId = co.Id
	GROUP BY co.Name
	ORDER BY AVG(Rate) DESC
)

SELECT co.Name AS CountryName, AVG(Rate) AS FeedbackRate FROM Feedbacks AS f
JOIN Customers AS c ON f.CustomerId = c.Id
JOIN Countries AS co ON c.CountryId = co.Id
JOIN CTE_HighestRatePerCountry AS hr ON 1=1
GROUP BY co.Name, hr.HighestRate
HAVING AVG(Rate) = hr.HighestRate

/*--15--*/
WITH CTE_DistributorsIngredientsCount(CountryName, Count) AS
(
	SELECT Name, MAX(Count) FROM
	(
		SELECT c.Name AS Name, COUNT(i.Id) AS Count FROM Countries AS c
		JOIN Distributors AS d ON c.Id = d.CountryId
		JOIN Ingredients AS i ON d.Id = i.DistributorId
		GROUP BY c.Name, d.Id
	) AS t
	GROUP BY Name
)

SELECT c.Name AS CountryName, d.Name AS DistributorName FROM Countries AS c
JOIN Distributors AS d ON c.Id = d.CountryId
JOIN Ingredients AS i ON d.Id = i.DistributorId
JOIN CTE_DistributorsIngredientsCount AS dic ON c.Name = dic.CountryName
GROUP BY c.Name, d.Name, dic.Count
HAVING COUNT(i.Id) = dic.Count
ORDER BY CountryName, DistributorName

GO

/*--16--*/
CREATE VIEW v_UserWithCountries AS
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName, c.Age, c.Gender, co.Name AS CountryNAme FROM Customers AS c
JOIN Countries AS co ON c.CountryId = co.Id

GO

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

 GO

/*--17--*/
CREATE FUNCTION dbo.udf_GetRating(@Name NVARCHAR(MAX))
RETURNS VARCHAR(20) AS
BEGIN
	DECLARE @Id INT = (SELECT Id FROM Products WHERE Name LIKE @Name)
	DECLARE @AvgRate DECIMAL(4,2) = (SELECT AVG(Rate) FROM Feedbacks WHERE ProductId = @Id)

	RETURN
		CASE
			WHEN @AvgRate < 5 THEN 'Bad'
			WHEN @AvgRate BETWEEN 5 AND 8 THEN 'Average'
			WHEN @AvgRate > 8 THEN 'Good'
			ELSE 'No rating'
		END
END

GO
SELECT TOP 5 Id, Name, dbo.udf_GetRating(Name)
  FROM Products
 ORDER BY Id

GO

/*--18--*/
CREATE PROC usp_SendFeedback(@CustomerId INT, @ProductId INT, @Rate DECIMAL(4, 2), @Description NVARCHAR(MAX)) AS
BEGIN
	DECLARE @FeedbacksCount INT = (SELECT COUNT(ProductId) FROM Feedbacks WHERE ProductId = @ProductId AND CustomerId = @CustomerId)

	IF(@FeedbacksCount >= 3)
	BEGIN
		RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1)
		RETURN
	END

	INSERT INTO Feedbacks(Description, Rate, ProductId, CustomerId) VALUES
	(@Description, @Rate, @ProductId, @CustomerId)
END

GO

/*--19--*/
CREATE TRIGGER tr_DeleteProductWithRelations ON Products INSTEAD OF DELETE AS
BEGIN
	DECLARE @Id INT = (SELECT Id FROM deleted)
	
	DELETE FROM ProductsIngredients
	WHERE ProductId = @Id

	DELETE FROM Feedbacks
	WHERE ProductId = @Id

	DELETE FROM Products
	WHERE Id = @Id
END

/*--20--*/
WITH CTE_ProductsDistributorCount (ProductId, DistributorsCount) AS
(
	SELECT p.Id, COUNT(DISTINCT i.DistributorId) FROM Products AS p
	JOIN ProductsIngredients AS pi ON p.Id = pi.ProductId
	JOIN Ingredients AS i ON pi.IngredientId = i.Id
	JOIN Distributors AS d ON i.DistributorId = d.Id
	GROUP BY p.Id
)

SELECT p.Name AS ProductName, AVG(f.Rate) AS ProductAverageRate, d.Name AS DistributorName, c.Name AS DistributorCountry FROM Products AS p
JOIN CTE_ProductsDistributorCount AS pdc ON p.Id = pdc.ProductId
LEFT JOIN Feedbacks AS f ON p.Id = f.ProductId
LEFT JOIN ProductsIngredients AS pi ON p.Id = pi.ProductId
LEFT JOIN Ingredients AS i ON pi.IngredientId = i.Id
LEFT JOIN Distributors AS d ON i.DistributorId = d.Id
LEFT JOIN Countries AS c ON d.CountryId = c.Id
WHERE pdc.DistributorsCount = 1
GROUP BY p.Id, p.Name, d.Name, c.Name
ORDER BY p.Id
