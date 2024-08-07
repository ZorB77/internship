use Exercise1;

CREATE TABLE Employees(
EmployeeId INT PRIMARY KEY,
FirstName NVARCHAR(250),
LastName NVARCHAR(250),
Salary NUMERIC(10,2),
Age INT)

CREATE TABLE Salaries(
SalariesId INT IDENTITY(1,1) PRIMARY KEY,
EmployeeId INT,
OldSalaries NUMERIC(10,2),
NewSalary NUMERIC(10,2),
ChangedDate DATETIME DEFAULT GETDATE(),
FOREIGN KEY(EmployeeId) REFERENCES Employees(EmployeeId)
);


SELECT * 
FROM Salaries

ALTER TABLE Salaries
ADD ChangeReason NVARCHAR(255);




