CREATE OR ALTER PROCEDURE updateEmployeeSalary
@Salary int, 
@EmployeeID int
AS
BEGIN 
SET NOCOUNT ON   --optimize the store procedure execution
	UPDATE dbo.Employee
	SET Salary = @Salary
	WHERE EmployeeID = @EmployeeID
END

EXECUTE dbo.updateEmployeeSalary @Salary = 5000,
                                 @EmployeeID = 1
SELECT * FROM dbo.Employee

