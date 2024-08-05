use AdventureWorks2022;

--1
SELECT CountryRegionCode, Name
FROM Person.CountryRegion
ORDER BY Name desc


--2
SELECT Name, GroupName
FROM HumanResources.Department
ORDER BY Name


--3
SELECT CurrencyRateDate, FromCurrencyCode, ToCurrencyCode, AverageRate
FROM Sales.CurrencyRate
WHERE ToCurrencyCode LIKE '_r%' AND AverageRate > 2


--4
SELECT Production.Product.Name, Production.ProductInventory.Quantity
FROM Production.ProductInventory, Production.Product 
WHERE Production.ProductInventory.Quantity > 299 AND Production.Product.ModifiedDate < '2024-01-01'

--5
SELECT MIN(EmployeePayHistory.Rate) AS 'MinPayFromHistory'
FROM HumanResources.EmployeePayHistory

--6
SELECT p.FirstName, p.MiddleName, p.LastName, e.EmailAddress
FROM Person.Person p
JOIN Person.EmailAddress e ON p.BusinessEntityID = e.BusinessEntityID
JOIN Person.Password pw ON p.BusinessEntityID = pw.BusinessEntityID
WHERE e.EmailAddress NOT LIKE '%0%' AND pw.ModifiedDate > '2010-01-01'
ORDER BY p.FirstName, p.MiddleName, p.LastName


--7
SELECT p.FirstName, p.LastName
FROM Person.Person p
JOIN Sales.PersonCreditCard pcc on p.BusinessEntityID = pcc.BusinessEntityID
JOIN Sales.CreditCard cc on pcc.CreditCardID = cc.CreditCardID
WHERE pcc.CreditCardID IN 
(SELECT pcc2.CreditCardID
FROM Sales.CreditCard pcc2
WHERE pcc2.CardType = 'SuperiorCard' OR pcc2.CardType = 'Distinguish')
AND pcc.CreditCardID NOT IN 
(SELECT pcc2.CreditCardID
FROM Sales.CreditCard pcc2
WHERE pcc2.CardType = 'Vista')

--8
SELECT DISTINCT p.Name, p.StandardCost
FROM Production.Product p
WHERE p.StandardCost > 40 AND p.ProductID NOT IN 
(SELECT p2.ProductID
FROM Production.Product p2
JOIN Sales.SpecialOfferProduct sop on sop.ProductID = p2.ProductID)

--9
SELECT cc.CreditCardID, cc.CardNumber
FROM Sales.CreditCard cc
WHERE cc.CardType = 'SuperiorCard'
AND cc.CreditCardID NOT IN
(SELECT cc2.CreditCardID
FROM Sales.CreditCard cc2
JOIN Sales.SalesOrderHeader soh on cc2.CreditCardID = soh.CreditCardID)

--10 
SELECT p.FirstName, p.LastName, COUNT(soh.SalesOrderID) AS 'NumberOfOrders', soh.ShipDate as 'DateOfLastOrder'
FROM Person.Person p 
JOIN Sales.Customer c ON p.BusinessEntityID = c.PersonID
JOIN Sales.SalesOrderHeader soh ON c.CustomerID = soh.CustomerID

WHERE soh.ShipDate = 
(SELECT MAX(soh2.ShipDate)
FROM SALES.SalesOrderHeader soh2
WHERE soh.CustomerID = soh2.CustomerID)

GROUP BY p.FirstName, p.LastName, soh.ShipDate
ORDER BY COUNT(soh.SalesORDERID) DESC

