﻿CREATE PROCEDURE EliminarVehiculos 
	@Id uniqueidentifier

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Begin Transaction
		Delete 
		FROM Vehiculo 
		Where (Vehiculo.Id=@Id)
		select @Id
	commit transaction
END