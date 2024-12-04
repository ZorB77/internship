CREATE OR ALTER TRIGGER getSalaryHistory
ON dbo.Employee
AFTER UPDATE
AS
BEGIN
	INSERT INTO dbo.Salaries (EmployeeID, Salary)
	SELECT deleted.EmployeeID, inserted.Salary
	FROM inserted
	JOIN deleted ON inserted.EmployeeID = deleted.EmployeeID
	WHERE deleted.Salary <> inserted.Salary
END