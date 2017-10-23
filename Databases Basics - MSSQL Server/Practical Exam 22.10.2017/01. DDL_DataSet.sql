USE ReportService
GO

-- Disable referential integrity
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
GO

EXEC sp_MSForEachTable 'DELETE FROM ?'
GO

EXEC sp_MSForEachTable 'DBCC CHECKIDENT(''?'', RESEED, 0)'
GO

-- Enable referential integrity 
EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'
GO

--INSERT Departments
SET IDENTITY_INSERT Departments ON;

INSERT INTO Departments(Id, Name)
VALUES(1, 'Infrastructure'), (2, 'Aged Care'), (3, 'Legal'), (4, 'Emergency'), (5, 'Roads Maintenance'), (6, 'Animals Care'), (7, 'Forestry Office'), (8, 'Property Management'), (9, 'Event Management'), (10, 'Environment');

SET IDENTITY_INSERT Departments OFF;


--INSERT Categories
SET IDENTITY_INSERT Categories ON;

INSERT INTO Categories(Id,
                       Name,
                       Departmentid)
VALUES(1, 'Snow Removal', 5), (2, 'Recycling', 10), (3, 'Water/Air Pollution', 10), (4, 'Streetlight', 1), (5, 'Illegal Construction', 8), (6, 'Sports Events', 9), (7, 'Homeless Elders', 2), (8, 'Disabled People', 2), (9, 'Art Events', 9), (10, 'Animal in Danger', 6), (11, 'Destroyed Home', 4), (12, 'Street animal', 6), (13, 'Music Events', 9), (14, 'Dangerous Building', 8), (15, 'Traffic Lights', 5), (16, 'Potholes', 5), (17, 'Green Areas', 7), (18, 'Dangerous Trees', 7);

SET IDENTITY_INSERT Categories OFF;

--INSERT Status
SET IDENTITY_INSERT [Status] ON;

INSERT INTO Status(Id,
                   Label)
VALUES(1, 'waiting'), (2, 'in progress'), (3, 'completed'), (4, 'blocked');

SET IDENTITY_INSERT [Status] OFF;

--INSERT Employees
SET IDENTITY_INSERT Employees ON;

INSERT INTO Employees(Id,
                      Firstname,
                      Lastname,
                      Gender,
                      Birthdate,
                      DepartmentId)
VALUES(1, 'Marlo', 'O''Malley', 'M', '9/21/1958', 1), (2, 'Nolan', 'Meneyer', 'M', '4/29/1961', 6), (3, 'Tarah', 'McWaters', 'F', '5/22/1954', 9), (4, 'Bernetta', 'Bigley', 'F', '10/18/1979', 2), (5, 'Gregory', 'Stithe', 'M', '6/25/1952', 5), (6, 'Bord', 'Hambleton', 'M', NULL, 8), (7, 'Humphrey', 'Tamblyn', 'M', '3/26/1941', 6), (8, 'Dinah', 'Zini', 'F', '9/8/1950', 10), (9, 'Eustace', 'Sharpling', 'M', '10/29/1956', 1), (10, 'Shannon', 'Partridge', 'M', '2/14/1952', 1), (11, 'Nancey', 'Heintsch', 'F', '8/20/1967', 3), (12, 'Niki', 'Stranaghan', 'M', '11/26/1969', 9), (13, 'Dick', 'Wentworth', 'M', '4/29/1983', 4), (14, 'Ives', 'McNeigh', 'M', '11/15/1952', 1), (15, 'Leonardo', 'Shopcott', 'M', '1/15/1939', 6), (16, 'Howard', 'Lovelady', 'M', '6/6/1969', 5), (17, 'Bron', 'Ledur', 'M', '11/26/1996', 10), (18, 'Adelind', 'Benns', 'F', '11/23/1935', 10), (19, 'Imogen', 'Burnup', 'F', '5/8/1952', 3), (20, 'Eldon', 'Gaze', 'M', '8/24/1947', 5), (21, 'Patsy', 'McLenahan', 'F', NULL, 10), (22, 'Jeane', 'Salisbury', 'F', '9/13/1967', 5), (23, 'Tiena', 'Ritchard', 'F', '4/18/1985', 3), (24, 'Hakim', 'Guilaem', 'M', '4/9/1963', 9), (25, 'Corny', 'Pickthall', 'M', '12/18/1979', 2), (26, 'Tam', 'Kornel', 'M', '10/3/1995', 9), (27, 'Abby', 'Brettoner', 'F', '4/16/1992', 9), (28, 'Galven', 'Moston', 'M', '3/20/1945', 5), (29, 'Stefa', 'Jakubovski', 'F', '1/10/1947', 2), (30, 'Hewet', 'Juschke', 'M', '12/26/1997', 7);

