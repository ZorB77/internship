--CREATE DATABASE EmployeeSalary

use EmployeeSalary
go

create table Employee(
	employeeID int primary key identity,
	firstName varchar(100) not null,
	lastName varchar(100) not null,
	salary float not null,
	address varchar(100),
	birthDate datetime 
	)

insert into Employee (firstName, lastName, salary, address, birthDate) values
('Maria', 'Pop', 4500, 'Cluj-Napoca', '2001-05-03')

select * from Employee

insert into Employee (firstName, lastName, salary, address, birthDate) values
('Matei', 'Ion', 3800, 'Brasov', '1998-04-21'),
('Florin', 'Dumitru', 4000, 'Cluj-Napoca', '1988-04-21'),
('Gabriela', 'Petrescu', 6100, 'Bucuresti', '1987-09-11')


create table EmployeeSalaryHistory(
	employeeSalaryID int primary key identity,
	employeeID int, 
	oldSalary float,
	newSalary float,
	dateOfChange datetime default current_timestamp,
	foreign key (employeeID) references Employee(employeeID)
	)

go
	create or alter procedure UpdateEmployeeSalary(@employeeID int, @newSalary float) as
	begin 
		update Employee
		set salary = @newSalary
		where employeeID = @employeeID
	end


exec UpdateEmployeeSalary 1, 4080


go
	create or alter procedure GetEmployeeSalary(@employeeID int) as
	begin
		declare @salary float
		set @salary = (select salary from Employee where employeeID = @employeeID)

		declare @firstName varchar(100)
		set @firstName = (select firstName from Employee where employeeID = @employeeID)
		
		--print 'The salary of ' + @firstName + ' is ' + cast(@salary as varchar) + '.'
		select 'The salary of ' + @firstName + ' is ' + cast(@salary as varchar) + '.' as Result
	end

exec GetEmployeeSalary 1


go
	create or alter trigger SalaryChanges
	on Employee after update as
	begin
		if update(salary)
			begin
				insert into EmployeeSalaryHistory (employeeID, oldSalary, newSalary, dateOfChange)
				select deleted.employeeID, deleted.salary, inserted.salary, getdate()
				from inserted
				join deleted on inserted.employeeID = deleted.employeeID
				where deleted.salary <> inserted.salary
		end
	end


select * from EmployeeSalaryHistory