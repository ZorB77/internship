CREATE OR ALTER PROCEDURE bbTransferBancar
@ExpeditorIBAN VARCHAR(50), @DestinatarIBAN VARCHAR(50), @Suma money, @Mesaj VARCHAR(50) OUTPUT
AS
BEGIN
SET NOCOUNT ON
	BEGIN TRANSACTION
		declare @soldExpeditor money;
		select @soldExpeditor = Sold from ConturiBancare where IBAN = @ExpeditorIBAN;
		if (@Suma > @soldExpeditor)
		BEGIN
			set @Mesaj = 'Fonduri Insuficiente.';
			rollback transaction;	
			return;
		END
		if (@Suma <= 0)
		BEGIN
			set @Mesaj = 'Introduceti o valoare pozitiva.';
			rollback transaction;
			return;
		END
		set @Mesaj = 'Fonduri Suficiente!';
		begin try
		update ConturiBancare set Sold = Sold + @Suma where IBAN = @DestinatarIBAN;
		update ConturiBancare set Sold = Sold - @Suma where IBAN = @ExpeditorIBAN;
		insert into Tranzactii (
			ID,
			ExpeditorIBAN,
			DestinatarIBAN,
			Suma,
			DataRealizare
		)
		values 
			((select MAX(ID) FROM Tranzactii) +1,
			@ExpeditorIBAN,
			@DestinatarIBAN,
			@Suma,
			SYSDATETIME()
			)
		end try
		begin catch
		rollback transaction;
		set @Mesaj = 'Am intampinat o eroare!';
		return;
		end catch;
		COMMIT TRANSACTION;
		set @Mesaj = 'Transfer realizat cu succes!';
END