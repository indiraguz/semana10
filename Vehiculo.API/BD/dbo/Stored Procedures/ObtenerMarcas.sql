CREATE PROCEDURE ObtenerMarcas
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Marcas.Id, Marcas.Nombre
    FROM Marcas;
END