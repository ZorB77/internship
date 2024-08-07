

CREATE PROCEDURE Transfers 
@FirstNameTo NVARCHAR(255),
@LastNameTo NVARCHAR(255),
@FirstNameFrom NVARCHAR(255),
@LastNameFrom NVARCHAR(255),
@Amount NUMERIC(10,2)
AS
BEGIN 
BEGIN TRANSACTION
BEGIN TRY
DECLARE @FromBalance DECIMAL(10,2);
DECLARE @ToBalance DECIMAL(10,2);

SELECT @FromBalance = ba.Balance 
FROM BankAccount ba
WHERE FirstName = @FirstNameFrom
AND LastName = @LastNameFrom

SELECT @ToBalance = ba.Balance
FROM BankAccount ba
WHERE FirstName = @FirstNameTo
AND LastName = @LastNameTo

--check if the balance is smaller
IF @FromBalance < @Amount
BEGIN;
THROW 51000, 'ERROR', 1;
END;


--the operations
UPDATE BankAccount
SET Balance = Balance+@Amount
WHERE LastName = @LastNameTo
AND FirstName = @FirstNameTo



UPDATE BankAccount 
SET Balance = Balance-@Amount
WHERE LastName= @LastNameFrom
AND FirstName = @FirstNameFrom


COMMIT TRANSACTION;
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION;
THROW;
END CATCH
END;
