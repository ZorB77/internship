--create database BankTransactions

use BankTransactions
go

create table Person(
	personID int primary key identity,
	firstName varchar(100) not null,
	lastName varchar(100) not null,
	address varchar(100),
	birthDate datetime 
	)

create table Account(
	accountID int primary key identity,
	personID int,
	funds float,
	foreign key (personID) references Person(personID) on delete cascade
)

go
	create or alter trigger createAccountForNewPerson
	on Person after insert as
	begin
		insert into Account (personID, funds)
		select personID, 0
		from inserted
	end


insert into Person (firstName, lastName, address, birthDate) values
('Matei', 'Ion', 'Brasov', '1998-04-21'),
('Florin', 'Dumitru', 'Cluj-Napoca', '1988-04-21'),
('Gabriela', 'Petrescu', 'Bucuresti', '1987-09-11'),
('Maria', 'Pop', 'Cluj-Napoca', '2001-05-03')

select * from Person
select * from Account

update Account set funds = 3020 where personID = 3


go
	create or alter procedure TransferFunds(@senderAccount int , @receiverAccount int, @amount float) as
	begin 
		begin transaction

		declare @senderFunds float
		set @senderFunds = (select funds from Account where accountID = @senderAccount)

		if @amount <= 5
			begin
				raiserror('The amount has to be greater than 5.', 16, 1)
				rollback transaction
				return
			end

		if @senderFunds is null
			begin 
				raiserror('The sender account does not exist.', 16, 1)
				rollback transaction
				return
			end

		if @amount > @senderFunds
			begin
				raiserror('The sender does not have enough money.', 16, 1)
				rollback transaction
				return
			end

		declare @receiverFunds float
		set @receiverFunds = (select funds from Account where accountID = @receiverAccount)

		if @receiverFunds is null
			begin 
				raiserror('The receiver account does not exist.', 16, 1)
				rollback transaction
				return
			end

		update Account
		set funds = funds - @amount
		where accountID = @senderAccount

		update Account
		set funds = funds + @amount
		where accountID = @receiverAccount

		commit transaction
	end


	exec TransferFunds 3, 1, 50 -- the sender does not have enough money
	exec TransferFunds 2, 1, 50
