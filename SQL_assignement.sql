use [AdventureWorks2022]

 --1
select 
	CountryRegionCode, 
	Name 
from 
	Person.CountryRegion 
order by Name desc

--2
Select 
	Name, 
	GroupName 
from 
	HumanResources.Department 
order by Name

--3
Select 
	CurrencyRateDate, 
	FromCurrencyCode, 
	ToCurrencyCode, 
	AverageRate 
from 
	Sales.CurrencyRate where ToCurrencyCode LIKE '_R%' and AverageRate > 2

--4
select 
	Production.Product.Name, 
	Production.ProductInventory.Quantity 
from 
	Production.Product
join 
	Production.ProductInventory on Production.ProductInventory.Quantity > 300 and year(Production.Product.ModifiedDate) <> 2024 


--5
select Min(Rate) as MinPayFromHistory from HumanResources.EmployeePayHistory

--6
select 
	Person.Person.FirstName,
	Person.Person.MiddleName,
	Person.Person.LastName,
	Person.EmailAddress.EmailAddress 
from 
	Person.Person
join 
	Person.EmailAddress on Person.EmailAddress.BusinessEntityID = Person.Person.BusinessEntityID
join 
	Person.Password on Person.Password.BusinessEntityID = Person.Person.BusinessEntityID
where
	Person.EmailAddress.EmailAddress not Like '%0%' and year(Person.Password.ModifiedDate) > 2010
order by 
	Person.Person.FirstName, Person.Person.MiddleName, Person.Person.LastName

--7
select 
    Person.Person.FirstName, 
    Person.Person.LastName
from 
    Person.Person
join 
    Sales.PersonCreditCard ON Person.Person.BusinessEntityID = Sales.PersonCreditCard.BusinessEntityID
join 
    Sales.CreditCard ON Sales.PersonCreditCard.CreditCardID = Sales.CreditCard.CreditCardID
where 
    Sales.CreditCard.CardType IN ('SuperiorCard', 'Distinguish')
    AND Person.Person.BusinessEntityID NOT IN (
        select 
             Sales.PersonCreditCard.BusinessEntityID
        from 
            Sales.PersonCreditCard
        join 
            Sales.CreditCard ON  Sales.PersonCreditCard.CreditCardID = Sales.CreditCard.CreditCardID
        where 
            Sales.CreditCard.CardType = 'Vista'
    );


--8
select distinct 
	Production.Product.Name, 
	Production.Product.StandardCost 
from 
	Production.Product
left join 
	Sales.SpecialOfferProduct 
on 
	Sales.SpecialOfferProduct.ProductID = Production.Product.ProductID 
and 
	Production.Product.StandardCost > 40 and Sales.SpecialOfferProduct.ProductID is not null


--9
select 
    Sales.CreditCard.CreditCardID, 
    Sales.CreditCard.CardNumber
from 
    Sales.CreditCard
left join 
    Sales.SalesOrderHeader on Sales.CreditCard.CreditCardID = Sales.SalesOrderHeader.CreditCardID
where 
    Sales.CreditCard.CardType = 'SuperiorCard' 
    and 
	Sales.SalesOrderHeader.CreditCardID is null;

--10
select 
    Person.Person.FirstName, 
    Person.Person.LastName, 
    count(Sales.SalesOrderHeader.SalesOrderID) as NumberOfOrders, 
    max(Sales.SalesOrderHeader.OrderDate) as LatestOrderDate
from 
    Person.Person
join 
    Sales.Customer on Person.Person.BusinessEntityID = Sales.Customer.PersonID
join 
    Sales.SalesOrderHeader on Sales.Customer.CustomerID = Sales.SalesOrderHeader.CustomerID
group by 
    Person.Person.FirstName, 
    Person.Person.LastName
order by NumberOfOrders desc;
