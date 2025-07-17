CREATE PROCEDURE ObtenerVehiculo
	@Id uniqueidentifier

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Vehiculo.Id, Vehiculo.IdModelo, Vehiculo.Placa, Vehiculo.Color, Vehiculo.Anio, Vehiculo.CorreoPropietario, Vehiculo.Precio, Vehiculo.TelefonoPropietario, Modelos.Nombre AS Modelo, Marcas.Nombre AS Marca
FROM     Marcas INNER JOIN
                  Modelos ON Marcas.Id = Modelos.IdMarca INNER JOIN
                  Vehiculo ON Modelos.Id = Vehiculo.IdModelo
				  where (Vehiculo.Id=@Id)
END