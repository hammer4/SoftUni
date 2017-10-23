CREATE DATABASE ReportService
GO

USE ReportService
GO

/*--01--*/
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL UNIQUE,
	Password NVARCHAR(50) NOT NULL,
	Name NVARCHAR(50),
	Gender CHAR CHECK(Gender IN('M', 'F')),
	BirthDate DATETIME,
	Age INT,
	Email NVARCHAR(50) NOT NULL 
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR CHECK(Gender IN('M', 'F')),
	BirthDate DATETIME,
	Age INT,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Status
(
	Id INT PRIMARY KEY IDENTITY,
	Label VARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	Description VARCHAR(200),
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

/*--02--*/
INSERT INTO Employees(FirstName, LastName, Gender, BirthDate, DepartmentId) VALUES
('Marlo',	'O’Malley',	'M',	'9/21/1958',	1),
('Niki',	'Stanaghan',	'F',	'11/26/1969',	4),
('Ayrton',	'Senna',	'M',	'03/21/1960', 	9),
('Ronnie',	'Peterson',	'M',	'02/14/1944',	9),
('Giovanna',	'Amati',	'F',	'07/20/1959',	5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId) VALUES
(1,	1,	'04/13/2017', NULL		, 'Stuck Road on Str.133',	6,	2),
(6,	3,	'09/05/2015',	'12/06/2015',	'Charity trail running',	3,	5),
(14, 2,	'09/07/2015', NULL,	'Falling bricks on Str.58',	5,	2),
(4, 3,	'07/03/2017',	'07/06/2017',	'Cut off streetlight on Str.11',	1,	1)


/*--03--*/
UPDATE Reports
SET StatusId = 2
WHERE StatusID = 1 AND CategoryId = 4

/*--04--*/
DELETE FROM Reports
WHERE StatusId = 4

/*--05--*/
SELECT Username, Age FROM Users
ORDER BY Age, Username DESC

/*--06--*/
SELECT Description, OpenDate FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, Description

/*--07--*/
SELECT e.FirstName, e.LastName, r.Description, FORMAT(r.OpenDate, 'yyyy-MM-dd') AS OpenDate FROM Reports AS r
JOIN Employees AS e ON r.EmployeeId = e.Id
ORDER BY e.Id, r.OpenDate, r.Id

/*--08--*/
SELECT c.Name AS CategoryName, COUNT(r.Id) AS ReportsNumber FROM Categories AS c
JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY ReportsNumber DESC, CategoryName

/*--09--*/
SELECT c.Name AS CategoryName, ISNULL(COUNT(e.Id), 0) AS [Employees Number] FROM Categories AS c
LEFT JOIN Departments AS d ON c.DepartmentId = d.Id
LEFT JOIN Employees AS e ON d.Id = e.DepartmentId
GROUP BY c.Name
ORDER BY c.Name

/*--10--*/
SELECT Name, SUM([Users Number]) FROM
(
	SELECT e.Id, CONCAT(e.FirstName, ' ', e.LastName) AS Name, COUNT(r.UserId) AS [Users Number] FROM Employees AS e
	LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
	GROUP BY e.Id, e.FirstName, e.LastName, r.UserId
) AS t
GROUP BY Id, Name
ORDER BY SUM([Users Number]) DESC, Name

/*--11--*/
SELECT r.OpenDate, r.Description, u.Email AS [Reporter Email] FROM Users AS u
JOIN Reports AS r ON u.Id = r.UserId
JOIN Categories AS c ON r.CategoryId = c.Id
JOIN Departments AS d ON c.DepartmentId = d.Id
WHERE r.CloseDate IS NULL AND LEN(r.Description) > 20 AND r.Description LIKE '%str%' 
	AND d.Name IN ('Infrastructure', 'Emergency', 'Roads Maintenance')
ORDER BY r.OpenDate, u.Email, r.Id

/*--12--*/
SELECT c.Name FROM Users AS u
JOIN Reports AS r ON u.Id = r.UserId
JOIN Categories As c ON r.CategoryId = c.Id
WHERE MONTH(r.OpenDate) = MONTH(u.BirthDate) AND DAY(r.OpenDate) = DAY(u.BirthDate)
GROUP BY c.Name
ORDER BY c.Name

/*--13--*/
SELECT u.Username FROM Users AS u
JOIN Reports AS r ON u.Id = r.UserId
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE (LEFT(u.Username, 1) LIKE '[0-9]' AND c.Id = TRY_CAST(LEFT(u.Username, 1) AS INT))
	OR (RIGHT(u.Username, 1) LIKE '[0-9]' AND c.Id = TRY_CAST(RIGHT(u.Username, 1) AS INT))
GROUP BY u.Username
ORDER BY u.Username

/*--14--*/
WITH CTE_OpenedRepots(EmployeeId, Count) AS
(
	SELECT e.Id, COUNT(r.Id) FROM Employees AS e
	JOIN Reports AS r ON e.Id = r.EmployeeId
	WHERE DATEPART(YEAR, r.OpenDate) = 2016
	GROUP BY e.Id
),

CTE_ClosededRepots(EmployeeId, Count) AS
(
	SELECT e.Id, COUNT(r.Id) FROM Employees AS e
	JOIN Reports AS r ON e.Id = r.EmployeeId
	WHERE DATEPART(YEAR, r.CloseDate) = 2016
	GROUP BY e.Id
)

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS Name, CONCAT(ISNULL(c.Count, 0), '/', ISNULL(o.Count, 0)) AS [Closed Open Reports] 
FROM  CTE_ClosededRepots AS c 
FULL JOIN CTE_OpenedRepots AS o ON c.EmployeeId = o.EmployeeId
JOIN Employees AS e ON c.EmployeeId = e.Id OR o.EmployeeId = e.Id
ORDER BY Name, e.Id

/*--15--*/
SELECT d.Name AS [Department Name], 
	CASE
		WHEN CAST(AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate)) AS VARCHAR(20)) IS NULL THEN 'no info'
		ELSE CAST(AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate)) AS VARCHAR(20))
	END AS [Average Duration]