SET IDENTITY_INSERT Employees OFF;

--INSERT Users
SET IDENTITY_INSERT Users ON;

INSERT INTO Users(Id,
                  Username,
                  Name,
			   Password,
                  Gender,
                  BirthDate,
		        Age,
                  Email)
VALUES
(1, 'ealpine0', 'Erhart Alpine', 'b8eYD1a7R44', 'F', '07/07/1949', 68, 'ealpine0@squarespace.com'),
(2, 'awight1', 'Anitra Wight', 'hbHhuwBSxqeo', 'F', '05/31/1943', 74, 'awight1@artisteer.com'),
(3, 'fmacane2', 'Faustine MacAne', 'nhpbS3h2rfR', 'M', '11/19/1944', 73, 'fmacane2@is.gd'),
(4, 'fdenrico3', 'Florette D''Enrico', '0iMw1JpVk4', 'F', '10/26/1977', 40, 'fdenrico3@va.gov'),
(5, 'lrow4', 'Lindsey Row', 'neGBinke', 'F', '01/16/1934', 83, 'lrow4@netscape.com'),
(6, 'dfinicj5', 'NULL', '2GDReU', 'F', '05/20/1993', 24, 'shynson5@ihg.com'),
(7, 'llankham6', 'Lishe Lankham', 'ygNzd2f', 'F', '11/05/1951', 66, 'llankham6@histats.com'),
(8, 'tmartensen7', 'Tawnya Martensen', 'KyFw9oA', 'M', '11/21/1980', 37, 'tmartensen7@cornell.edu'),
(9, 'mgobbett8', 'Maud Gobbett', 'anv5ba2pvM', 'F', '10/29/1958', 59, 'mgobbett8@dmoz.org'),
(10, 'vinglese9', 'Veronique Inglese', 'ZCJp511W', 'M', '02/16/1962', 55, 'vinglese9@g.co'),
(11, 'mburdikina', 'Maggi Burdikin', 'MjXufd', 'F', '04/23/1986', 31, 'mburdikina@boston.com'),
(12, 'varkwrightb', 'Vanni Arkwright', 'sWKjjlWE', 'M', '02/29/1964', 53, '6varkwrightb@ucoz.com'),
(13, '5omarkwelleyc', 'Odette Markwelley', 'UfUE4pE', 'F', '05/23/1998', 19, 'omarkwelleyc@alibaba.com'),
(14, 'dpennid', 'Dorene Penni', 'rIBnJ77b', 'F', '09/07/1959', 58, 'dpennid@arizona.edu'),
(15, 'wkicke', 'Wileen Kick', '7bZQ3gntC', 'M', '09/20/1962', 55, 'wkicke@disqus.com'),
(16, '1qiskowf', 'Quent Iskow', 'DCDiR6YTf8', 'F', '12/18/1958', 59, 'qiskowf@opensource.org'),
(17, 'bkaasg', 'Brig Kaas', 'D1oonIJDX3G', 'M', '07/13/1996', 21, 'bkaasg@g.co'),
(18, 'gdiaperh', 'Germaine Diaper', 'YM05Ya6Xpo7', 'F', '05/26/1939', 78, 'gdiaperh@nsw.gov.au'),
(19, '1eallibertoni', 'Emlynn Alliberton', 's8XQ0d7iv', 'F', '07/29/1972', 45, 'eallibertoni@slashdot.org'),
(20, 'jgreggorj', 'Jocko Greggor', 'H1J1AbJW4BEB', 'M', '04/22/1981', 36, 'jgreggorj@whitehouse.gov');

SET IDENTITY_INSERT Users OFF;

--INSERT Reports
SET IDENTITY_INSERT Reports ON;

INSERT INTO Reports(Id,
                    CategoryId,
                    StatusId,
                    OpenDate,
                    CloseDate,
                    Description,
                    UserId,
                    EmployeeId)
