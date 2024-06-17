
SELECT OrderID, CustomerID FROM Orders WHERE ShippedDate > RequiredDate;




select distinct Country from Employees;




SELECT EmployeeID, LastName, FirstName, ReportsTo FROM Employees WHERE ReportsTo IS NULL;




SELECT DISTINCT ProductName FROM Products WHERE Discontinued = 1;




SELECT OrderID FROM [Order Details] WHERE Discount = 0;




SELECT CompanyName FROM Customers WHERE Region IS NULL ;




SELECT CompanyName FROM Customers WHERE Country = 'UK' OR Country = 'USA';



SELECT CompanyName FROM Suppliers WHERE HomePage IS NOT NULL ;




SELECT DISTINCT ShipCountry FROM Orders  where year(OrderDate)='1997';




SELECT DISTINCT CustomerID FROM Orders WHERE ShippedDate IS NULL;



SELECT SupplierID, CompanyName, City FROM Suppliers;




select Count(distinct Country) from Employees;SELECT DISTINCT FirstName, LastName FROM Employees WHERE City = 'London';




SELECT ProductName FROM Products WHERE Discontinued = 0;




select distinct OrderID from [Order Details] where Discount<=0.1;




SELECT EmployeeID, FirstName, LastName, HomePhone, Extension FROM Employees WHERE Region IS NULL OR Region = '';
