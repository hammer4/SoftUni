USE Bank
GO

CREATE TABLE Logs
(
	LogID INT PRIMARY KEY IDENTITY,
	AccountID INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)

GO

/*--01--*/
CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
  INSERT INTO Logs
  SELECT inserted.Id, deleted.Balance, inserted.Balance FROM inserted
  JOIN deleted
  ON inserted.Id = deleted.Id

UPDATE Accounts
SET Balance -= 10
WHERE Id = 1

SELECT * FROM Logs
/*--02--*/
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
	Subject VARCHAR(100),
	Body VARCHAR(200)
)
GO

CREATE TRIGGER tr_LogsInsert ON Logs FOR INSERT
AS
	INSERT INTO NotificationEmails
	SELECT AccountId,  
		'Balance change for account: ' + CAST(AccountID AS varchar(20)),
		'On ' + CONVERT(VARCHAR(50), GETDATE(), 100) + ' your balance was changed from ' + 
		CAST(OldSum AS varchar(20)) + ' to ' + CAST(NewSum AS varchar(20))
		FROM inserted

UPDATE Accounts
SET Balance -= 10
WHERE Id = 1

SELECT * FROM NotificationEmails
GO

/*--03--*/
CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY) AS
BEGIN
	BEGIN TRAN
		IF (@MoneyAmount > 0)
		BEGIN
			UPDATE Accounts
			SET Balance += @MoneyAmount
			WHERE Id = @AccountId

			IF @@ROWCOUNT != 1
			BEGIN
				ROLLBACK
				RAISERROR('Invalid account!', 16, 1)
				RETURN
			END
		END
	COMMIT
END 

EXEC usp_DepositMoney 1, 10
SELECT * FROM Accounts
GO

/*--04--*/
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY) AS
BEGIN
	BEGIN TRAN
		IF (@MoneyAmount > 0)
		BEGIN
			UPDATE Accounts
			SET Balance -= @MoneyAmount
			WHERE Id = @AccountId

			IF @@ROWCOUNT != 1
			BEGIN
				ROLLBACK
				RAISERROR('Invalid account!', 16, 1)
				RETURN
			END
		END
	COMMIT
END

EXEC usp_WithdrawMoney 5, 25
SELECT * FROM Accounts
GO

/*--05--*/
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount money) AS
BEGIN 
	BEGIN TRAN
		IF(@Amount > 0)
		BEGIN
			EXEC usp_WithdrawMoney @SenderId, @Amount
			EXEC usp_DepositMoney @ReceiverId, @Amount
		END
	COMMIT
END

EXEC usp_TransferMoney 5, 1, 5000

SELECT * FROM Accounts
GO

/*--06--*/
USE Diablo
GO

CREATE TRIGGER tr_UserGameItems ON UserGameItems INSTEAD OF INSERT AS
BEGIN 
	INSERT INTO UserGameItems
	SELECT i.Id, ug.Id FROM inserted
	JOIN UsersGames AS ug
	ON UserGameId = ug.Id
	JOIN Items AS i
	ON ItemId = i.Id
	WHERE ug.Level >= i.MinLevel
END
GO

UPDATE UsersGames
SET Cash += 50000
FROM UsersGames AS ug
JOIN Users AS u
ON ug.UserId = u.Id
JOIN Games AS g
ON ug.GameId = g.Id
WHERE g.Name = 'Bali' AND u.Username IN('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
GO

CREATE PROC usp_BuyItems(@Username VARCHAR(100)) AS
BEGIN
	DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = @Username)
	DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = 'Bali')
	DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
	DECLARE @UserGameLevel INT = (SELECT Level FROM UsersGames WHERE Id = @UserGameId)

	DECLARE @counter INT = 251

	WHILE(@counter <= 539)
	BEGIN
		DECLARE @ItemId INT = @counter
		DECLARE @ItemPrice MONEY = (SELECT Price FROM Items WHERE Id = @ItemId)
		DECLARE @ItemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @ItemId)
		DECLARE @UserGameCash MONEY = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId)

		IF(@UserGameCash >= @ItemPrice AND @UserGameLevel >= @ItemLevel)
		BEGIN
			UPDATE UsersGames
			SET Cash -= @ItemPrice
			WHERE Id = @UserGameId

			INSERT INTO UserGameItems VALUES
			(@ItemId, @UserGameId)
		END

		SET @counter += 1
		
		IF(@counter = 300)
		BEGIN
			SET @counter = 501
		END
	END
