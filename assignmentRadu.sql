--- 1. Retrieve the content of the Person.CountryRegion table and display it in reverse alphabetical order based on the name!
-- Columns to display: CountryRegionCode, Name
select Person.CountryRegion.CountryRegionCode, Person.CountryRegion.Name from Person.CountryRegion order by Name DESC; 

--- 2. Query the content of the HumanResources.Department table, and order it in alphabetical order based on the name (Name column)!
--- Columns to display: Name, GroupName
select HumanResources.Department.Name, HumanResources.Department.GroupName from HumanResources.Department order by Name;

--- 3. Display the rows from the Sales.CurrencyRate table where the second letter of the target currency (ToCurrencyCode column) is 'R' 
--- and the value of the average rate (AverageRate column) is greater than 2!
-- Columns to display: CurrencyRateDate, FromCurrencyCode, ToCurrencyCode, AverageRate
select Sales.CurrencyRate.CurrencyRateDate, Sales.CurrencyRate.FromCurrencyCode, Sales.CurrencyRate.ToCurrencyCode, Sales.CurrencyRate.AverageRate 
	from Sales.CurrencyRate
	where Sales.CurrencyRate.ToCurrencyCode LIKE '__R' AND Sales.CurrencyRate.AverageRate > 2;

--- 4. Display the products that have at least 300 units in stock (Quantity column of Production.ProductInventory), 
--- which haven't been modified this year (according to the ModifiedDate column of the Production.Product table)!
--- Columns to display: Production.Product.Name, Production.ProductInventory.Quantity
select
	Production.Product.Name,
	Production.ProductInventory.Quantity
from Production.Product
join Production.ProductInventory on Production.ProductInventory.ProductID = Production.Product.ProductID
where Production.ProductInventory.Quantity >= 300;


--- 5. Find the smallest salary (based on the Rate column of the HumanResources.EmployeePayHistory table)!
--- Columns to display: MinPayFromHistory
select MIN(HumanResources.EmployeePayHistory.Rate) AS MinPayFromHistory from HumanResources.EmployeePayHistory;

--- 6. Retrieve those persons (from the Person.Person table) whose email address doesn't contain the character '0' 
--- (based on the EmailAddress column of the Person.EmailAddress table), and their passwords were modified after 2010 
--- (based on the ModifiedDate column of the Person.Password table), ordered in ascending order by their first, middle, and last names (FirstName, MiddleName, and LastName columns)! 
--- Hint: (The individuals' IDs are stored in the BusinessEntityID field in the database.)
--- Columns to display:  Person.Person.FirstName, Person.Person.MiddleName, Person.Person.LastName, Person.EmailAddress.EmailAddress
select
	Person.Person.FirstName,
	Person.Person.MiddleName,
	Person.Person.LastName,
	Person.EmailAddress.EmailAddress
from Person.Person
join Person.EmailAddress on Person.Person.BusinessEntityID = Person.EmailAddress.BusinessEntityID
join Person.Password on Person.Password.BusinessEntityID = Person.Person.BusinessEntityID
where
	Person.EmailAddress.EmailAddress NOT LIKE '%0%'
	AND
	YEAR(Person.Password.ModifiedDate) > 2010
order by
	Person.Person.FirstName, Person.Person.MiddleName, Person.Person.LastName
;

--- 7.Find those persons who possess credit cards of type 'SuperiorCard' or 'Distinguish', but do not possess a 'Vista' card 
--- (based on the CardType column of the Sales.CreditCard table)! 
--- Hint: (For this query, we also need the Sales.PersonCreditCard table.)
--- Columns to display: Person.Person.FirstName, Person.Person.LastName
select
	Person.Person.FirstName,
	Person.Person.LastName
from Person.Person
join Sales.PersonCreditCard on Sales.PersonCreditCard.BusinessEntityID = Person.Person.BusinessEntityID
join Sales.CreditCard on Sales.PersonCreditCard.CreditCardID = Sales.CreditCard.CreditCardID
where 
	Sales.CreditCard.CardType = 'SuperiorCard' OR Sales.CreditCard.CardType = 'Distinguish'
	AND NOT Sales.CreditCard.CardType = 'Vista'
group by
	Person.Person.FirstName, Person.Person.LastName
;

--- ? 8. Get those products whose standard cost (based on the Production.Product.StandardCost field) is greater than 40 
--- and have not appeared in any special offers (based on Sales.SpecialOfferProduct)!
--- Each product should appear only once in the list.
--- Columns to display:  Production.Product.Name, Production.Product.StandardCost
select
	DISTINCT(Production.Product.Name),
	Production.Product.StandardCost
from Production.Product
left join Sales.SpecialOfferProduct on Production.Product.ProductID = Sales.SpecialOfferProduct.ProductID
where 
	Sales.SpecialOfferProduct.ProductID IS NULL
	AND
	Production.Product.StandardCost > 40
;

--- 9. Retrieve those credit cards (from the Sales.CreditCard table) whose type is 'SuperiorCard' 
--- (based on the CardType column of the Sales.CreditCard table) and have not been used in any order (based on the Sales.SalesOrderHeader table)!
--- Columns to display: Sales.CreditCard.CreditCardID, Sales.CreditCard.CardNumber
select
	Sales.CreditCard.CreditCardID,
	Sales.CreditCard.CardNumber
from Sales.CreditCard
left join Sales.SalesOrderHeader on Sales.SalesOrderHeader.CreditCardID = Sales.CreditCard.CreditCardID
where
	Sales.CreditCard.CardType = 'SuperiorCard'
	AND
	Sales.SalesOrderHeader.CreditCardID IS NULL;

--- 10. For each customer, provide the number of their orders and the date of their latest order, ordered in descending order by the number of orders! 
--- Hint: The query requires the Person.Person, Sales.Customer, and Sales.SalesOrderHeader tables.
--- Columns to display: Person.Person.FirstName, Person.Person.LastName
select
	Person.Person.FirstName,
	Person.Person.LastName,
	COUNT(Sales.SalesOrderHeader.CustomerID) AS TotalOrders,
	(select MAX(Sales.SalesOrderHeader.OrderDate) from Sales.SalesOrderHeader where Sales.SalesOrderHeader.CustomerID = Sales.Customer.CustomerID) AS LastOrder 
from Person.Person
join Sales.Customer on Sales.Customer.PersonID = Person.Person.BusinessEntityID
join Sales.SalesOrderHeader on Sales.SalesOrderHeader.CustomerID = Sales.Customer.CustomerID
group by Person.Person.FirstName, Person.Person.LastName, Sales.Customer.CustomerID
order by TotalOrders desc;