VALUES
(1, 1, 4, '04/13/2017', NULL, 'Stuck Road on Str.14', 14, 5),
(2, 2, 3, '09/05/2015', '09/17/2015', '366 kg plastic for recycling.', 10, NULL),
(3, 1, 2, '01/03/2015', NULL, 'Stuck Road on Str.29', 4, 22),
(4, 11, 4, '12/06/2015', NULL, 'Burned facade on Str.183', 7, NULL),
(5, 4, 4, '11/17/2015', NULL, 'Fallen streetlight columns on Str.40', 3, NULL),
(6, 18, 1, '09/07/2015', NULL, 'Fallen Tree on the road on Str.26', 14, 30),
(7, 2, 2, '09/07/2017', NULL, 'High grass in Park Riversqaure', 10, 8),
(8, 18, 3, '04/23/2016', '05/01/2016', 'Fallen Tree on the road on Str.26', 11, NULL),
(9, 10, 4, '12/17/2014', NULL, 'Stuck Road on Str.65', 1, 15),
(10, 2, 4, '08/23/2015', NULL, '399 kg plastic for recycling.', 12, 17),
(11, 4, 3, '07/03/2017', '07/06/2017', 'Fallen streetlight columns on Str.41', 19, 14),
(12, 10, 3, '07/20/2016', '08/13/2016', 'Burned facade on Str.793', 7, 7),
(13, 1, 2, '01/26/2016', NULL, '246 kg plastic for recycling.', 16, 20),
(14, 12, 1, '06/09/2016', NULL, 'Aggressive monkey corner of Str.36 and Str.92', 20, NULL),
(15, 1, 4, '06/20/2015', NULL, 'Stuck Road on Str.133', 17, NULL),
(16, 6, 1, '10/09/2015', NULL, 'Stuck Road on Str.66', 18, 24),
(17, 11, 4, '08/26/2015', NULL, 'Burned facade on Str.560', 14, NULL),
(18, 6, 4, '10/24/2014', NULL, '86 kg plastic for recycling.', 10, 24),
(19, 11, 4, '01/14/2016', NULL, '39 kg plastic for recycling.', 6, 13),
(20, 16, 1, '07/02/2016', NULL, 'Gigantic crater ?n Str.48', 3, NULL),
(21, 2, 4, '03/31/2015', NULL, 'High grass in Park Riversqaure', 14, 17),
(22, 14, 1, '05/15/2016', NULL, 'Falling bricks on Str.17', 14, NULL),
(23, 2, 3, '07/24/2017', '07/27/2017', 'Stuck Road on Str.8', 16, 18),
(24, 1, 3, '05/23/2015', '05/19/2016', 'Stuck Road on Str.123', 13, 16),
(25, 17, 1, '01/11/2016', NULL, '162 kg plastic for recycling.', 19, 30),
(26, 10, 2, '11/10/2016', '11/20/2016', 'Parked car on green area on the sidewalk of Str.74', 20, 15),
(27, 9, 2, '12/17/2014', NULL, 'Art exhibition on July 24', 8, NULL),
(28, 2, 4, '07/12/2017', NULL, 'Stuck Road on Str.13', 2, 18),
(29, 14, 3, '09/25/2015', '10/12/2016', 'Falling bricks on Str.38', 12, 13),
(30, 3, 4, '08/02/2016', NULL, 'Extreme increase in nitrogen dioxide at Litchfield', 4, NULL),
(31, 4, 4, '09/12/2017', NULL, 'Fallen streetlight columns on Str.14', 1, 1),
(32, 6, 3, '06/08/2015', '06/13/2015', 'Sky Run competition on September 8', 19, 12),
(33, 16, 2, '11/17/2015', NULL, 'Gigantic crater ?n Str.19', 1, NULL),
(34, 2, 4, '07/10/2017', NULL, 'Glass Bottles for recycling on Str.105', 5, NULL),
(35, 2, 1, '02/06/2017', NULL, 'Glass Bottles for recycling on Str.28', 5, NULL),
(36, 4, 2, '01/01/2016', NULL, 'Fallen streetlight columns on Str.15', 18, NULL),
(37, 5, 1, '08/28/2017', NULL, 'Glass Bottles for recycling on Str.150', 13, 17),
(38, 7, 2, '02/27/2016', NULL, 'Lonely child on corner of Str.3 and Str.30', 16, NULL),
(39, 9, 1, '02/11/2016', NULL, 'Glass Bottles for recycling on Str.116', 10, NULL),
(40, 7, 1, '11/05/2015', NULL, 'Lonely child on corner of Str.1 and Str.19', 7, 25);

SET IDENTITY_INSERT Reports OFF;