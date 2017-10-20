CREATE DATABASE WMS
GO

USE WMS
GO

/*--01--*/
CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	Status VARCHAR(11) CHECK(Status IN ('Pending', 'In Progress', 'Finished')) DEFAULT 'Pending',
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0 NOT NULL
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	Description VARCHAR(255),
	Price MONEY CHECK(Price > 0 AND Price < 10000) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT CHECK(StockQty >= 0) DEFAULT 0 NOT NULL
)

CREATE TABLE OrderParts
(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT CHECK(Quantity > 0) DEFAULT 1 NOT NULL,
	CONSTRAINT PK_OrderParts PRIMARY KEY(OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT CHECK(Quantity > 0) DEFAULT 1 NOT NULL,
	CONSTRAINT PK_PartsNeeded PRIMARY KEY(JobId, PartId)
)

/*--02--*/
INSERT INTO Clients VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts VALUES
('WP8182119', 'Door Boot Seal', 117.86,	2, DEFAULT),
('W10780048', 'Suspension Rod',	42.81, 1, DEFAULT),
('W10841140', 'Silicone Adhesive', 6.77, 4, DEFAULT),
('WPY055980', 'High Temperature Adhesive', 13.94, 3, DEFAULT)

/*--03--*/
UPDATE Jobs
SET Status = 'In Progress',  MechanicId = 3
WHERE Status = 'Pending'

/*--04--*/
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

/*--05--*/
SELECT FirstName, LastName, Phone FROM Clients
ORDER BY LastName, ClientId

/*--06--*/
SELECT Status, IssueDate FROM JOBS
WHERE Status NOT LIKE 'Finished'
ORDER BY IssueDate, JobId

/*--07--*/
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic, j.Status, j.IssueDate FROM Mechanics AS m
JOIN Jobs AS j
ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId

/*--08--*/
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client, 
	DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going], 
	j.Status
	FROM Clients AS c
JOIN Jobs AS j
ON c.ClientId = j.ClientId
WHERE j.Status NOT LIKE 'Finished'
ORDER BY [Days going] DESC

/*--09--*/
SELECT CONCAT(FirstName, ' ', LastName) AS Mechanic, AVG(TimeSpan) AS [Average Days] FROM
(
	SELECT m.MechanicId, m.FirstName, m.LastName, DATEDIFF(DAY, j.IssueDate, j.FinishDate) AS TimeSpan FROM Mechanics AS m
	JOIN Jobs AS j
	ON m.MechanicId = j.MechanicId
	WHERE j.Status LIKE 'Finished'
) AS t
GROUP BY MechanicId, FirstName, LastName
ORDER BY MechanicId

/*--10--*/
SELECT TOP 3 CONCAT(FirstName, ' ',  LastName) AS Mechanic, COUNT(JobId) AS Jobs FROM Mechanics AS m
JOIN Jobs AS j
ON m.MechanicId = j.MechanicId
WHERE j.Status NOT LIKE 'Finished'
GROUP BY m.MechanicId, m.FirstName, m.LastName
HAVING COUNT(JobId) > 1
ORDER BY Jobs DESC, m.MechanicId

/*--11--*/
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Available FROM Mechanics AS m
LEFT JOIN Jobs AS j
ON m.MechanicId = j.MechanicId
WHERE j.Status LIKE 'Finished' OR j.Status IS NULL
GROUP BY m.MechanicId, m.FirstName, m.LastName
ORDER BY m.MechanicId

/*--12--*/
SELECT ISNULL(SUM(op.Quantity * p.Price), 0) AS [Parts Total] FROM Parts AS p
JOIN OrderParts AS op
ON p.PartId = op.PartId
JOIN Orders AS o
ON op.OrderId = o.OrderId
WHERE o.IssueDate BETWEEN DATEADD(WEEK, -3, '2017-04-24') AND '2017-04-24'

/*--13--*/
SELECT j.JobId, ISNULL(SUM(op.Quantity * p.Price), 0) AS Total FROM Jobs AS j
LEFT JOIN Orders AS o
ON j.JobId = o.JobId
LEFT JOIN OrderParts AS op
ON o.OrderId = op.OrderId
LEFT JOIN Parts AS p
ON op.PartId = p.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId

