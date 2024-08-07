use Exercise1;
GO
--Stored Procedures
--Update Salary

CREATE OR ALTER PROCEDURE updtdemployee
@FirstName NVARCHAR(250),
@LastName NVARCHAR(250),
@NewSalary NUMERIC(10,2),
@ChangeReason NVARCHAR(255)
AS 
BEGIN
SET NOCOUNT ON;
DECLARE @OldSalary DECIMAL (10,2);
DECLARE @EmployeeNumber INT;


 SELECT @EmployeeNumber = COUNT(*)
 FROM dbo.Employees e
 WHERE FirstName = @FirstName AND LastName = @LastName;

IF @EmployeeNumber =0
BEGIN
RAISERROR('No employee was found with the name %s %s',16,@FirstName,@LastName);
RETURN;
END
ELSE IF @EmployeeNumber >1
BEGIN 
RAISERROR('Multiple employees found with the same name: %s %s',16,@FirstName,@LastName);
RETURN;
END
--select the old salary
SELECT @OldSalary = e.Salary
FROM Employees e
WHERE FirstName = @FirstName 
AND LastName = @LastName;

--update the new one
UPDATE dbo.Employees
SET Salary = @NewSalary
WHERE FirstName = @FirstName 
AND LastName = @LastName;

INSERT INTO Salaries (EmployeeId, OldSalaries, NewSalary, ChangeReason)
SELECT e.EmployeeId, @OldSalary, @NewSalary,@ChangeReason
FROM Employees e
WHERE FirstName = @FirstName 
AND LastName = @LastName;

END;
GO

--second procedure
CREATE OR ALTER PROCEDURE GetSalary
@FirstName NVARCHAR(250),
@LastName NVARCHAR(250)
AS
BEGIN
SELECT e.Salary
FROM Employees e
WHERE FirstName = @FirstName
AND
LastName = @LastName;
END;
GO

CREATE OR ALTER TRIGGER SalaryUpdates
ON Employees
AFTER UPDATE
AS
BEGIN
SET NOCOUNT ON;

--update the salaries table
UPDATE s
SET s.NewSalary = inserted.Salary,
s.ChangedDate = GETDATE()
FROM Salaries s
JOIN inserted  ON s.EmployeeId = inserted.EmployeeId
JOIN deleted ON inserted.EmployeeId = deleted.EmployeeId
WHERE inserted.Salary <> deleted.Salary

--insert the new values into the table
INSERT INTO Salaries(EmployeeId,OldSalaries,NewSalary,ChangedDate,ChangeReason)
SELECT del.EmployeeId,
del.Salary AS OldSalaries,
ins.Salary AS NewSalary,
GETDATE() AS ChangedDate,
'SalaryUpdated' AS ChangedReason
FROM deleted del 
JOIN inserted ins ON del.EmployeeId = ins.EmployeeId
WHERE ins.Salary <> del.Salary;

END;
GO

--another procedure for getting the old salaries
CREATE OR ALTER PROCEDURE GetOldSalaries
@FirstName NVARCHAR(250),
@LastName NVARCHAR(250)
AS
BEGIN
SET NOCOUNT ON;
SELECT s.EmployeeId, s.OldSalaries,s.NewSalary,s.ChangedDate,s.ChangeReason
FROM Salaries s
JOIN Employees e ON s.EmployeeId = e.EmployeeId
WHERE e.FirstName = @FirstName 
AND e.LastName = @LastName
ORDER BY s.ChangedDate DESC;
END;
GO
EXEC GetOldSalaries @FirstName = 'Maria', @LastName = 'Popescu';
