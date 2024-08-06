use Company

create table BankAccount(
accountId int identity(1,1) primary key,
iban varchar(20),
customerId int,
balance money,
limit money,
foreign key (customerId) references Employee(id));

INSERT INTO BankAccount (iban, customerId, balance, limit) VALUES
('GB29NWB0161331926819', 1, 1000.00, 500.00),
('DE893704004532013000', 2, 2000.00, 600.00),
('FR893703204432011010', 3, 1500.00, 700.00),
('ES912100041051051332', 4, 2500.00, 800.00),
('IT60X054281110000900', 5, 1800.00, 550.00),
('CH930076201162852957', 6, 3000.00, 900.00),
('SE455000000398257466', 7, 2100.00, 650.00),
('NL91ABNA041716774300', 8, 1600.00, 500.00),
('NO938601111099999947', 9, 2200.00, 700.00),
('GR160110125012300695', 10, 2700.00, 800.00);

select * from BankAccount
select * from Employee


select iban, Employee.firstName, Employee.lastName, balance, limit from BankAccount
left join Employee on Employee.id = BankAccount.customerId

create or alter procedure doTransaction
    @id_sender int,
    @iban_reciver varchar(20),
    @amount money
as
begin
    begin transaction;

    if exists (select * from Employee where id = @id_sender)
    begin
        if exists (select * from BankAccount where iban = @iban_reciver)
        begin
            declare @senderBalance money;
			declare @senderLimit money;
            select @senderBalance = balance, @senderLimit = limit from BankAccount where customerId = @id_sender;

			if @senderLimit >= @amount
			begin
				if @senderBalance >= @amount
				begin
					update BankAccount set balance = balance - @amount where customerId = @id_sender;

					update BankAccount set balance = balance + @amount where iban = @iban_reciver;

					commit transaction;
					select 'Transaction made successfully!';
				end
				else
				begin
					rollback transaction;
					select 'Error: Insufficient balance!';
				end
			end
			else
			begin
				rollback transaction;
				select 'Error: The sender limit was exceded!';
			end
        end
        else
        begin
            -- eroare: receiver-ul nu există
            rollback transaction;
            select 'Error: The receiver does not exist!';
        end
    end
    else
    begin
        -- eroare: sender-ul nu există
        rollback transaction;
        select 'Error: The sender does not exist!';
    end
end;

exec doTransaction @id_sender = 9, @iban_reciver = 'GB29NWB0161331926819', @amount = 110 

select * from BankAccount

select @@TRANCOUNT