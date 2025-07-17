CREATE PROCEDURE ObtenerModelo
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Modelo.Id,
        Marca.Nombre AS Marca,
        Modelo.Nombre AS Nombre
    FROM 
        Modelos Modelo
    INNER JOIN 
        Marcas Marca ON Modelo.IdMarca = Marca.Id
    WHERE 
        Modelo.Id = @Id;
END
