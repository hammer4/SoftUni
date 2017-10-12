USE SoftUni
GO

/*--01--*/
SELECT TOP 5 e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID = e.AddressID
ORDER BY a.AddressID 

/*--02--*/
SELECT TOP 50 FirstName, LastName, t.Name AS Town, AddressText FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID = e.AddressID
JOIN Towns AS t
ON t.TownID = a.TownID
ORDER BY FirstName, LastName

/*--03--*/
SELECT EmployeeID, FirstName, LastName, d.Name AS DepartmentName FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID

/*--04--*/
SELECT TOP 5 e.EmployeeID, e.FirstName, e.Salary, d.Name AS DepartmentName FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

/*--05--*/
SELECT DISTINCT TOP(3) e.EmployeeID, e.FirstName FROM Employees AS e
RIGHT OUTER JOIN EmployeesProjects AS ep
ON e.EmployeeID NOT IN(SELECT DISTINCT EmployeeID FROM EmployeesProjects)
ORDER BY e.EmployeeID

/*--06--*/
SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID AND e.HireDate > '1999-01-01' AND (d.Name = 'Sales' OR d.Name = 'Finance')
ORDER BY e.HireDate

/*--07--*/
SELECT TOP 5 e.EmployeeID, e.FirstName, p.Name AS ProjectName FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON ep.ProjectID = p.ProjectID AND p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

/*--08--*/
SELECT e.EmployeeID, e.FirstName,
	CASE
		WHEN p.StartDate >= '2005-01-01' THEN NULL
		ELSE p.Name
	END AS ProjectName
	 FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID AND e.EmployeeID = 24
JOIN Projects AS p
ON p.ProjectID = ep.ProjectID

/*--09--*/
SELECT e.EmployeeID, e.FirstName, e.ManagerID, e2.FirstName AS ManagerName FROM Employees AS e
JOIN Employees AS e2
ON e2.EmployeeID = e.ManagerID AND e.ManagerID IN(3, 7)
ORDER BY e.EmployeeID

/*--10--*/
SELECT TOP 50 e.EmployeeID, CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	   CONCAT(e2.FirstName, ' ', e2.LastName) AS ManagerName, d.Name AS DepartmentName FROM Employees AS e
JOIN Employees AS e2
ON e2.EmployeeID = e.ManagerID
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID

/*--11--*/
SELECT MIN(AverageSalaryByDepartment) AS MinAverageSalary FROM
	(SELECT AVG(Salary) AS AverageSalaryByDepartment FROM Employees
	GROUP BY DepartmentID) AS AvgSalaries

/*--12--*/
USE Geography
GO

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM Countries AS c
JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode AND c.CountryCode = 'BG'
JOIN Mountains AS m
ON m.Id = mc.MountainId
JOIN Peaks AS p
ON p.MountainId = mc.MountainId AND p.Elevation > 2835
ORDER BY p.Elevation DESC

/*--13--*/
SELECT c.CountryCode, COUNT(mc.MountainId) AS MountainRanges FROM Countries AS c
JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode AND c.CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY c.CountryCode

/*--14--*/
SELECT TOP 5 c.CountryName, r.RiverName FROM Rivers AS r
JOIN CountriesRivers AS rc
ON r.Id = rc.RiverId
RIGHT OUTER JOIN Countries AS c
ON c.CountryCode = rc.CountryCode
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

/*--15--*/
WITH CTE_ContinentMax (ContinentCode, CurrencyUsage) AS
(
	SELECT ContinentCode, MAX(c) AS CurrencyUsage FROM
	(SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS c FROM Countries
	GROUP BY ContinentCode, CurrencyCode) AS k
	GROUP BY ContinentCode
),

CTE_AllCurrCont (ContinentCode, CurrencyCode, CurrencyUsage) AS
(
	SELECT * FROM
	(SELECT ContinentCode, CurrencyCode, MAX(c) AS CurrencyUsage FROM
		(SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS c FROM Countries
		GROUP BY ContinentCode, CurrencyCode) AS t
	GROUP BY ContinentCode, CurrencyCode) AS m
)

SELECT acc.ContinentCode, acc.CurrencyCode, acc.CurrencyUsage FROM CTE_AllCurrCont AS acc
JOIN CTE_ContinentMax AS cm
ON cm.ContinentCode = acc.ContinentCode AND cm.CurrencyUsage = acc.CurrencyUsage
WHERE acc.CurrencyUsage > 1
ORDER BY acc.ContinentCode

/*--16--*/
WITH CTE_AllCountries AS
(
	SELECT COUNT(*) AS a FROM Countries
),

CTE_CountriesWithMountains AS 
(
	SELECT COUNT(DISTINCT CountryCode) AS b FROM MountainsCountries
)

SELECT a - b AS CountryCode FROM CTE_AllCountries
JOIN CTE_CountriesWithMountains
ON a IS NOT NULL

/*--17--*/
WITH CTE_CountryHighestPeak AS
(
	SELECT c.CountryName, MAX(p.Elevation) AS HighestPeakElevation FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	LEFT JOIN Peaks AS p
	ON p.MountainId = mc.MountainId
	GROUP BY c.CountryName
),

CTE_CountryLongestRiver AS
(
	SELECT c.CountryName, MAX(r.Length) AS LongestRiverLength FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr
	ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r
	ON r.Id = cr.RiverId
	GROUP BY c.CountryName
)

SELECT TOP(5) hp.CountryName, hp.HighestPeakElevation, lr.LongestRiverLength FROM CTE_CountryHighestPeak AS hp
JOIN CTE_CountryLongestRiver AS lr
ON lr.CountryName = hp.CountryName
ORDER BY hp.HighestPeakElevation DESC, lr.LongestRiverLength DESC

/*--18--*/
WITH CTE_CountriesHighestElevation AS
(
	SELECT c.CountryName,
		CASE 
			WHEN MAX(p.Elevation) IS NULL THEN 0
			ELSE MAX(p.Elevation)
		END AS [Highest Peak Elevation] FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	LEFT JOIN Peaks As p
	ON p.MountainId = mc.MountainId
	GROUP BY c.CountryName
),

CTE_MountainHighestElevation AS
(
	SELECT m.Id, MAX(p.Elevation) AS mhe FROM Mountains AS m
	JOIN Peaks AS p
	ON p.MountainId = m.Id
	GROUP BY m.Id
)

SELECT TOP 5
	he.CountryName AS Country,
	CASE
		WHEN p.PeakName IS NULL THEN '(no highest peak)'
		ELSE p.PeakName
	END AS [Highest Peak Name],

	he.[Highest Peak Elevation],
	CASE
		WHEN m.MountainRange IS NULL THEN '(no mountain)'
		ELSE m.MountainRange
	END AS Mountain

FROM CTE_CountriesHighestElevation As he
JOIN Countries AS c
ON c.CountryName = he.CountryName
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
LEFT JOIN CTE_MountainHighestElevation AS mh
ON mh.Id = mc.MountainId AND mh.mhe = [Highest Peak Elevation]
LEFT JOIN Peaks AS p
ON p.Elevation = mh.mhe
LEFT JOIN Mountains AS m
ON mc.MountainId = m.Id
WHERE he.[Highest Peak Elevation] = p.Elevation OR he.[Highest Peak Elevation] = 0
ORDER BY he.CountryName
