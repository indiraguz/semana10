CREATE PROCEDURE ObtenerModelos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Modelos.Id,
        Marcas.Nombre AS Marca,
        Modelos.Nombre AS Nombre
    FROM 
        Modelos
    INNER JOIN 
        Marcas ON Modelos.IdMarca = Marcas.Id;
END
