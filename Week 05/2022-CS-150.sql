--select  Customers.CustomerID, OrderID,OrderDate from Orders right join Customers on Customers.CustomerID=Orders.CustomerID;
















--select Customers.CustomerID from Orders right join  Customers on   Customers.CustomerID=Orders.CustomerID where OrderID is null;









--select  Customers.CustomerID, OrderID,OrderDate from Orders left join Customers on Customers.CustomerID=Orders.CustomerID where YEAR([OrderDate])='1997' and MONTH(OrderDate)=07 ;







--select CustomerID,Count(*) as [Total Orders]  from Orders group by CustomerID;










--It is not possible

--It is not possible









--select Customers.CustomerID,COUNT(Orders.CustomerID) as TotalOrders,Sum([Order Details].Quantity) as TotalQuantity  from Customers join Orders on Orders.CustomerID=Customers.CustomerID join [Order Details] on Orders.OrderID=[Order Details].OrderID where Customers.Country='USA' group by Customers.CustomerID;


















--SELECT Customers.CustomerID,Customers.CompanyName,Orders.OrderID,Orders.OrderDate FROM  Customers LEFT JOIN  Orders ON Customers.CustomerID = Orders.CustomerID WHERE CONVERT(DATE, Orders.OrderDate) = '1997-07-04' and Orders.OrderDate IS not NULL;







--Yes









--SELECT  CONCAT(E.FirstName, ' ', E.LastName) AS EmployeeName,DATEDIFF(YEAR, E.BirthDate, GETDATE()) AS EmployeeAge, CONCAT(M.FirstName, ' ', M.LastName) AS ManagerName,DATEDIFF(YEAR, M.BirthDate, GETDATE()) AS ManagerAge FROM Employees AS E JOIN Employees AS M ON E.ReportsTo = M.EmployeeID WHERE E.BirthDate < M.BirthDate ORDER BY E.FirstName, E.LastName;














--SELECT Products.ProductName,Orders.OrderDate FROM  Orders JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID JOIN Products ON [Order Details].ProductID = Products.ProductID WHERE CONVERT(DATE, Orders.OrderDate) = '1997-08-08';






--select Orders.ShipAddress,Orders.ShipCity,Orders.ShipCountry from Orders join Employees on Orders.EmployeeID=Employees.EmployeeID join Customers on Customers.CustomerID=Orders.CustomerID where Employees.FirstName='Anne' and Orders.RequiredDate<Orders.ShippedDate;
















SELECT  ShipCountry FROM Orders JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID JOIN  Products ON [Order Details].ProductID = Products.ProductID WHERE Products.ProductName = 'Beverages' AND Orders.ShippedDate IS NOT NULL;