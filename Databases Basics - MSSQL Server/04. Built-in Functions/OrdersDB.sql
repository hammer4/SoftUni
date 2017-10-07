CREATE DATABASE Orders;
GO

USE Orders;
GO
CREATE TABLE Orders
(
Id INT NOT NULL,
ProductName VARCHAR(50) NOT NULL,
OrderDate DATETIME NOT NULL
CONSTRAINT PK_Orders PRIMARY KEY (Id)
)

INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (1, 'Butter', '20160919');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (2, 'Milk', '20160930');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (3, 'Cheese', '20160904');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (4, 'Bread', '20151220');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (5, 'Tomatoes', '20150101');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (6, 'Tomatoe2', '20150201');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (7, 'Tomatoess', '20150401');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (8, 'Tomatoe3', '20150128');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (9, 'Tomatoe4', '20150628');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (10, 'Tomatoe44s', '20150630');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (11, 'Tomatoefggs', '20150228');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (12, 'Tomatoesytu', '20160228');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (13, 'Toyymatddoehys', '20151231');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (14, 'Tom443atoes', '20151215');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (15, 'Tomat65434foe23gfhgsPep', '20151004');