FROM Departments AS d
JOIN Categories AS c ON d.Id = c.DepartmentId
JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY d.Name

GO

/*--16--*/
WITH CTE_TotalReportsByDepartment (DepartmentId, Count) AS
(
	SELECT d.Id, COUNT(r.Id) FROM Departments AS d
	JOIN Categories AS c ON d.Id = c.DepartmentId
	JOIN Reports AS r ON c.Id = r.CategoryId
	GROUP BY d.Id
)

SELECT d.Name AS [Department Name], c.Name AS [Category Name], CAST(ROUND(CEILING(CAST(COUNT(r.Id) AS DECIMAL(7,2)) * 100)/tr.Count, 0) AS INT) AS Percentage FROM Departments AS d
JOIN CTE_TotalReportsByDepartment AS tr ON d.Id = tr.DepartmentId
JOIN Categories AS c ON d.Id = c.DepartmentId
JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY d.Name, c.Name, tr.Count

GO

/*--17--*/
CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT) RETURNS INT AS
BEGIN
	RETURN
		(	SELECT COUNT(r.Id) FROM  Reports As r
			WHERE r.StatusId = @statusId AND r.EmployeeId = @employeeId
	    )
END


SELECT Id, FirstName, Lastname, dbo.udf_GetReportsCount(1, 2) AS ReportsCount
FROM Employees
ORDER BY Id

GO

/*--18--*/
CREATE PROC usp_AssignEmployeeToReport(@employeeId INT, @reportId INT) AS
BEGIN
	DECLARE @EmployeeDepartment INT = 
	(	SELECT e.DepartmentId FROM Employees AS e
		WHERE e.Id = @employeeId
	)

	DECLARE @ReportDepartment INT =
	(
		SELECT c.DepartmentId FROM Categories AS c
		JOIN Reports AS r ON c.Id = r.CategoryId
		WHERE r.Id = @reportId
	)

	IF(@EmployeeDepartment != @ReportDepartment)
	BEGIN;
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
		RETURN
	END

	UPDATE Reports
	SET EmployeeId = @employeeId
	WHERE Id = @reportId
END

GO
/*--19--*/
CREATE TRIGGER tr_CloseReport ON Reports AFTER UPDATE AS
BEGIN
	UPDATE Reports
	SET StatusId = 3
	FROM deleted AS d
	JOIN inserted AS i ON d.Id = i.Id
	WHERE i.CloseDate IS NOT NULL
END

/*--20--*/
WITH CTE_MostCommonProgress (CategoryId, Count) AS
(
	SELECT c.Id AS CategoryId, 
	CASE
		WHEN COUNT(r.StatusId) = 0 then NULL
		ELSE COUNT(r.StatusId)
	end AS Count FROM Categories AS c
	JOIN Reports AS r ON c.Id = r.CategoryId
	WHERE r.StatusId = 2
	GROUP BY c.Id
),


CTE_MostCommonwaiting (CategoryId, Count) AS
(
	SELECT c.Id AS CategoryId,
	CASE
		WHEN COUNT(r.StatusId) = 0 then NULL
		ELSE COUNT(r.StatusId)
	END AS Count FROM Categories AS c
	JOIN Reports AS r ON c.Id = r.CategoryId
	WHERE r.statusid = 1
	GROUP BY c.Id
)

SELECT 
c.Name AS [Category Name],
ISNULL(SUM(prog.Count), 0) + ISNULL(SUM(wait.Count), 0) AS [Reports Number],
CASE
	WHEN ISNULL(SUM(prog.Count), 0) > ISNULL(SUM(wait.Count), 0) THEN 'in progress'
	WHEN ISNULL(SUM(prog.Count), 0) < ISNULL(SUM(wait.Count), 0) THEN 'waiting'
	ELSE 'equal'
END [Main Status]
FROM Categories AS c
LEFT JOIN CTE_MostCommonProgress as prog ON c.Id = prog.CategoryId
LEFT JOIN CTE_MostCommonwaiting as wait ON c.Id = wait.CategoryId
GROUP BY c.Id, c.Name
HAVING ISNULL(SUM(prog.Count), 0) + ISNULL(SUM(wait.Count), 0) > 0
ORDER BY c.Name, [Reports Number], [Main Status]
