---1. Retrieve the content of the Person.CountryRegion table and display it in reverse alphabetical order based on the name!
---Columns to display: CountryRegionCode, Name
SELECT cr.CountryRegionCode, cr.Name
FROM Person.CountryRegion cr
ORDER BY cr.Name DESC;

---2. Query the content of the HumanResources.Department table, and order it in alphabetical order based on the name (Name column)!
---Columns to display: Name, GroupName
SELECT hr.Name, hr.GroupName
FROM HumanResources.Department hr
ORDER BY hr.Name;

---3. Display the rows from the Sales.CurrencyRate table where the second letter of the target currency (ToCurrencyCode column) is 'R' and the value of the average rate (AverageRate column) is greater than 2!
---Columns to display: CurrencyRateDate, FromCurrencyCode, ToCurrencyCode, AverageRate
SELECT cr.CurrencyRateDate, cr.FromCurrencyCode, cr.ToCurrencyCode, cr.AverageRate
FROM Sales.CurrencyRate cr
WHERE cr.ToCurrencyCode LIKE '_R%' AND cr.AverageRate > 2;

---4. Display the products that have at least 300 units in stock (Quantity column of Production.ProductInventory), which haven't been modified this year (according to the ModifiedDate column of the Production.Product table)!
---Columns to display: Production.Product.Name, Production.ProductInventory.Quantity
SELECT p.Name, pi.Quantity
FROM Production.Product p, Production.ProductInventory pi
WHERE pi.Quantity >= 300 AND pi.ModifiedDate <= DATEADD(year,-1, GETDATE());

---5. Find the smallest salary (based on the Rate column of the HumanResources.EmployeePayHistory table)!
---Columns to display: MinPayFromHistory
SELECT MIN(ph.Rate) AS MinPayFromHistory
FROM HumanResources.EmployeePayHistory ph;

---6. Retrieve those persons (from the Person.Person table) whose email address doesn't contain the character '0' (based on the EmailAddress column of the Person.EmailAddress table), and their passwords were modified after 2010 (based on the ModifiedDate column of the Person.Password table), ordered in ascending order by their first, middle, and last names (FirstName, MiddleName, and LastName columns)! 
---Hint: (The individuals' IDs are stored in the BusinessEntityID field in the database.)
---Columns to display:  Person.Person.FirstName, Person.Person.MiddleName, Person.Person.LastName, Person.EmailAddress.EmailAddress
SELECT p.FirstName, p.MiddleName, p.LastName, e.EmailAddress  
FROM Person.Person p, Person.EmailAddress e, Person.Password 
WHERE e.EmailAddress NOT LIKE '%0%' AND Person.Password.ModifiedDate > '2010-12-31'
ORDER BY p.FirstName, p.MiddleName, p.LastName;

---7.Find those persons who possess credit cards of type 'SuperiorCard' or 'Distinguish', but do not possess a 'Vista' card (based on the CardType column of the Sales.CreditCard table)! 
---Hint: (For this query, we also need the Sales.PersonCreditCard table.)
---Columns to display: Person.Person.FirstName, Person.Person.LastName
SELECT p.FirstName, p.LastName
FROM Person.Person p, Sales.PersonCreditCard pc
JOIN Sales.CreditCard c ON pc.CreditCardID = c.CreditCardID
WHERE c.CardType IN ('SuperiorCard', 'Distinguish');


---8. Get those products whose standard cost (based on the Production.Product.StandardCost field) is greater than 40 and have not appeared in any special offers (based on Sales.SpecialOfferProduct)! Each product should appear only once in the list.
SELECT p.Name, p.StandardCost
FROM Production.Product p
LEFT JOIN Sales.SpecialOfferProduct sop ON p.ProductID = sop.ProductID
WHERE p.StandardCost > 40 AND sop.ProductID IS NULL;

---9. Retrieve those credit cards (from the Sales.CreditCard table) whose type is 'SuperiorCard' (based on the CardType column of the Sales.CreditCard table) and have not been used in any order (based on the Sales.SalesOrderHeader table)!
---Columns to display: Sales.CreditCard.CreditCardID, Sales.CreditCard.CardNumber
SELECT c.CreditCardID, c.CardNumber
FROM Sales.CreditCard c
LEFT JOIN Sales.SalesOrderHeader s ON c.CreditCardID = s.CreditCardID
WHERE c.CardType IN ('SuperiorCard') AND s.CreditCardID IS NULL;

---10. For each customer, provide the number of their orders and the date of their latest order, ordered in descending order by the number of orders! 
---Hint: The query requires the Person.Person, Sales.Customer, and Sales.SalesOrderHeader tables.
---Columns to display: Person.Person.FirstName, Person.Person.LastName
SELECT p.FirstName, p.LastName,
COUNT(s.SalesOrderID) AS NumberOfOrders,
MAX(s.OrderDate) AS LatestOrderDate
FROM Person.Person p
JOIN Sales.Customer c ON p.BusinessEntityID = c.PersonID 
JOIN Sales.SalesOrderHeader s ON c.CustomerID = s.CustomerID
GROUP BY p.FirstName, p.LastName
ORDER BY NumberOfOrders DESC;