/*--14--*/
SELECT ModelId, Name, CONCAT(AVG(TimeSpan), ' days') AS [Average Service Time] FROM
(
	SELECT m.ModelId, m.Name, DATEDIFF(DAY, j.IssueDate, j.FinishDate) AS TimeSpan FROM Models AS m
	JOIN Jobs AS j
	ON m.ModelId = j.ModelId
	WHERE j.FinishDate IS NOT NULL
) AS t
GROUP BY ModelId, Name
ORDER BY CONVERT(INT, SUBSTRING(CONCAT(AVG(TimeSpan), ' days'), 1, CHARINDEX(' ', CONCAT(AVG(TimeSpan), ' days') , 1) - 1))

/*--15--*/
WITH CTE_MostServicedModelCount(ServicesCount) AS
(
	SELECT TOP 1 COUNT(ModelId) FROM Jobs
	GROUP BY ModelId
	ORDER BY COUNT(ModelId) DESC
),

CTE_AllModelsPartsCost(ModelId, TotalCost) AS
(
	SELECT j.ModelId, ISNULL(SUM(p.Price * op.Quantity), 0) FROM Models AS m
	LEFT JOIN Jobs AS j
	ON m.ModelId = j.ModelId
	LEFT JOIN Orders AS o
	ON j.JobId = o.JobId
	LEFT JOIN OrderParts AS op
	ON o.OrderId = op.OrderId
	LEFT JOIN Parts AS p
	ON op.PartId = p.PartId
	GROUP BY j.ModelId
)

SELECT m.Name AS Model, COUNT(j.ModelId) AS [Times Serviced], am.TotalCost AS [Parts Total] FROM Jobs AS j
JOIN CTE_AllModelsPartsCost AS am
ON j.ModelId = am.ModelId
JOIN Models AS m
ON am.ModelId = m.ModelId
JOIN CTE_MostServicedModelCount AS ms
ON ms.ServicesCount >= 0
GROUP BY j.ModelId, m.Name, ms.ServicesCount, am.TotalCost
HAVING COUNT(j.ModelId) = ms.ServicesCount
ORDER BY COUNT(j.ModelId)

/*--16--*/
WITH CTE_ActiveJobsPartsQty (PartId, Quantity) AS
(
	SELECT pn.PartId, SUM(pn.Quantity) FROM Jobs AS j
	JOIN PartsNeeded AS pn
	ON j.JobId = pn.JobId
	WHERE j.Status NOT LIKE 'Finished'
	GROUP BY pn.PartId
),

CTE_PendingOrdersQty (PartId, Quantity) AS
(
	SELECT p.PartId, SUM(op.Quantity) FROM Parts AS p
	JOIN OrderParts AS op
	ON p.PartId = op.PartId
	JOIN Orders AS o
	ON op.OrderId = o.OrderId
	WHERE o.Delivered = 0
	GROUP BY p.PartId
)

SELECT p.PartId, p.Description, ajp.Quantity AS Required, p.StockQty AS [In Stock], ISNULL(poq.Quantity, 0) AS Ordered FROM CTE_ActiveJobsPartsQty as ajp
JOIN Parts AS p 
ON ajp.PartId = p.PartId
LEFT JOIN CTE_PendingOrdersQty AS poq
ON p.PartId = poq.PartId
WHERE ajp.Quantity > p.StockQty + ISNULL(poq.Quantity, 0)
GO

/*--17--*/
CREATE FUNCTION udf_GetCost(@JobId INT) 
RETURNS DECIMAL(16, 2) AS
BEGIN
	DECLARE @Total DECIMAL(16, 2)
	SELECT @Total = SUM(PartsPrice) FROM
	(
		SELECT ISNULL(SUM(p.Price * op.Quantity), 0) AS PartsPrice FROM Orders AS o
		JOIN OrderParts AS op
		ON o.OrderId = op.OrderId
		JOIN Parts AS p
		ON op.PartId = p.PartId
		WHERE o.JobId = @JobId
	) AS t
	RETURN @Total
END
GO

