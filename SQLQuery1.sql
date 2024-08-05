-- 1
SELECT CountryRegionCode, Name FROM Person.CountryRegion

-- 2
SELECT Name, GroupName FROM HumanResources.Department
ORDER BY Name

-- 3
SELECT CurrencyRateDate, FromCurrencyCode, ToCurrencyCode, AverageRate FROM Sales.CurrencyRate
WHERE ToCurrencyCode LIKE '_R%' AND AverageRate > 2

-- 4 
 SELECT Production.Product.Name, Production.ProductInventory.Quantity 
FROM Production.Product
JOIN Production.ProductInventory ON Production.Product.ProductID = Production.ProductInventory.ProductID
WHERE Production.ProductInventory.Quantity >= 300 AND YEAR(Production.Product.ModifiedDate) < YEAR(GETDATE())

-- 5
SELECT MIN(Rate) AS MinPayFromHistory FROM HumanResources.EmployeePayHistory

-- 6
SELECT Person.Person.FirstName, Person.Person.MiddleName, Person.Person.LastName, Person.EmailAddress.EmailAddress
FROM Person.Person
JOIN Person.EmailAddress ON Person.Person.BusinessEntityID = Person.EmailAddress.BusinessEntityID
JOIN Person.Password ON Person.Person.BusinessEntityID = Person.Password.BusinessEntityID
WHERE EmailAddress NOT LIKE '%0%'
AND YEAR(Person.Password.ModifiedDate) > 2010
ORDER BY Person.Person.FirstName, Person.Person.MiddleName, Person.Person.LastName

-- 7
SELECT Person.Person.FirstName, Person.Person.LastName FROM Person.Person
JOIN Sales.PersonCreditCard ON Person.Person.BusinessEntityID = Sales.PersonCreditCard.BusinessEntityID
JOIN Sales.CreditCard ON Sales.PersonCreditCard.CreditCardID = Sales.CreditCard.CreditCardID
WHERE Sales.CreditCard.CardType NOT IN ('Vista') AND (Sales.CreditCard.CardType LIKE 'SuperiorCard' OR Sales.CreditCard.CardType LIKE 'Distinguish')

-- 8
SELECT DISTINCT Production.Product.Name, Production.Product.StandardCost FROM Production.Product
WHERE Production.Product.StandardCost > 40 
AND NOT EXISTS 
(
	SELECT *
	FROM Sales.SpecialOfferProduct
	WHERE Production.Product.ProductID = Sales.SpecialOfferProduct.ProductID
)

-- 9
SELECT Sales.CreditCard.CreditCardID, Sales.CreditCard.CardNumber FROM Sales.CreditCard
WHERE Sales.CreditCard.CardType = 'SuperiorCard'
AND NOT EXISTS
(
	SELECT *
	FROM Sales.SalesOrderHeader
	WHERE Sales.SalesOrderHeader.CreditCardID = Sales.CreditCard.CreditCardID

)

-- 10
SELECT Person.Person.FirstName, Person.Person.LastName, COUNT(Sales.SalesOrderHeader.SalesOrderID) AS NumberOfOrders, MAX(Sales.SalesOrderHeader.OrderDate) AS LatestOrder FROM Person.Person
JOIN Sales.Customer ON Sales.Customer.CustomerID = Person.Person.BusinessEntityID
JOIN Sales.SalesOrderHeader ON Sales.SalesOrderHeader.CustomerID = Sales.Customer.CustomerID
GROUP BY Person.Person.FirstName, Person.Person.LastName
ORDER BY NumberOfOrders DESC
