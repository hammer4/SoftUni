USE Gringotts

/*--01--*/
SELECT COUNT(*) AS Count FROM WizzardDeposits 

/*--02--*/
SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits

/*--03--*/
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits
GROUP BY DepositGroup

/*--04--*/
SELECT TOP 2 DepositGroup FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

/*--05--*/
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
GROUP BY DepositGroup

/*--06--*/
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander Family'
GROUP BY DepositGroup

/*--07--*/
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander Family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

/*--08--*/
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

/*--09--*/
SELECT *, COUNT(*) AS WizardCount FROM 
(
SELECT 
  CASE
   WHEN Age <= 10 THEN '[0-10]'
   WHEN Age between 11 and 20 THEN '[11-20]'
   WHEN Age between 21 and 30 THEN '[21-30]'
   WHEN Age between 31 and 40 THEN '[31-40]'
   WHEN Age between 41 and 50 THEN '[41-50]'
   WHEN Age between 51 and 60 THEN '[51-60]'
   ELSE '[61+]'
 END AS AgeGroup 
 FROM WizzardDeposits
) AS t
GROUP BY AgeGroup
ORDER BY AgeGroup

/*--10--*/
SELECT LEFT(FirstName, 1) AS FirstLetter FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)

/*--11--*/
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) FROM WizzardDeposits
WHERE DATEPART(YEAR, DepositStartDate) >= 1985
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

/*--12--*/
SELECT SUM(Difference) FROM (
SELECT Wiz1.FirstName AS [Host Wizzard], Wiz1.DepositAmount AS [Host Wizzard Deposit],
	Wiz2.FirstName AS [Guest Wizzard], Wiz2.DepositAmount AS [Guest Wizzard Deposit],
	Wiz1.DepositAmount - Wiz2.DepositAmount AS Difference
  FROM WizzardDeposits AS Wiz1
INNER JOIN WizzardDeposits AS Wiz2
ON Wiz1.Id = Wiz2.Id - 1) AS t

/*--13--*/
USE SoftUni

SELECT DepartmentID, SUM(Salary) AS TotalSalary FROM Employees
GROUP BY DepartmentID

/*--14--*/
SELECT DepartmentID, MIN(Salary) AS MinimumSalary FROM Employees
WHERE DATEPART(YEAR, HireDate) >= 2000
GROUP BY DepartmentID
HAVING DepartmentID IN (2, 5, 7)

/*--15--*/
SELECT * 
INTO EmployeesWithHighSalary
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithHighSalary
WHERE ManagerID = 42

UPDATE EmployeesWithHighSalary
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM EmployeesWithHighSalary
GROUP BY DepartmentID

/*--16--*/
SELECT DepartmentID, MAX(Salary) AS MaxSalary FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

/*--17--*/
SELECT COUNT(Salary) AS [Count] FROM Employees
WHERE ManagerID IS NULL

/*--18--*/
SELECT a.DepartmentId,
(
	SELECT DISTINCT b.Salary FROM Employees AS b
	WHERE b.DepartmentID = a.DepartmentId
	ORDER BY Salary DESC
	OFFSET 2 ROWS
	FETCH NEXT 1 ROWS ONLY
) AS [ThirdHighestSalary]
FROM Employees AS a
WHERE (
	SELECT DISTINCT b.Salary FROM Employees AS b
	WHERE b.DepartmentID = a.DepartmentId
	ORDER BY Salary DESC
	OFFSET 2 ROWS
	FETCH NEXT 1 ROWS ONLY
) IS NOT NULL
GROUP BY a.DepartmentID

/*--19--*/
SELECT TOP 10 FirstName, LastName, DepartmentID FROM Employees AS e
WHERE Salary > (
	SELECT AVG(Salary) FROM Employees AS e2
	WHERE e2.DepartmentID = e.DepartmentID
	)
ORDER BY DepartmentID
