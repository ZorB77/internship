--Problema2
use Exercise1;
CREATE TABLE BankAccount (
AccountID INT PRIMARY KEY,
FirstName NVARCHAR(250),
LastName NVARCHAR(250),
Balance DECIMAL(10,2),
Email NVARCHAR(250),
DateOfTheTransaction DATETIME DEFAULT GETDATE()
)