END

EXEC usp_BuyItems 'baleremuda'
EXEC usp_BuyItems 'loosenoise'
EXEC usp_BuyItems 'inguinalself'
EXEC usp_BuyItems 'buildingdeltoid'
EXEC usp_BuyItems 'monoxidecos'
GO

SELECT * FROM Users AS u
JOIN UsersGames AS ug
ON u.Id = ug.UserId
JOIN Games AS g
ON ug.GameId = g.Id
JOIN UserGameItems AS ugi
ON ug.Id = ugi.UserGameId
JOIN Items AS i
ON ugi.ItemId = i.Id
WHERE g.Name = 'Bali'
ORDER BY u.Username, i.Name
GO

/*--07--*/
DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = 'Stamat')
DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = 'Safflower')
DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
DECLARE @UserGameLevel INT = (SELECT Level FROM UsersGames WHERE Id = @UserGameId)
DECLARE @ItemStartLevel INT = 11
DECLARE @ItemEndLevel INT = 12
DECLARE @AllItemsPrice MONEY = (SELECT SUM(Price) FROM Items WHERE (MinLevel BETWEEN @ItemStartLevel AND @ItemEndLevel)) 
DECLARE @StamatCash MONEY = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId)

IF(@StamatCash >= @AllItemsPrice)
BEGIN
	BEGIN TRAN	
		UPDATE UsersGames
		SET Cash -= @AllItemsPrice
		WHERE Id = @UserGameId
	
		INSERT INTO UserGameItems
		SELECT i.Id, @UserGameId  FROM Items AS i
		WHERE (i.MinLevel BETWEEN @ItemStartLevel AND @ItemEndLevel)
	COMMIT
END

SET @ItemStartLevel = 19
SET @ItemEndLevel = 21
SET @AllItemsPrice = (SELECT SUM(Price) FROM Items WHERE (MinLevel BETWEEN @ItemStartLevel AND @ItemEndLevel)) 
SET @StamatCash = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId)

IF(@StamatCash >= @AllItemsPrice)
BEGIN
	BEGIN TRAN
		UPDATE UsersGames
		SET Cash -= @AllItemsPrice
		WHERE Id = @UserGameId
	
		INSERT INTO UserGameItems
		SELECT i.Id, @UserGameId  FROM Items AS i
		WHERE (i.MinLevel BETWEEN @ItemStartLevel AND @ItemEndLevel)
	COMMIT
END

SELECT i.Name AS [Item Name] FROM Users AS u
JOIN UsersGames AS ug
ON u.Id = ug.UserId
JOIN Games AS g
ON ug.GameId = g.Id
JOIN UserGameItems AS ugi
ON ug.Id = ugi.UserGameId
JOIN Items AS i
ON ugi.ItemId = i.Id
WHERE u.Username = 'Stamat' AND g.Name = 'Safflower'
ORDER BY i.Name

/*-08--*/
USE SoftUni
GO

CREATE PROC usp_AssignProject(@employeeId INT, @projectID INT) AS
BEGIN
	BEGIN TRAN
		INSERT INTO EmployeesProjects VALUES
		(@employeeId, @projectID)
		DECLARE @EmployeeProjectsCount INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeId = @employeeId)
		IF(@EmployeeProjectsCount > 3)
		BEGIN
			ROLLBACK
			RAISERROR('The employee has too many projects!', 16, 1)
			RETURN
		END
	COMMIT
END 

/*--09--*/
CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentID INT NOT NULL,
	Salary MONEY NOT NULL
)
GO

CREATE TRIGGER tr_DeleteEmployees ON Employees AFTER DELETE AS
	INSERT INTO Deleted_Employees
	SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary FROM deleted

