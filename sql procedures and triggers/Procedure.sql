CREATE OR ALTER PROCEDURE moneyTransfere
@FromAccountID INT, 
@ToAccountID INT,
@Amount DECIMAL(10,2)
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @FromBalance DECIMAL(10,2)
	DECLARE @ToBalance DECIMAL(10,2)
	DECLARE @Sum DECIMAL(10,2)

	SELECT @FromBalance = b.Balance
	FROM dbo.Bank b
	WHERE b.AccountID = @FromAccountID

	SELECT @ToBalance = b.Balance
	FROM dbo.Bank b
	WHERE b.AccountID = @ToAccountID

	SET @Sum = @FromBalance - @Amount

	IF @Sum < 0
	BEGIN 
		RAISERROR('Transaction failed. Please try again!', 16, 1);
		RETURN;
	END;

	UPDATE dbo.Bank 
	SET Balance = Balance - @Amount
	WHERE AccountID = @FromAccountID;

	UPDATE dbo.Bank 
	SET Balance = Balance + @Amount
	WHERE AccountID = @ToAccountID;
END;

EXECUTE dbo.moneyTransfere @FromAccountID = 2,
						   @ToAccountID = 1,
						   @Amount = 800