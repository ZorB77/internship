CREATE OR ALTER PROCEDURE getSalaryById
@EmployeeID INT,
@Salary INT OUTPUT
AS
BEGIN
SET NOCOUNT ON
	SELECT @Salary =  e.Salary 
	FROM dbo.Employee e
	WHERE EmployeeID = @EmployeeID
END

DECLARE @Salary1 INT
EXECUTE dbo.getSalaryById @EmployeeID = 1, --int
							  @Salary = @Salary1 OUTPUT --money
SELECT @Salary1 AS Salary