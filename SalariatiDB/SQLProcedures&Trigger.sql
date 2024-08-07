CREATE PROCEDURE angActualizareSalariu
@AngajatID INT, @Salariu money
AS
BEGIN
SET NOCOUNT ON
UPDATE dbo.Angajati
   SET 
      Salariu = @Salariu
 WHERE ID = @AngajatID;
END;

CREATE PROCEDURE angAfisareSalariu
@AngajatID INT, @Salariu money OUTPUT
AS
BEGIN
SELECT @Salariu = Salariu
FROM Angajati
WHERE Angajati.ID = @AngajatID
END;

DECLARE @Salariu money;
EXECUTE dbo.angAfisareSalariu
@AngajatID = 1, @Salariu = @Salariu OUTPUT;
PRINT @Salariu;

EXECUTE dbo.angActualizareSalariu 1, 12.01;

CREATE TRIGGER trgActualizareSalariu
ON Angajati
AFTER UPDATE
AS
IF UPDATE(Salariu)
BEGIN
	SET NOCOUNT ON;
	declare @idAng int;
	declare @salariuNou money;
	select @idAng=inserted.ID, @salariuNou=inserted.Salariu
	FROM inserted;
	
	update SalariatiPB1.dbo.IstoricSalarii
		SET 
			DataFinal = SYSDATETIME()
	WHERE
		AngajatId = @idAng
		AND
		DataFinal IS NULL;

	insert into dbo.IstoricSalarii
		(ID,
		AngajatID,
		Salariu,
		DataInceput)
		values (
		(SELECT MAX(ID) FROM IstoricSalarii)+1,
		@idAng,
		@salariuNou,
		SYSDATETIME());
END;
