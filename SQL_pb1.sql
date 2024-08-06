use Company

create table Employee(
id int identity(1,1) primary key,
firstName varchar(20),
lastName varchar(20),
salary money)

create table SalaryHistory(
SalaryHistoryId int IDENTITY(1,1) PRIMARY KEY,
idEmployee int,
oldSalary money,
newSalary money,
dateModifyed datetime default current_timestamp,
foreign key (idEmployee) references Employee(id))

create or alter procedure updateSalary (@id int, @salary money)
as
begin
	update Employee set salary = @salary where id = @id
end
go

insert into Employee (firstName, lastName, salary) values 
('John', 'Tate', 3500.00),
('Mary', 'James', 7499.99),
('Dan', 'Hailey', 1999.99),
('Juliana', 'Ford', 3312.49),
('Juan', 'Fernandes', 2200.00),
('Indiana', 'Luke', 1980.00),
('Kevin', 'Thomson', 7500.00),
('Andia', 'Stan', 3500.00),
('Haelena', 'Kudrow', 3700.00)

exec updateSalary @id = 10, @salary = 3200.00

select * from Employee
select * from SalaryHistory


create or alter procedure getEmployeeSalaryById(@id int)
as
begin
	if exists (select salary from Employee where id = @id)
		select salary from Employee where id = @id
	else
		select -1 as ReturnValue
end
go

create or alter procedure getEmployeeHistorySalary(@id int)
as
begin
	if exists (select salary from Employee where id = @id)
		select oldSalary, newSalary, dateModifyed from SalaryHistory where idEmployee = @id
	else
		select -1 as ReturnValue
end
go

exec getEmployeeSalaryById @id = 12

exec getEmployeeHistorySalary @id = 13


create or alter trigger addToSalaryHistory 
on Employee 
after update
as
begin
	insert into SalaryHistory (idEmployee, oldSalary, newSalary) 
	select 
		inserted.id, 
		deleted.salary as oldSalary, 
		inserted.salary as newSalary
	from
		inserted
	join
		deleted on inserted.id = deleted.id
	where
		inserted.salary <> deleted.salary;
end;

