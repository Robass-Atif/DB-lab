SELECT ProductName FROM Products WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products);

select ShippedDate,COUNT(*) as NumberOfOrders from Orders where ShippedDate is not null group by ShippedDate;


select Country from Suppliers group by Country having count(*)>=2;

select Month(ShippedDate) as [Month Number],COUNT(*) As [Order Delayed] from Orders  where ShippedDate is not null and ShippedDate>RequiredDate group by MONTH(ShippedDate) ;

SELECT OrderID, SUM(Discount) AS TotalDiscount FROM [Order Details] GROUP BY OrderID HAVING SUM(Discount) > 0;

SELECT ShipCity, COUNT(*) AS NumberOfOrders FROM [Orders] WHERE ShipCountry = 'USA' AND YEAR(ShippedDate) = 1997 GROUP BY ShipCity;

 SELECT ShipCountry AS Country, COUNT(*) AS [Orders Delayes] FROM [Orders] WHERE ShippedDate > RequiredDate GROUP BY ShipCountry;


 SELECT OrderID, SUM(Discount)AS Discount,SUM(UnitPrice) As [Total Price]  FROM [Order Details] GROUP BY OrderID HAVING SUM(Discount) > 0;

SELECT ShipRegion, ShipCity, COUNT(*) AS NumberOfOrders FROM Orders WHERE YEAR(OrderDate) = '1997' GROUP BY ShipRegion, ShipCity ;
