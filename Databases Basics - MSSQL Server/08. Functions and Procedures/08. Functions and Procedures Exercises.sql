USE SoftUni
GO

/*--01--*/
CREATE PROC usp_GetEmployeesSalaryAbove35000 AS
SELECT FirstName, LastName FROM Employees
WHERE Salary > 35000

EXEC usp_GetEmployeesSalaryAbove35000
GO

/*--02--*/
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@Salary DECIMAL(18,4)) AS
SELECT FirstName, LastName FROM Employees
WHERE Salary >= @Salary

EXEC usp_GetEmployeesSalaryAboveNumber 48100
GO

/*--03--*/
CREATE PROC usp_GetTownsStartingWith(@StartWith VARCHAR(50)) AS
SELECT Name AS Town FROM Towns
WHERE Name LIKE @StartWith + '%'

EXEC usp_GetTownsStartingWith 'b'
GO

/*--04--*/
CREATE PROC usp_GetEmployeesFromTown(@TownName VARCHAR(50)) AS
SELECT e.FirstName, e.LastName FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
WHERE t.Name = @TownName

EXEC usp_GetEmployeesFromTown 'Sofia'
GO

/*--05--*/
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10) AS
BEGIN
	DECLARE @SalaryLevel VARCHAR(10)
	SET @SalaryLevel =
		CASE
			WHEN @salary < 30000 THEN 'Low'
			WHEN @salary <= 50000 THEN 'Average'
			ELSE 'High'
		END
	RETURN @SalaryLevel
END
GO

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] FROM Employees
GO

/*--06--*/
CREATE PROC usp_EmployeesBySalaryLevel(@SalaryLevel VARCHAR(10)) AS
SELECT FirstName, LastName FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel

EXEC usp_EmployeesBySalaryLevel 'High'
GO

/*--07--*/
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT AS
BEGIN
	DECLARE @WordLength INT = LEN(@word)
	DECLARE @Index INT = 1

	WHILE (@Index <= @WordLength)
	BEGIN
		IF (CHARINDEX(SUBSTRING(@word, @Index, 1), @setOfLetters) = 0)
		BEGIN
			RETURN 0
		END

		SET @Index += 1
	END

	RETURN 1
END
GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob')
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')
GO

/*--08--*/
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) AS
ALTER TABLE Employees
DROP CONSTRAINT FK_Employees_Employees

ALTER TABLE EmployeesProjects
DROP CONSTRAINT FK_EmployeesProjects_Employees

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE

ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees

ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

UPDATE Departments
SET ManagerID = NULL
WHERE DepartmentID = @departmentId

UPDATE Employees
SET ManagerID = NULL
WHERE DepartmentID = @departmentId

DELETE FROM Employees
WHERE DepartmentID = @departmentId AND ManagerID IS NULL

DELETE FROM Departments
WHERE DepartmentID = @departmentId

IF OBJECT_ID('[Employees].[FK_Employees_Employees]') IS NULL
    ALTER TABLE [Employees] WITH NOCHECK
        ADD CONSTRAINT [FK_Employees_Employees] FOREIGN KEY ([ManagerID]) REFERENCES [Employees]([EmployeeID]) ON DELETE NO ACTION ON UPDATE NO ACTION

IF OBJECT_ID('[Departments].[FK_Departments_Employees]') IS NULL
    ALTER TABLE [Departments] WITH NOCHECK
        ADD CONSTRAINT [FK_Departments_Employees] FOREIGN KEY ([ManagerID]) REFERENCES [Employees]([EmployeeID]) ON DELETE NO ACTION ON UPDATE NO ACTION

SELECT COUNT(*) FROM Employees
WHERE DepartmentID = @departmentId

EXEC usp_DeleteEmployeesFromDepartment 4
GO

/*--09--*/
USE Bank
GO

CREATE PROC usp_GetHoldersFullName AS
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] FROM AccountHolders

EXEC usp_GetHoldersFullName
GO

/*--10--*/
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@money DECIMAL(16,2)) AS
SELECT ah.FirstName, ah.LastName FROM Accounts AS a
JOIN AccountHolders AS ah
ON a.AccountHolderId = ah.Id
GROUP BY ah.FirstName, ah.LastName
HAVING SUM(a.Balance) > @money

EXEC usp_GetHoldersWithBalanceHigherThan 20000
GO

/*--11--*/
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(16, 2), @Interest FLOAT, @Years INT) 
RETURNS DECIMAL(20, 4) AS
BEGIN
	DECLARE @FutureValue DECIMAL(20, 4) = @Sum * POWER(1 + @Interest, @Years)
	RETURN @FutureValue
END
GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)
GO

/*--12--*/
CREATE PROC usp_CalculateFutureValueForAccount(@AccountID INT, @InterestRate FLOAT) AS
SELECT 
	a.Id AS [Account Id], 
	ah.FirstName AS [First Name],
	ah.LastName AS [Last Name],
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years] 
	FROM Accounts AS a
JOIN AccountHolders AS ah
ON a.AccountHolderId = ah.Id AND a.Id = @AccountID

EXEC usp_CalculateFutureValueForAccount 1, 0.1
GO

/*--13--*/
USE Diablo
GO

CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS TABLE AS
RETURN	SELECT SUM(Cash) AS SumCash FROM
	(
		SELECT ug.Cash, ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RowNum FROM UsersGames AS ug
		JOIN Games AS g
		ON g.Id = ug.GameId
		WHERE g.Name = @gameName
	) AS AllGameRows
	WHERE RowNum % 2 = 1
GO

SELECT * FROM dbo.ufn_CashInUsersGames('Lily Stargazer')