/*--18--*/
CREATE PROC usp_PlaceOrder(@JobId INT, @SerialNumber VARCHAR(50), @Quantity INT) AS
BEGIN
	DECLARE @JobStatus VARCHAR(MAX) = (SELECT Status FROM Jobs WHERE JobId = @JobId)
	DECLARE @JobExists BIT = (SELECT COUNT(JobId) FROM Jobs WHERE JobId = @JobId)
	DECLARE @PartExists BIT = (SELECT COUNT(SerialNumber) FROM Parts WHERE SerialNumber = @SerialNumber)

	IF(@Quantity <= 0)
	BEGIN;
		THROW 50012, 'Part quantity must be more than zero!' , 1
	END

	IF(@JobStatus = 'Finished')
	BEGIN;
		THROW 50011, 'This job is not active!', 1
	END

	IF(@JobExists = 0)
	BEGIN;
		THROW 50013, 'Job not found!', 1
	END

	IF(@PartExists = 0)
	BEGIN;
		THROW 50014, 'Part not found!', 1
	END

	DECLARE @OrderForJobExists INT = 
	(
		SELECT COUNT(o.OrderId) FROM Orders AS o
		WHERE o.JobId = @JobId AND o.IssueDate IS NULL
	)

	IF(@OrderForJobExists = 0)
	BEGIN
		INSERT INTO Orders VALUES
		(@JobId, NULL, 0)
	END

	DECLARE @OrderId INT = 
	(
		SELECT o.OrderId FROM Orders AS o
		WHERE o.JobId = @JobId AND o.IssueDate IS NULL
	)

	IF(@OrderId > 0 AND @PartExists = 1 AND @Quantity > 0)
	BEGIN
		DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @SerialNumber)
		DECLARE @PartExistsInOrder INT = (SELECT COUNT(*) FROM OrderParts WHERE OrderId = @OrderId AND PartId = @PartId)

		IF(@PartExistsInOrder > 0)
		BEGIN
			UPDATE OrderParts
			SET Quantity += @Quantity
			WHERE OrderId = @OrderId AND PartId = @PartId
		END
		ELSE
		BEGIN
			INSERT INTO OrderParts VALUES
			(@OrderId, @PartId, @Quantity)
		END
	END
END
GO

/*--19--*/
CREATE TRIGGER tr_addQuantities ON Orders AFTER UPDATE AS
BEGIN
	UPDATE Parts
	SET StockQty += op.Quantity
	FROM deleted AS d
	JOIN inserted AS i
	ON d.OrderId = i.OrderId
	JOIN OrderParts AS op
	ON i.OrderId = op.OrderId
	WHERE d.Delivered = 0 AND i.Delivered = 1 AND Parts.PartId = op.PartId
END

/*--20--*/
WITH CTE_MechanicsAllParts(MechanicId, Count) AS
(
	SELECT m.MechanicId, SUM(op.Quantity) FROM Mechanics As m
	JOIN Jobs AS j ON m.MechanicId = j.MechanicId
	JOIN Orders AS o ON j.JobId = o.JobId
	JOIN OrderParts AS op ON o.OrderId = op.OrderId
	GROUP BY m.MechanicId
),

CTE_PartsByVendorMechanic(MechanicId, VendorId, VendorCount) AS
(
	SELECT m.MechanicId, v.VendorId, SUM(op.Quantity) FROM Mechanics AS m
	JOIN Jobs AS j ON m.MechanicId = j.MechanicId
	JOIN Orders AS o ON j.JobId = o.JobId
	JOIN OrderParts AS op ON o.OrderId = op.OrderId
	JOIN Parts as p ON op.PartId = p.PartId
	JOIN Vendors AS v ON p.VendorId = v.VendorId
	GROUP BY m.MechanicId, v.VendorId
)

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic, 
	v.Name AS Vendor, 
	pv.VendorCount AS Parts, 
	CONCAT((pv.VendorCount * 100)/ap.Count, '%') AS Preference  
	FROM Mechanics AS m
JOIN CTE_MechanicsAllParts AS ap ON m.MechanicId = ap.MechanicId
JOIN CTE_PartsByVendorMechanic AS pv ON ap.MechanicId = pv.MechanicId
JOIN Vendors AS v ON pv.VendorId = v.VendorId
ORDER BY Mechanic, Parts DESC, Vendor