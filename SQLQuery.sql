use AdventureWorks2022;

--EX1 
SELECT cr.CountryRegionCode, cr.Name
FROM Person.CountryRegion cr
ORDER BY cr.Name DESC;


--EX2
SELECT hrd.Name, hrd.GroupName
FROM HumanResources.Department hrd
ORDER BY hrd.Name;

--EX3
SELECT cr.CurrencyRateDate, cr.FromCurrencyCode, cr.ToCurrencyCode, cr.AverageRate
FROM Sales.CurrencyRate cr
WHERE SUBSTRING(ToCurrencyCode,2,1) = 'R' 
AND AverageRate >2;

--EX4
SELECT pi.Quantity, p.Name
FROM Production.Product p
JOIN Production.ProductInventory pi ON p.ProductID = pi.ProductID
WHERE YEAR(p.ModifiedDate) < YEAR(GETDATE()) 
AND pi.Quantity >= 300;

--EX5
SELECT MIN(Rate) AS MinPayFromHistory
FROM HumanResources.EmployeePayHistory;

--EX6
SELECT p.FirstName, p.MiddleName,p.LastName, pea.EmailAddress
FROM Person.Person p
JOIN Person.EmailAddress pea ON p.BusinessEntityID = pea.BusinessEntityID
JOIN Person.Password psw ON psw.BusinessEntityID = pea.BusinessEntityID
WHERE pea.EmailAddress NOT LIKE '%0%' 
AND psw.ModifiedDate > '2010-01-01'
ORDER BY p.FirstName, p.MiddleName, p.LastName;

--EX7
SELECT p.FirstName, p.LastName
FROM Person.Person p
JOIN Sales.PersonCreditCard pcc ON p.BusinessEntityID = pcc.BusinessEntityID
JOIN Sales.CreditCard cc ON pcc.CreditCardID = cc.CreditCardID
WHERE cc.CardType IN ('SuperiorCard', 'Distinguish') 
AND cc.CardType != ('VISTA');

--EX8
SELECT p.Name, p.StandardCost
FROM Production.Product p
LEFT JOIN Sales.SpecialOfferProduct sop ON p.ProductID = sop.ProductID
WHERE p.StandardCost > 40 
AND sop.SpecialOfferID IS NULL;

--EX9
SELECT cc.CreditCardID, cc.CardNumber
FROM Sales.CreditCard cc
LEFT JOIN Sales.SalesOrderHeader soh ON cc.CreditCardID = soh.CreditCardID
WHERE cc.CardType = 'SuperiorCard' 
AND soh.CreditCardID IS NULL;

--EX10
SELECT p.FirstName, p.LastName, 
MAX(soh.OrderDate) AS LatestOrder, COUNT(soh.SalesOrderID) AS NumberOfOrders
FROM Person.Person p
JOIN Sales.Customer c ON c.PersonID = p.BusinessEntityID
JOIN Sales.SalesOrderHeader soh ON c.CustomerID = soh.CustomerID
GROUP BY p.FirstName, p.LastName
ORDER BY NumberOfOrders DESC;
